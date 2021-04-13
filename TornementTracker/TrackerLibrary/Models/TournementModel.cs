using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
   public class TournementModel
    {
        /// <summary>
        /// we need an event for closing
        /// </summary>
        public event EventHandler< DateTime> onTournementComplete;

        public int Id { get; set; }
        /// <summary>
        /// this is a name of the tornement
        /// </summary>
        public string TournementName { get; set; }
        /// <summary>
        /// this is fee of tournement
        /// </summary>
        public decimal TournementFee { get; set; }
        /// <summary>
        /// this is list of all team for formin one tournement
        /// </summary>
        public List<TeamModel> EntryTeams { get; set; } = new List<TeamModel>();
        /// <summary>
        /// this is list of all prizes for this tournement
        /// </summary>
        public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();
        /// <summary>
        /// this is one sid or group of all machtups that we name it list<list<matchups>>
        /// </summary>
        public List<List<MatchupModel>> Rounds { get; set; } = new List<List<MatchupModel>>();
        public void CompleteTournement()
        {
            onTournementComplete?.Invoke(this,DateTime.Now);
        }
    }
}
