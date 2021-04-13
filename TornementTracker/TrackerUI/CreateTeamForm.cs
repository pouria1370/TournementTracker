using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class Create_Team : Form
    {
        private List<PersonModel> availablePersonMembers = new List<PersonModel>();
        private List<PersonModel> selectedPersonMembers = new List<PersonModel>();
        private ITeamRequester calling;
        public Create_Team(ITeamRequester caller)
        {
            calling = caller;
            InitializeComponent();
            //createSampleData();
            loadListData();
            wireUp();
        }
        
        private void wireUp()
        {
            selectTeamMemberDown.DataSource = null;
            selectTeamMemberDown.DataSource = availablePersonMembers;
            selectTeamMemberDown.DisplayMember = "FullName";
            TournementPlayersBox.DataSource = null;
            TournementPlayersBox.DataSource = selectedPersonMembers;
            TournementPlayersBox.DisplayMember = "FullName";
        }
        
        private void loadListData()
        {
            availablePersonMembers = GlobalConfig.Connection.Get_All();
        }
        private void createMemberButton_Click(object sender, EventArgs e)
        {
             if (Validateform())
            {
                PersonModel model = new PersonModel(
                    firstNameText.Text, 
                    lastNameText.Text,
                    emailText.Text,
                    cellphoneText.Text
                    );

                GlobalConfig.Connection.CreatePerson(model);
                availablePersonMembers.Add(model);
                wireUp();
                MessageBox.Show("You Persondata is now saved in Databases.");
                firstNameText.Text= "";
                lastNameText.Text = "";
                emailText.Text="";
                cellphoneText.Text = "";
            }
            else
            {
                MessageBox.Show("This form in Person_entiry has invalid input.Please correct it.");
            }

            
        }
        private bool Validateform()
        {
            bool output = true;

            return output;
        }

        private void TournementPlayersBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)selectTeamMemberDown.SelectedItem;

            if (p!=null)
            {
                availablePersonMembers.Remove(p);
                selectedPersonMembers.Add(p);
                wireUp(); 
            }
           
        }

        private void RemoveSelectedButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)TournementPlayersBox.SelectedItem;
            if (p!=null)
            {
                selectedPersonMembers.Remove(p);
                availablePersonMembers.Add(p);
                wireUp(); 
            }
        }
        
        private void createTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel t = new TeamModel();
            t.TeamName = teamNameText.Text;
            t.TeamMember = selectedPersonMembers;
            GlobalConfig.Connection.CreateTeam(t);
            //this creation team form must been closed,otherwise it must been reset.
            MessageBox.Show("Your Data saved Successfully");
            calling.CompleteTeam(t);
            //teamNameText.Text = "";
            //selectedPersonMembers = null;
            //selectedPersonMembers = new List<PersonModel>();
            //TournementPlayersBox.DataSource = selectedPersonMembers;
            this.Close();
            
        }

    }
}
