using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
   public class TeamModel
    {
        public int Id { get; set; }
        /// <summary>
        /// this is a list of all memeber for forming one team
        /// </summary>
        public List<PersonModel> TeamMember { get; set; } = new List<PersonModel>();
        /// <summary>
        /// this is a title of a team
        /// </summary>
        public string TeamName { get; set; }
        /// <summary>
        /// this property is just for showing in databox
        /// </summary>
        public string ShowData
        {
            get
            {
                return $"{TeamName} :" + give_NameMemeber();
            }
        }
        private string give_NameMemeber()
        {
            string output = string.Empty;
            foreach (PersonModel item in this.TeamMember)
            {
                output += $"{item.FullName}|";

            }

            output=output.Substring(0, output.Length - 1);
            return output;
        }
    }
}
