using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class Create_Prize : Form
    {
        private IPrizeRequester calling;

        

        public Create_Prize(IPrizeRequester caller)
        {
            InitializeComponent();
            calling = caller;
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            if (Validateform())
            {
                PrizeModel model = new PrizeModel(
                    placeNumberText.Text, 
                    placeNameText.Text,
                    prizeAmountText.Text,
                    prizePercentageText.Text);

                GlobalConfig.Connection.CreatePrize(model);
                MessageBox.Show("You data is now saved in Databases.");
                //looseconnction with createTournemtn
                calling.ComplePrize(model);
                placeNumberText.Text = "";
                placeNameText.Text = "";
                prizeAmountText.Text="0";
                prizePercentageText.Text = "0";
            }
            else
            {
                MessageBox.Show("this form has invalid input.please correct it.");
            }
            this.Close();
        }

        private bool Validateform()
        {
            bool output = true;
            int PlaceNumber = 0;
            bool placenumberValidNumber = int.TryParse(placeNumberText.Text, out PlaceNumber);
            if (placenumberValidNumber==false)
            {
                output = false;
            }
            if(PlaceNumber<1)
            {
                output = false;
            }

            if(placeNameText.Text.Length==0)
            {
                output = false;
            }
            decimal prizeamount = 0;
            double prizePercentage = 0;
            bool prizeAmountValid = decimal.TryParse(prizeAmountText.Text, out prizeamount);
            bool prizePercentageValid = double.TryParse(prizePercentageText.Text, out prizePercentage);
            if(prizeAmountValid==false||prizePercentageValid==false)
            {
                output = false;
            }
            if(prizeamount<=0 && prizePercentage<=0)
            {
                output = false;
            }
            if(prizePercentage<0||prizePercentage>100)
            {
                output = false;
            }
            return output;
        }
    }
}
