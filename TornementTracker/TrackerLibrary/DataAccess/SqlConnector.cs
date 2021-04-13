using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using Dapper;
//@PlaceNumber int,
//	@PlaceName nvarchar(50),
//	@PrizeAmount money,
//    @PrizePercentage float,
//	@id int = 0 output

namespace TrackerLibrary.DataAccess
{

    public class SqlConnector : IDataConnection
    {
        #region Creates
        public PersonModel CreatePerson(PersonModel person1)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournement")))
            {

                var p = new DynamicParameters();

                p.Add("@FirstName", person1.FirstName);
                p.Add("@LastName", person1.LastName);
                p.Add("@EmailAddress", person1.EmailAddress);
                p.Add("@CellPhoneNumber", person1.CellPhoneNumber);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spPersonModel_Insert", p, commandType: CommandType.StoredProcedure);
                person1.ID = p.Get<int>("@id");
                return person1;

            }
        }

        //1000- this class must prize model wire up
        public PrizeModel CreatePrize(PrizeModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournement")))
            {
                var p = new DynamicParameters();
                p.Add("@PlaceNumber", model.PlaceNumber);
                p.Add("@PlaceName", model.PlaceName);
                p.Add("@PrizePercentage", model.PrizePercentage);
                p.Add("@PrizeAmount", model.PrizeAmount);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spPrizeModel_Insert", p, commandType: CommandType.StoredProcedure);
                model.Id = p.Get<int>("@id");
                return model;
            }
        }

        public TeamModel CreateTeam(TeamModel team1)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournement")))
            {
                var p = new DynamicParameters();
                p.Add("@TeamName", team1.TeamName);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spTeam_Insert", p, commandType: CommandType.StoredProcedure);
                team1.Id = p.Get<int>("@id");
                foreach (PersonModel tm in team1.TeamMember)
                {
                    p = new DynamicParameters();
                    p.Add("@TeamId", team1.Id);
                    p.Add("@PersonId", tm.ID);
                    connection.Execute("dbo.spTeamMember_Insert", p, commandType: CommandType.StoredProcedure);

                }
            }
            return team1;
        }

        public TournementModel CreateTournement(TournementModel Tournement1)
        {
            saveTournement(Tournement1);
            savePrizeTournement(Tournement1);
            saveTeamTournement(Tournement1);
            saveRounds(Tournement1);
            return Tournement1;
        }
        private void saveTournement(TournementModel Tournement1)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournement")))
            {
                var p = new DynamicParameters();
                p.Add("@TournementName", Tournement1.TournementName);
                p.Add("@TournementFee", Tournement1.TournementFee);
                p.Add("@TournementId", 0, DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spTournement_Insert", p, commandType: CommandType.StoredProcedure);
                Tournement1.Id = p.Get<int>("@TournementId");

            }
        }
        private void savePrizeTournement(TournementModel Tournement1)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournement")))
            {
                foreach (PrizeModel item in Tournement1.Prizes)
                {
                    var p = new DynamicParameters();
                    p.Add("@TournementId", Tournement1.Id);
                    p.Add("PrizeId", item.Id);
                    p.Add("@id", 0, DbType.Int32, direction: ParameterDirection.Output);
                    connection.Execute("dbo.spTournementPrizeList_Insert", p, commandType: CommandType.StoredProcedure);
                    item.Id = p.Get<int>("@id");
                }
            }
        }
        private void saveTeamTournement(TournementModel Tournement1)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournement")))
            {
                foreach (TeamModel item in Tournement1.EntryTeams)
                {
                    var p = new DynamicParameters();
                    p.Add("@TournementId", Tournement1.Id);
                    p.Add("TeamId", item.Id);
                    p.Add("@id", 0, DbType.Int32, direction: ParameterDirection.Output);
                    connection.Execute("dbo.spTournementTeamList_Insert", p, commandType: CommandType.StoredProcedure);
                    //item.Id = p.Get<int>("@id");
                }
            }
        }
        private void saveRounds(TournementModel Tournement1)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournement")))
            {
                foreach (List<MatchupModel> Round in Tournement1.Rounds)
                {
                    foreach (MatchupModel  MatchUp in Round)
                    {
                        var p = new DynamicParameters();
                        if (MatchUp.Winner == null)
                        {
                            p.Add("@WinnerId", null);
                        }
                        else
                            p.Add("@WinnerId", MatchUp.Winner.Id);
                        p.Add("@MatchupRound", MatchUp.MatchupRound);
                        p.Add("@TournementId", Tournement1.Id);
                        p.Add("@id", 0, DbType.Int32, direction: ParameterDirection.Output);
                        connection.Execute("dbo.spMatchUps_Insert", p, commandType: CommandType.StoredProcedure);
                        MatchUp.ID = p.Get<int>("@id");

                        foreach (MatchupEntryModel item in MatchUp.Entries)
                        {
                            p = new DynamicParameters();
                            if (item.ParentMatchup == null)
                            {
                                p.Add("@ParentMatchUpId", null);

                            }
                            else
                                p.Add("@ParentMatchUpId", item.ParentMatchup.ID);
                            if (item.TeamCompeting == null)
                            {
                                p.Add("@TeamCompetingId", null);

                            }
                            else
                                p.Add("@TeamCompetingId", item.TeamCompeting.Id);
                            p.Add("@Score", item.Score);
                            p.Add("@MatchUpId", MatchUp.ID);
                            p.Add("@id", 0, DbType.Int32, direction: ParameterDirection.Output);
                            connection.Execute("dbo.spMatchUpEntries_Insert", p, commandType: CommandType.StoredProcedure);
                            item.ID = p.Get<int>("@id");

                        }
                    }
                }

            }
        }
        public void UpdateMatchUp(MatchupModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournement")))
            {
                var p = new DynamicParameters();
                p.Add("@id", model.ID);
                p.Add("@WinnerId", model.WinnerId);
                connection.Execute("dbo.spMatchUps2_Update", p, commandType: CommandType.StoredProcedure);
                foreach (MatchupEntryModel matchupEntryModel in model.Entries)
                {
                    p = new DynamicParameters();
                    p.Add("@id", matchupEntryModel.ID);
                    p.Add("@TeamCompetingId", matchupEntryModel.TeamCompetingId);
                    p.Add("@Score", matchupEntryModel.Score);
                    connection.Execute("dbo.spMatchUpEntries2_Update", p, commandType: CommandType.StoredProcedure);
                }

            }
        }


        #endregion

        #region Get_Alls
        public List<PersonModel> Get_All()
        {
            List<PersonModel> output = new List<PersonModel>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournement")))
            {
                output = connection.Query<PersonModel>("dbo.spPeople_GetAll").ToList();

            }

            return output;
        }

        public List<PrizeModel> Get_All_Prizes()
        {
            List<PrizeModel> output = new List<PrizeModel>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournement")))
            {
                output = connection.Query<PrizeModel>("dbo.spGetAll_Prizes").ToList();
            }
            return output;
        }
        public List<TeamModel> Get_All_Teams()
        {
            List<TeamModel> output = new List<TeamModel>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournement")))
            {
                output = connection.Query<TeamModel>("dbo.spTeam_GetAll ").ToList();
                foreach (TeamModel item in output)
                {
                    var p = new DynamicParameters();
                    p.Add("@TeamId", item.Id);
                    item.TeamMember = connection.Query<PersonModel>("dbo.spGetAllMember_MemberTeam", p, commandType: CommandType.StoredProcedure).ToList();

                }
            }
            return output;

        }

        public List<TournementModel> Get_All_Tournements()
        {
            
            List<TournementModel> output = new List<TournementModel>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournement")))
            {
                output = connection.Query<TournementModel>("spTournementModel_GetAll").ToList();
                foreach (TournementModel tournementModel in output)
                {
                    var p = new DynamicParameters();
                    p.Add("@TournementId", tournementModel.Id);
                    tournementModel.Prizes = connection.Query<PrizeModel>("dbo.spTournementPrizeList_GetAll", p, commandType: CommandType.StoredProcedure).ToList();
                    tournementModel.EntryTeams = connection.Query<TeamModel>("dbo.spTournementTeamList_GetAll", p, commandType: CommandType.StoredProcedure).ToList();
                    foreach (TeamModel teamModel in tournementModel.EntryTeams)
                    {
                        var t = new DynamicParameters();
                        t.Add("@TeamId", teamModel.Id);
                        teamModel.TeamMember = connection.Query<PersonModel>("dbo.spGetAllMember_MemberTeam", t, commandType: CommandType.StoredProcedure).ToList();

                    }
                    List<MatchupModel> matchupModels = connection.Query<MatchupModel>("dbo.spTournementMatchUpsList_GetAll", p, commandType: CommandType.StoredProcedure).ToList();
                    List<TeamModel> teams = Get_All_Teams();

                    foreach (MatchupModel matchup in matchupModels)
                    {
                        var t = new DynamicParameters();
                        t.Add("@MatchUpId", matchup.ID);
                        matchup.Entries = connection.Query<MatchupEntryModel>("dbo.spTournementMatchUpEntriesList_GetAll", t, commandType: CommandType.StoredProcedure).ToList();
                        if (matchup.WinnerId > 0)
                            matchup.Winner = teams.Where(x => x.Id == matchup.WinnerId).First();

                        foreach (MatchupEntryModel matchupEntryModel in matchup.Entries)
                        {
                            if (matchupEntryModel.TeamCompetingId > 0)
                                matchupEntryModel.TeamCompeting = teams.Where(x => x.Id == matchupEntryModel.TeamCompetingId).FirstOrDefault();
                            if (matchupEntryModel.ParentMatchUpId > 0)
                                matchupEntryModel.ParentMatchup = matchupModels.Where(x => x.ID == matchupEntryModel.ParentMatchUpId).FirstOrDefault();

                        }
                    }
                    int countofTeams = matchupModels.Count + 1;
                    int countOfRound = 0;
                    while (countofTeams != 1)
                    {
                        countOfRound++;
                        countofTeams = countofTeams / 2;
                    }
                    for (int i = 1; i <= countOfRound; i++)
                    {
                        List<MatchupModel> round = new List<MatchupModel>();
                        foreach (MatchupModel matchup in matchupModels)
                        {
                            if (matchup.MatchupRound == i)
                                round.Add(matchup);
                        }
                        tournementModel.Rounds.Add(round);
                    }

                }
                return output;
            }
        }

        public void CompleteTournement(TournementModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournement")))
            {
                var p = new DynamicParameters();
                p.Add("@id", model.Id);
                connection.Execute("dbo.spTournementModel2_Complete", p, commandType: CommandType.StoredProcedure);
            }

        }


        #endregion
    }
}
