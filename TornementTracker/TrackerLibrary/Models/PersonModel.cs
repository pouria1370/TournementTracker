using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
   public class PersonModel
    {
        public int ID { get; set; }
        /// <summary>
        /// what is first name of ur perosn or member?
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// what is last name of ur perosn or member?
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// what is email adress of ur perosn or member?
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// what is cellphonenumber of ur perosn or member?
        /// </summary>

        public string FullName
        { get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public string CellPhoneNumber { get; set; }
        public PersonModel()
        {
                
        }
        public PersonModel(string firstname,string lastname,string email,string cellphone)
        {
            FirstName = firstname;
            LastName = lastname;
            CellPhoneNumber = cellphone;
            EmailAddress = email;
        }

    }
}
