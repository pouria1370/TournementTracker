using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelper;
using System.IO;

namespace TrackerLibrary.DataAccess
{
    class TextConnector : IDataConnection
    {
        private const string PrizeFile = "PrizedModel.csv";
        private const string PersonFile = "PersonModel.csv";
        private const string TeamFile = "TeamModel.csv";
        private const string TournementFile = "TournementModel.csv";
        private const string MatchUpFile = "MatchUpModel.csv";
        private const string MatchUpEntriesFile = "MatchUpEntryModel.csv";
        #region Creates

        public TeamModel CreateTeam(TeamModel team1)
        {
            //1:teamid,teamname,person1id|person2id|person3id...
            List<TeamModel> teams = TeamFile.Pathfinder().LoadFile().ConvertToTeamModel();
            if(teams.Count==0)
                team1.Id = 1;
            else 
            {
                team1.Id = teams.OrderByDescending(x => x.Id).First().Id + 1;
            }
            teams.Add(team1);
           teams. SaveToTeamFile(TeamFile);

            return team1;
        }
        PersonModel IDataConnection.CreatePerson(PersonModel person1)
        {
            List<PersonModel> persones = PersonFile.Pathfinder().LoadFile().ConvertorToPersonModel();
            int CurrentId=1;
            if (persones.Count > 0)
                CurrentId = persones.OrderByDescending(x => x.ID).First().ID;

            person1.ID = CurrentId + 1;
            persones.Add(person1);
            persones.SaveToPrizedFile(PersonFile);

            return person1;
        }
        PrizeModel IDataConnection.CreatePrize(PrizeModel model)
        {
            //load the textfile
            // convert the text to list of prizemodel
            List<PrizeModel> prizes = PrizeFile.Pathfinder().LoadFile().ConvertorToPrizeModel();
            if (prizes.Count==0)
                model.Id = 1;
              else
            {
                model.Id = prizes.OrderByDescending(x => x.Id).First().Id+1;

            }

            //find the max id
            //record the new id
            
            //convert the prizes in the List<string>
            prizes.Add(model);
            prizes.SaveToPrizedFile(PrizeFile);
            //save the Lit<string> to the file

            return model;
        }
        public TournementModel CreateTournement(TournementModel Tournement1)
        {
            List<TournementModel> Tm = new List<TournementModel>();
            Tm = TournementFile.Pathfinder().LoadFile().ConvertToTournementModel();
            if (Tm.Count == 0)
                Tournement1.Id = 1;
            else
            {
                Tournement1.Id = Tm.OrderByDescending(x => x.Id).First().Id + 1;
            }
            //Tournement1.SaveToMatchUpEntriesFile();
            Tournement1.SaveToMatchUpFile();
            Tm.Add(Tournement1);
            Tm.SaveToTournementFile();

            return Tournement1;
        }
        #endregion
        #region Get_Alls
        public List<PersonModel> Get_All()
        {
            return  PersonFile.Pathfinder().LoadFile().ConvertorToPersonModel();
        }

        public List<TeamModel> Get_All_Teams()
        {
            List<TeamModel> output = TeamFile.Pathfinder().LoadFile().ConvertToTeamModel();
            return output;
        }

        public List<PrizeModel> Get_All_Prizes()
        {
            List<PrizeModel> output = PrizeFile.Pathfinder().LoadFile().ConvertorToPrizeModel();
            return output;
        }

        public List<TournementModel> Get_All_Tournements()
        {

            return "TournementModel.csv".Pathfinder().LoadFile().ConvertToTournementModel();
        }


        #endregion
        public void UpdateMatchUp(MatchupModel model)
        {
            model.MatchUps_Update();
        }

        public void CompleteTournement(TournementModel model)
        {
            List<TournementModel> Tm = new List<TournementModel>();
            Tm = TournementFile.Pathfinder().LoadFile().ConvertToTournementModel();
           
            Tm.Remove(model);
            Tm.SaveToTournementFile();
            CreateRounds.UpdateTournementResult(model);
            
           
        }
    }
}
