using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;


namespace TrackerLibrary.DataAccess.TextHelper
{
    public static class TextconnectorProcessor
    {

        // General Utilities
        public static string Pathfinder(this string fileName)
        {
            //C:\Users\PouriaPC\Desktop\TornementTracker\{file}
            return $"{ConfigurationManager.AppSettings["filepath"]}\\{fileName}";
        }
        public static List<string> LoadFile(this string file)
        {
            return File.Exists(file)==false ? new List<string>() : File.ReadAllLines(file).ToList();
        }
        //PrizeModel
        public static List<PrizeModel> ConvertorToPrizeModel(this List<string> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();
          
            
                foreach (string line in lines)
                {
                    
                    string[] col = line.Split(',');
                    PrizeModel p = new PrizeModel()
                    {
                        Id = int.Parse(col[0]),
                        PlaceNumber = int.Parse(col[1]),
                        PlaceName = col[2],
                        PrizeAmount = decimal.Parse(col[3]),
                        PrizePercentage = double.Parse(col[4])
                    };
                    output.Add(p);
                }
            
            

            
            return output;
        }
        public static void SaveToPrizedFile(this List<PrizeModel> models, string filename)
        {
            List<string> lines = new List<string>();        
            foreach (PrizeModel p in models)
            {
                lines.Add($"{p.Id},{p.PlaceNumber},{p.PlaceName},{p.PrizeAmount},{p.PrizePercentage}");
            }

            File.WriteAllLines(filename.Pathfinder(), lines);
        }

        // PersonModel
        public static List<PersonModel> ConvertorToPersonModel(this List<string> lines)
            
        {
            List<PersonModel> output = new List<PersonModel>();
            foreach (string line in lines)
            {
                string[] col = line.Split(',');
                PersonModel p = new PersonModel
                {
                    ID = int.Parse(col[0]),
                    FirstName = col[1],
                    LastName = col[2],
                    EmailAddress = col[3],
                    CellPhoneNumber = col[4]
                };
                output.Add(p);
            }


            return output;

        }
        public static void SaveToPrizedFile(this List<PersonModel> models, string filename)
        {
            List<string> lines = new List<string>();
            foreach (PersonModel p in models)
            {
                lines.Add($"{p.ID},{p.FirstName},{p.LastName},{p.EmailAddress},{p.CellPhoneNumber}");
            }

            File.WriteAllLines(filename.Pathfinder(), lines);
        }

        //TeamModel
        public static List<TeamModel> ConvertToTeamModel(this List<string>lines)
        {
            List<TeamModel> output = new List<TeamModel>();
            foreach (string line in lines)
            {
                TeamModel team = new TeamModel();
                string[] cols = line.Split(',');
                team.Id = int.Parse(cols[0]);
                team.TeamName = cols[1];
                team.TeamMember = GiveTeamMember(cols[2]);
                output.Add(team);
            }

            return output;
        }
        private static List<PersonModel> GiveTeamMember(string idTeamMember)
        {
            List<PersonModel> tm = new List<PersonModel>();
            List<PersonModel> People = "PersonModel.csv".Pathfinder().LoadFile().ConvertorToPersonModel();
            string[] col = idTeamMember.Split('|');

            foreach (PersonModel person in People)
            {
                foreach (string item in col)
                {
                    if (int.Parse(item) == person.ID)
                        tm.Add(person);
                }
            }
            return tm;
        }
        public static void SaveToTeamFile(this List<TeamModel>tm,string teamfile)
        {
            List<string> AllData = new List<string>();
            foreach (TeamModel item in tm)
            {
                AllData.Add($"{item.Id},{item.TeamName},"+GiveTeamMemberIdToString(item));
            }
            File.WriteAllLines(teamfile.Pathfinder(), AllData);
        }
        private static string GiveTeamMemberIdToString(TeamModel tm)
        {
            string output="";
            if (tm.TeamMember == null)
                return output;
            foreach (PersonModel item in tm.TeamMember)
            {
                output += $"{item.ID}|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }

        //TournementModel
        public static List<TournementModel> ConvertToTournementModel(this List<string> lines )
        {
            List<TournementModel> tm = new List<TournementModel>();
            foreach (string item in lines)
            {
                TournementModel tmp = new TournementModel();
                string[] cols = item.Split(',');
                tmp.Id = int.Parse(cols[0]);
                tmp.TournementName = cols[1];
                tmp.TournementFee = decimal.Parse(cols[2]);
                tmp.EntryTeams = giveTeams(cols[3]);
                tmp.Prizes = givePrizes(cols[4]);
                tmp.Rounds = giveRounds(cols[5],tmp.Id);
                tm.Add(tmp);
            }
            return tm;
        }
        private static List<TeamModel> giveTeams(string teams)
        {
            List<TeamModel> tm = new List<TeamModel>();
            List<TeamModel> Allteams = "TeamModel.csv".Pathfinder().LoadFile().ConvertToTeamModel();
            teams = teams.Substring(1, teams.Length - 2);
            string[] cols = teams.Split(' ');
            foreach (string item in cols)
            {
                foreach (TeamModel team in Allteams)
                {
                    if (team.TeamName==item)
                    {
                        tm.Add(team);
                    }
                }
            }
            return tm;
        }
        private static List<PrizeModel> givePrizes(string prizes)
        {
            List<PrizeModel> priz = new List<PrizeModel>();
            List<PrizeModel> ALLPrizes = "PrizedModel.csv".Pathfinder().LoadFile().ConvertorToPrizeModel();
            prizes = prizes.Substring(1, prizes.Length - 2);
            string[] cols = prizes.Split(' ');
            foreach (string item in cols)
            {
                string[] col = item.Split('|');
                foreach (PrizeModel prizel in ALLPrizes)
                {
                    if (int.Parse(col[0])==prizel.Id)
                    {
                        priz.Add(prizel);
                    }
                }

            }
            return priz;
        }
        private static List<List<MatchupModel>> giveRounds(string rounds,int tournementId)
        { // id id id|id id id|id id

            List<List<MatchupModel>> tempraryRounds = new List<List<MatchupModel>>();
            List<MatchupModel> matchupEntriesInfo = new List<MatchupModel>();
            matchupEntriesInfo = "MatchUpModel.csv".Pathfinder().LoadFile().ConvertorToMatchUp();
            rounds = rounds.Substring(1, rounds.Length - 2);
            string[] roundscol = rounds.Split('|');
            foreach (string itemRound in roundscol)
            {
                 string[] matchupscol = itemRound.Split(' ');
                List<MatchupModel> temporaryRound = new List<MatchupModel>();
                foreach (string itemMatchup in matchupscol)
                {
                    foreach (MatchupModel item in matchupEntriesInfo)
                    {
                        if (item.ID == int.Parse(itemMatchup))
                            temporaryRound.Add(item);
                    }
                }
                tempraryRounds.Add(temporaryRound);
            }
            return tempraryRounds;
        }
        private static List<MatchupModel> ConvertorToMatchUp(this List<string>lines)
        {
            //matchupid=col[0],tournemetntid=col[1],round=col[2],winnerid=col[3],entriesteam=col[4](id1|id2)

            List<MatchupModel> matchups = new List<MatchupModel>();
            List<TeamModel> teams = "TeamModel.csv".Pathfinder().LoadFile().ConvertToTeamModel();
            
            List<MatchupEntryModel> entries = "MatchUpEntryModel.csv".Pathfinder().LoadFile().ConvertToMatchUpEntryModel();
            foreach (string item in lines)
            {
                MatchupModel tempMatchup = new MatchupModel();
                string[] col = item.Split(',');
                tempMatchup.ID = int.Parse(col[0]);
                tempMatchup.TournementId = int.Parse(col[1]);
                tempMatchup.MatchupRound = int.Parse(col[2]);

                foreach (TeamModel team in teams)
                {
                    if(col[3]==" ")
                    {
                        tempMatchup.Winner = null;
                        break;
                    }
                    if (team.Id == int.Parse(col[3]) )
                    {
                        tempMatchup.Winner = team;
                        break;

                    }
                }
                matchups.Add(tempMatchup);
                string[] colMatchupEntries = col[4].Split('|');
                foreach (MatchupEntryModel matchupEntryModel in entries)
                {

                    foreach (string stringitem in colMatchupEntries)
                    {
                        if (matchupEntryModel.ID == int.Parse(stringitem) ||
                                       matchupEntryModel.ID == int.Parse(stringitem))
                        {
                            tempMatchup.Entries.Add(matchupEntryModel);
                        }
                       
                    }
                }
            }

            return matchups;
        }
        private static List<MatchupEntryModel> ConvertToMatchUpEntryModel(this List<string> lines)
        {
            // matchupentryId=col[0],teamcompetingId=col[1],score=col[2],parentmatchupId=col[3]
            List<MatchupEntryModel> matchupEntryModels = new List<MatchupEntryModel>();
            List<TeamModel> teamModels = "TeamModel.csv".Pathfinder().LoadFile().ConvertToTeamModel();
           // List<MatchupModel> matchupModels= "MatchUpModel.csv".Pathfinder().LoadFile().ConvertorToMatchUp();
            foreach (string item in lines)
            {
                MatchupEntryModel matchupEntryModel = new MatchupEntryModel();
                string[] col = item.Split(',');
                matchupEntryModel.ID = int.Parse(col[0]);
                if (col[1] == " ")
                    matchupEntryModel.TeamCompeting = null;
                else
                {
                    foreach (TeamModel team in teamModels)
                    {
                        if (team.Id == int.Parse(col[1]))
                        {
                            matchupEntryModel.TeamCompeting = team;

                        }

                    } 
                }
                if (col[2] == " ")
                    matchupEntryModel.Score = null;
                else
                {
                    matchupEntryModel.Score = double.Parse(col[2]);
                }
                if (col[3] == " ")
                    matchupEntryModel.ParentMatchup = null;
                else
                {
                    matchupEntryModel.ParentMatchup.ID =int.TryParse(col[3],out var f)?f:default(int?);
                }
                matchupEntryModels.Add(matchupEntryModel);
            }

            return matchupEntryModels;
        }
        private static List<List<MatchupModel>> lookUpMatchupById(TournementModel tour1)
        {
            int RoundsNumber = tour1.Rounds.Count;
            for (int i = 2; i <RoundsNumber; i++)
            {
                List<MatchupModel> output = new List<MatchupModel>();
                List<MatchupModel> lastMatchUps = tour1.Rounds[i - 2];
                MatchupModel temp = new MatchupModel();
                foreach (MatchupModel item in lastMatchUps)
                {
                    //MatchupEntryModel temp2 = new MatchupEntryModel();
                    //temp2.ParentMatchup = item;
                    //temp.Entries.Add(temp2);
                    //if (temp.Entries.Count > 1)
                    //{
                    //    output.Add(temp);
                    //    temp = new MatchupModel();
                    //}
                    foreach (MatchupModel matchup in tour1.Rounds[i-1])
                    {
                        foreach (MatchupEntryModel matchupEntry in matchup.Entries)
                        {
                            if(matchupEntry.ParentMatchup==null)
                            {
                                matchupEntry.ParentMatchup = item;
                                break;
                            }
                            
                        }
                        break;
                    }

                }
                //temporaray.Add(output);
            }
            
            return tour1.Rounds;
        }
        public static void SaveToMatchUpEntriesFile(this TournementModel Tour)
        {
            // matchupentryId=col[0],teamcompetingId=col[1],score=col[2],parentmatchupId=col[3]
            
            List<string> lines = new List<string>();
            List<MatchupEntryModel> matchupEntryModels = "MatchUpEntryModel.csv".Pathfinder().LoadFile().ConvertToMatchUpEntryModel();
            Tour.Rounds = lookUpMatchupById(Tour);
            foreach (List<MatchupModel> item in Tour.Rounds)
            {
                List<MatchupModel> currentMatchUps = new List<MatchupModel>();
                foreach (MatchupModel matchup in item)
                {
                    foreach (MatchupEntryModel matchupEntry in matchup.Entries)
                    {
                        if (matchupEntryModels.Count == 0)
                            matchupEntry.ID = 1;
                        else
                        {
                            matchupEntry.ID = matchupEntryModels.OrderByDescending(x =>x.ID).First().ID + 1;
                        }
                        matchupEntryModels.Add(matchupEntry); 
                    }

                }
            }
            foreach (MatchupEntryModel item in matchupEntryModels)
            {
                
                string matchupstring = $"{item.ID},";
                if (item.TeamCompeting == null)
                    matchupstring += " ,";
                else
                    matchupstring += $"{item.TeamCompeting.Id},";
                if (item.Score == null)
                    matchupstring += " ,";
                else
                    matchupstring += $"{item.Score},";
                if (item.ParentMatchup == null)
                    matchupstring += " ";
                else
                    matchupstring += $"{item.ParentMatchup.ID}";
                lines.Add(matchupstring);
            }

            File.WriteAllLines("MatchUpEntryModel.csv".Pathfinder(), lines);
        }
        public static void MatchUps_Update(this MatchupModel model)
        {
            List<string> lines = new List<string>();

            List<MatchupModel> matchups = "MatchUpModel.csv".Pathfinder().LoadFile().ConvertorToMatchUp();
            MatchupModel oldmatchup = new MatchupModel();
            foreach (MatchupModel item in matchups)
            {
                if (model.ID == item.ID)
                    oldmatchup = item;
            }
            matchups.Remove(oldmatchup);
            matchups.Add(model);

            foreach (MatchupEntryModel item in model.Entries)
            {
                item.UpdateToMatchUpEntriesFile(); 
            }


            //matchupid=col[0],tournemetntid=col[1],round=col[2],winnerid=col[3],entriesteam=col[4]
            matchups.OrderByDescending(x => x.ID).First();
            foreach (MatchupModel item in matchups)
            {
                if (item.Winner == null)
                {
                    lines.Add($"{item.ID},{item.TournementId},{item.MatchupRound}," + " ," + giveMatchUpEntriesId(item));
                }
                else
                    lines.Add($"{item.ID},{item.TournementId},{item.MatchupRound},{item.Winner.Id}," + giveMatchUpEntriesId(item));
            }

            File.WriteAllLines("MatchUpModel.csv".Pathfinder(), lines);
        }
        public static void UpdateToMatchUpEntriesFile(this MatchupEntryModel model)
        {
            List<string> lines = new List<string>();
            List<MatchupEntryModel> matchupEntryModels = "MatchUpEntryModel.csv".Pathfinder().LoadFile().ConvertToMatchUpEntryModel();
            MatchupEntryModel oldMatchupEntryModel = new MatchupEntryModel();
            foreach (MatchupEntryModel item in matchupEntryModels)
            {
                if (item.ID == model.ID)
                    oldMatchupEntryModel = item;
            }
            matchupEntryModels.Remove(oldMatchupEntryModel);
            matchupEntryModels.Add(model);
            matchupEntryModels.OrderByDescending(x => x.ID);
            foreach (MatchupEntryModel item in matchupEntryModels)
            {

                string matchupstring = $"{item.ID},";
                if (item.TeamCompeting == null)
                    matchupstring += " ,";
                else
                    matchupstring += $"{item.TeamCompeting.Id},";
                if (item.Score == null)
                    matchupstring += " ,";
                else
                    matchupstring += $"{item.Score},";
                if (item.ParentMatchup == null)
                    matchupstring += " ";
                else
                    matchupstring += $"{item.ParentMatchup.ID}";
                lines.Add(matchupstring);
            }
            File.WriteAllLines("MatchUpEntryModel.csv".Pathfinder(), lines);

        }
        public static void SaveToMatchUpFile(this TournementModel Tour)
        {
            //matchupid=col[0],tournemetntid=col[1],round=col[2],winnerid=col[3],entriesteam=col[4]

            List<string> lines = new List<string>();
            
            List<MatchupModel> matchups = "MatchUpModel.csv".Pathfinder().LoadFile().ConvertorToMatchUp();
           
           
            foreach (List<MatchupModel> item in Tour.Rounds)
            {
                foreach (MatchupModel matchup in item)
                {
                    matchup.TournementId = Tour.Id;
                    if (matchups.Count == 0)
                        matchup.ID = 1;
                    else
                    {
                        matchup.ID = matchups.OrderByDescending(x => x.ID).First().ID + 1;
                    }
                    matchups.Add(matchup);
                    
                }

            }
            Tour.SaveToMatchUpEntriesFile();

            
            //matchupid=col[0],tournemetntid=col[1],round=col[2],winnerid=col[3],entriesteam=col[4]
            foreach (MatchupModel item in matchups)
            {
                if(item.Winner==null)
                {
                lines.Add($"{item.ID},{item.TournementId},{item.MatchupRound}," +" ,"+giveMatchUpEntriesId(item));
                }
               else
                lines.Add($"{item.ID},{item.TournementId},{item.MatchupRound},{item.Winner.Id},"+giveMatchUpEntriesId(item));
            }
           
            File.WriteAllLines("MatchUpModel.csv".Pathfinder(), lines);
        }
        public static void SaveToTournementFile(this List<TournementModel> Tour)
        {
            List<string> lines = new List<string>();
            foreach (TournementModel item in Tour)
            {
                lines.Add($"{item.Id},{item.TournementName},{item.TournementFee},"+giveTeamsToString(item)+givePrizesToString(item)+giveRoundsToString(item));
            }
            File.WriteAllLines("TournementModel.csv".Pathfinder(), lines);
        }
        private static string giveMatchUpEntriesId(MatchupModel matchup)
        {
            
            string st = string.Empty;
            
            foreach (MatchupEntryModel item in matchup.Entries)
            {
                st += item.ID + "|";
            }
            st = st.Substring(0, st.Length - 1);
            return st;

        }
        private static string giveTeamsToString(TournementModel tm)
        {
            string st = string.Empty;
            st += '{';
            foreach (TeamModel item in tm.EntryTeams)
            {
                st += item.TeamName+" ";
            }
            st = st.Substring(0, st.Length - 1);
           return (st += "},");
            
        }
        private static string givePrizesToString(TournementModel tm)
        {
            string st = string.Empty;
            st += '{';
            foreach (PrizeModel item in tm.Prizes)
            {
                st += $"{item.Id}|PlaceName:{item.PlaceName}|PrizeAmount:{item.PrizeAmount}|PrizePercentage:{item.PrizePercentage}"+" ";
            }
            //last charackter must be reduced because it has extra space which is determined by  (GivetoPrize)  function as determiner.
            st = st.Substring(0, st.Length - 1);
            return (st += "},");
        }
        private static string giveRoundsToString(TournementModel tm)
        {
            string st = string.Empty;
            st += '{';
            foreach (List<MatchupModel> item in tm.Rounds)
            {
                foreach (MatchupModel matchupitem in item)
                {
                    st += $"{matchupitem.ID}" + " "; 
                }
                st = st.Substring(0, st.Length - 1);
                st += '|';
            }
            //last charackter must be reduced because it has extra space which is determined by  (GivetoPrize)  function as determiner.
            st = st.Substring(0, st.Length - 1);
            return (st += "}");
        }
        private static string giveMatchupEntriesToString(MatchupModel Mu)
        {
            string st = string.Empty;
            
            foreach (MatchupEntryModel item in Mu.Entries)
            {
                
                    
                    st += $"{item.ParentMatchup.ID},";
               
                   
                
            }
            
            if(st!="")return st = st.Substring(0, st.Length - 1);
            return st;
        }
    }
}
