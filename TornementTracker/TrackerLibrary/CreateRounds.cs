using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary
{
    public static class CreateRounds
    {
        public static void ConfigurationRounds(TournementModel model)
        {
            randomizingTeamList(model.EntryTeams);
            populationTeams(model);

        }
        // all teams must be randomized
        private static void randomizingTeamList(List<TeamModel> team)
        {
            team.OrderBy(a => Guid.NewGuid()).ToList();
        }
        // then all teams must e calculated based on power of2 (2^n) 
        //then if their number is less than expected we add BYE and then first round will be created
        private static void populationTeams(TournementModel Tournementteam)
        {
            int n = 2;
            int count = 1;
            int counter = 0;
            int countOfBuys = 0;
            while(count<Tournementteam.EntryTeams.Count)
            {

                count=Power(n,++counter);
                
            }
            countOfBuys = count - Tournementteam.EntryTeams.Count;
            createFirstRound(Tournementteam, countOfBuys);
            createnextRounds(Tournementteam, counter);
        }
        private static int Power(int n,int p)
        {
            int count = 1;
            for(int i=1;i<=p;i++)
            {
                count = count * n;
            }
            return count;
        }
        // then first Tournemet must be created
        private static void createFirstRound(TournementModel model,int Buys)
        {
            model.Rounds.Add(occupy(model, Buys));
            
        }
        private static  List<MatchupModel> occupy(TournementModel tour1,int Buys)
        {
            List<MatchupModel> output = new List<MatchupModel>();
            MatchupModel temp = new MatchupModel();
            temp.MatchupRound = 1;
            //temp.TournementId = tour1.Id;
            //int id = 1;
            
            foreach (TeamModel item in tour1.EntryTeams)
            {
                
                MatchupEntryModel temp2 = new MatchupEntryModel();
                temp2.TeamCompeting = item;
                temp.Entries.Add(temp2);
                if(temp.Entries.Count>1||Buys>0)
                {
                    //temp.ID = id++;
                    output.Add(temp);
                    Buys--;
                    temp = new MatchupModel();
                    temp.MatchupRound = 1;
                   // temp.TournementId = tour1.Id;

                }
            }
            return output;
        }
        //then the other tournements must be added until finals matchup
        private static void createnextRounds(TournementModel model,int Rounds)
        {
            
            for (int i = 2; i <=Rounds; i++)
            {
                List<MatchupModel> output = new List<MatchupModel>();
                List<MatchupModel> lastMatchUps = model.Rounds[i-2];
                //int? id = lastMatchUps.OrderByDescending(x => x.ID).First().ID;
                MatchupModel temp = new MatchupModel();
                foreach (MatchupModel item in lastMatchUps)
                {
                    MatchupEntryModel temp2 = new MatchupEntryModel();
                    temp2.ParentMatchup = item;
                    temp.Entries.Add(temp2);
                    if (temp.Entries.Count > 1 )
                    {
                       // temp.ID = ++id;
                        temp.MatchupRound = i;
                        //temp.TournementId = model.Id;
                        output.Add(temp);
                        temp = new MatchupModel();

                    }
                }
                model.Rounds.Add(output);
            }
        }
        public static void UpdateTournementResult(TournementModel tournement)
        {
            int startround = tournement .CheckRound();
            List<MatchupModel> toscore = new List<MatchupModel>();
            foreach (List<MatchupModel> round in tournement.Rounds)
            {
                foreach (MatchupModel matchup in round)
                {
                    if (matchup.Winner == null && (matchup.Entries.Any(x => x.Score != 0) || matchup.Entries.Count == 1))
                        toscore.Add(matchup);
                }
            }
            MarkWinnersInMatchUps(toscore);
            
           
            toscore.ForEach(x=>GlobalConfig.Connection.UpdateMatchUp(x));
            AdvanceWinner(toscore,tournement);
            int endround = tournement.CheckRound();
            if(endround>startround)
            {
                AllertUsersToNewRound(tournement);
            }
        }
        private static void AllertUsersToNewRound(TournementModel tournement)
        {
            int currRound = tournement.CheckRound();
            List<MatchupModel> currmatchups = tournement.Rounds.Where(x => x.First().MatchupRound == currRound).First();
            foreach (MatchupModel matchup in currmatchups)
            {
                foreach (MatchupEntryModel matchupEntry in matchup.Entries)
                {
                    foreach (PersonModel person in matchupEntry.TeamCompeting.TeamMember)
                    {
                        AllertPersonToNewRound(person, matchupEntry.TeamCompeting, 
                            matchup.Entries.Where
                            (x => x.TeamCompeting != matchupEntry.TeamCompeting).FirstOrDefault());
                            
                    }
                }
            }
        }

        private static void AllertPersonToNewRound(PersonModel person, TeamModel teamCompeting, MatchupEntryModel competitor)
        {
            if(person.EmailAddress==null)
            {
                return;
            }
            string to ="";
            string subject = "";
            StringBuilder body = new StringBuilder();
            if (competitor.TeamCompeting!=null)
            {
                subject= $"You Have New matchup with {competitor.TeamCompeting.TeamName}";
                body.AppendLine("<h1>Hello my friend you have new match with</h1>");
                body.Append("<strong>Competitor</strong>");
                body.Append(competitor.TeamCompeting.TeamName);
                body.AppendLine();
                body.AppendLine();
                body.Append("kheili Nazi");
                body.AppendLine("Tournement Tracker");
            }
            else
            {
               subject= $"You Have off week with no competitor. ";
                body.AppendLine("<h1>Hello my friend you have Off Week<strong>Enjoy</strong></h1>");
            }
            to=person.EmailAddress;
            EmailLogic.SendEmail( to, subject, body.ToString());
        }

        private static int CheckRound(this TournementModel tournement)
        {
            int round = 1;
            foreach (List<MatchupModel> item in tournement.Rounds)
            {
                if (item.All(x => x.Winner != null))
                    round += 1;
                else
                {
                    return round;
                }
            }
            tournement.CompleteRound() ;
            return round - 1;
        }

        private static void CompleteRound(this TournementModel model)
        {
            GlobalConfig.Connection.CompleteTournement(model);
            TeamModel winners = model.Rounds.Last().First().Winner;
            TeamModel runnerUp = model.Rounds.Last().First().Entries.Where(x => x.TeamCompeting != winners).First().TeamCompeting;
            decimal winnerPrize = 0;
            decimal runnerUpPrize = 0;
            if (model.Prizes.Count>0)
            {
                decimal totalIncome = model.EntryTeams.Count * model.TournementFee;
                PrizeModel firstPlacePrize = model.Prizes.Where(x => x.PlaceNumber == 1).FirstOrDefault();
                PrizeModel secondPlacePrize = model.Prizes.Where(x => x.PlaceNumber == 2).FirstOrDefault();
                if (firstPlacePrize!=null)
                {
                    winnerPrize = firstPlacePrize.CalculatePrizePayOut(totalIncome);
                }
                if (secondPlacePrize != null)
                {
                    winnerPrize = secondPlacePrize.CalculatePrizePayOut(totalIncome);
                }
            }
            
            string subject = "";
            StringBuilder body = new StringBuilder();
            
                subject = $"{model.TournementName},{winners.TeamName} is champion";
                body.AppendLine("<h1>We Have A Cahmpion!!</h1>");
                body.AppendLine($"<strong>{winners.TeamName}</strong>");
                body.AppendLine("<p>this Tournemnt was very exciting and fairplay THX");
                body.AppendLine();
                body.AppendLine();
               if(winnerPrize>0)
               {
                body.AppendLine($"<p>The prize of champion: {winnerPrize}</p>");
               }
            if (runnerUpPrize>0)
            {
                body.AppendLine($"<p>The prize of Second: {runnerUpPrize}</p>");

            }
            body.AppendLine("<strong>THx for pursuting our matches</strong>");
            body.AppendLine("Tournemnt Tracker");
            List<string> bcc = new List<string>();
            foreach (TeamModel team in model.EntryTeams)
            {
                foreach (PersonModel person in team.TeamMember)
                {
                    if (person.EmailAddress.Length>0)
                    {
                        bcc.Add(person.EmailAddress); 
                    }
                }
            }
            EmailLogic.SendEmail(new List<string> { },bcc,subject, body.ToString());
            model.CompleteTournement();


        }
        private static decimal CalculatePrizePayOut(this PrizeModel prize,decimal totallincome)
        {
            decimal output = 0;
            if(prize.PrizeAmount>0)
            {
                output = prize.PrizeAmount;
            }
            else
            {
                output =Decimal.Multiply( totallincome ,Convert.ToDecimal(prize.PrizePercentage) / 100);
            }
            return output;

        }
        private static void AdvanceWinner(List<MatchupModel> toscore ,TournementModel tournement)
        {
            foreach (MatchupModel item in toscore)
            {
                foreach (List<MatchupModel> round in tournement.Rounds)
                {
                    foreach (MatchupModel matchupModel in round)
                    {
                        foreach (MatchupEntryModel matchupEntryModel in matchupModel.Entries)
                        {
                            if (matchupEntryModel.ParentMatchup != null)
                            {
                                if (matchupEntryModel.ParentMatchup.ID == item.ID)
                                {
                                    matchupEntryModel.TeamCompeting = item.Winner;
                                    matchupEntryModel.TeamCompetingId = item.WinnerId;
                                    GlobalConfig.Connection.UpdateMatchUp(matchupModel);

                                }
                            }

                        }
                    }
                } 
            }
        }

        private static void MarkWinnersInMatchUps(List<MatchupModel> toscore)
        {
            string situation = ConfigurationManager.AppSettings["HighWin"];
            if(situation=="1")
            {
                foreach (MatchupModel m in toscore)
                {
                    if (m.Entries.Count == 1)
                    {
                        m.Winner = m.Entries[0].TeamCompeting;
                        m.WinnerId = m.Entries[0].TeamCompeting.Id;
                        continue;
                    }
                    if (m.Entries[0].Score > m.Entries[1].Score)
                    {
                        m.Winner = m.Entries[0].TeamCompeting;
                        m.WinnerId = m.Entries[0].TeamCompeting.Id;
                    }
                    else if (m.Entries[0].Score < m.Entries[1].Score)
                    {
                        m.Winner = m.Entries[1].TeamCompeting;
                        m.WinnerId = m.Entries[1].TeamCompeting.Id;
                    }
                    else
                        //throw new Exception("we can not handle tied scores");
                        m.Winner = null;
                }
            }
            else
            {
                foreach (MatchupModel m in toscore)
                {
                    if (m.Entries.Count == 1)
                    {
                        m.Winner = m.Entries[0].TeamCompeting;
                        m.WinnerId = m.Entries[0].TeamCompeting.Id;
                        continue;
                    }
                    if (m.Entries[0].Score > m.Entries[1].Score)
                    {
                        m.Winner = m.Entries[1].TeamCompeting;
                        m.WinnerId = m.Entries[1].TeamCompeting.Id;
                    }
                    else if (m.Entries[0].Score < m.Entries[1].Score)
                    {
                        m.Winner = m.Entries[0].TeamCompeting;
                        m.WinnerId = m.Entries[0].TeamCompeting.Id;
                    }
                    else
                        //throw new Exception("we can not handle tied scores");
                        m.Winner = null;

                }
            }
           
        }
    }
}
