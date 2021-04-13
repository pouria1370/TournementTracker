using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class MatchupModel
    {
        public int? ID { get; set; }
        /// <summary>
        /// all we need from this atribute is one list of team in a sid or group
        /// </summary>
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();
        /// <summary>
        /// this backs the winner team
        /// </summary>
        public TeamModel Winner { get; set; }
        /// <summary>
        /// this unique id for sql finder of winnerteam
        /// </summary>
        public int WinnerId { get; set; }
        /// <summary>
        /// this backs which round of this match up related to the this result
        /// </summary>
        public int MatchupRound { get; set; }
        public string matchupToString
        {
            get
            {
                string s = string.Empty;
                foreach (MatchupEntryModel item in this.Entries)
                {
                   if(item.TeamCompeting!=null)
                    {
                        if (s.Length == 0)
                            s = $"{item.TeamCompeting.TeamName}";
                        else
                            s += $" vs. {item.TeamCompeting.TeamName}";
                    }
                    else
                    {
                        s = "this matchup is not determined";
                    }
                }
               

                return s;
            }
 }
        public int TournementId { get; set; }
    }
}
