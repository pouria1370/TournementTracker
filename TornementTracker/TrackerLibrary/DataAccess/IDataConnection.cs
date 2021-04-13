using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;


namespace TrackerLibrary.DataAccess
{
    public interface IDataConnection
    {
        PrizeModel CreatePrize(PrizeModel model);
        PersonModel CreatePerson(PersonModel person1);
        TeamModel CreateTeam(TeamModel team1);
        TournementModel CreateTournement(TournementModel Tournement1);
        void UpdateMatchUp(MatchupModel model);
        void CompleteTournement(TournementModel model);
        List<PersonModel> Get_All();
        List<TeamModel> Get_All_Teams();
        List<PrizeModel> Get_All_Prizes();
        List<TournementModel> Get_All_Tournements();

    }
}
