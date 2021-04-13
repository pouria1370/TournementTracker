using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class PrizeModel
    {
        /// <summary>
        /// this is for assigning an id for any prize
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// this backs the rank of winner 
        /// </summary>
        public int PlaceNumber { get; set; }
        /// <summary>
        /// this backs the title of winner
        /// </summary>
        public string PlaceName { get; set; }
        /// <summary>
        /// this backs the amount of prize
        /// </summary>
        public decimal PrizeAmount { get; set; }
        /// <summary>
        /// this backs instead of amount the percentage of prize
        /// </summary>
        public double PrizePercentage { get; set; }
        /// <summary>
        /// this is for returning in event handler as prizes
        /// </summary>
        public string PrizeShow {
            get
            {
                return $"PlaceNumber:{PlaceNumber} PlaceName:{PlaceName} PrizeAmount:{PrizeAmount}/PrizePercentage:{PrizePercentage}";
            }
                }

        public PrizeModel()
        {

        }
        public PrizeModel(
            string placenumber,
            string placename,
            string prizeamount,
            string prizepercentage)
        {
            PlaceName = placename;
            PlaceNumber = int.Parse(placenumber);
            PrizeAmount = decimal.Parse(prizeamount);
            PrizePercentage = double.Parse(prizepercentage);
        }
    }
}
