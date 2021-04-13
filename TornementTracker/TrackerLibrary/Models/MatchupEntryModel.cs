using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
   public class MatchupEntryModel
    {
        public int ID { get; set; }
        /// <summary>
        /// this is for matchupentry class(teamcompeting)
        /// </summary>
        public TeamModel TeamCompeting { get; set; }
        /// <summary>
        /// this can show score of one match up both in email or text file
        /// </summary>
        public double? Score { get; set; }
        /// <summary>
        /// this can back of which team this result came from
        /// </summary>
        public MatchupModel ParentMatchup { get; set; } = new MatchupModel();
        /// <summary>
        /// this unique id for sql finder of team
        /// </summary>
        public int TeamCompetingId { get; set; }
        /// <summary>
        /// this unique id for sql finder of matchup
        /// </summary>
        public int ParentMatchUpId { get; set; }
    }
}
