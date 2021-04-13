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
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTournementForm : Form,IPrizeRequester,ITeamRequester
    {
        //Requirements
        private List<TeamModel> availableTeams = GlobalConfig.Connection.Get_All_Teams();
        private List<TeamModel> SelectedTeams = new List<TeamModel>();
        private List<PrizeModel> selectedPrizes = GlobalConfig.Connection.Get_All_Prizes();
        private ITournementRequester caller;
        public CreateTournementForm(ITournementRequester calling)
        {
            caller = calling;
            InitializeComponent();
            WireUp();
        }      
        public  void WireUp()
        {
           selectTeamDown.DataSource = null;
           selectTeamDown.DataSource = availableTeams;
           selectTeamDown.DisplayMember = "TeamName";
           TournementPlayersListBox.DataSource = null;
           TournementPlayersListBox.DataSource = SelectedTeams;
           TournementPlayersListBox.DisplayMember = "ShowData";
           PrizesListBox.DataSource = null;
           PrizesListBox.DataSource = selectedPrizes;
           PrizesListBox.DisplayMember = "PrizeShow";
          
        }
        
        // EventHandlers
        private void addTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel temp = new TeamModel();
            temp =( TeamModel)selectTeamDown.SelectedItem;
            if (temp != null)
            {
                availableTeams.Remove(temp);
                SelectedTeams.Add(temp);
            }
            WireUp();
        }

        private void deleteSelectedTeamPlayerButton_Click(object sender, EventArgs e)
        {
            TeamModel temp = new TeamModel();
            temp = (TeamModel)TournementPlayersListBox.SelectedItem;

            if (temp!=null)
            {
                availableTeams.Add(temp);
                SelectedTeams.Remove(temp); 
            }
            WireUp();
        }

        private void deleteSelectedPrizeButton_Click(object sender, EventArgs e)
        {
            PrizeModel tmp = new PrizeModel();
            if (selectedPrizes != null)
            {
                tmp = (PrizeModel)PrizesListBox.SelectedItem;
                selectedPrizes.Remove(tmp);
                WireUp();
            }
        }

        private void createTournementButton_Click(object sender, EventArgs e)
        {


            bool Istrue = decimal.TryParse(entryFeeText.Text, out decimal checker);
            if (Istrue==false)
                {
                    MessageBox.Show("Your entity is not valid try it again", "validation", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
         
                }


            if (Istrue)
            {
                TournementModel Tm = new TournementModel();
                Tm.TournementName = tournementNameText.Text;
                Tm.TournementFee = decimal.Parse(entryFeeText.Text);
                Tm.Prizes = selectedPrizes;
                Tm.EntryTeams = SelectedTeams;
                CreateRounds.ConfigurationRounds(Tm);
                GlobalConfig.Connection.CreateTournement(Tm);
                caller.completeTournement(Tm);
                this.Close();
            }


        }
        
        private void createNewLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Application.Run(new Create_Team());
            Create_Team p = new Create_Team(this);
            p.Show();
            
            
          
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            Create_Prize p = new Create_Prize(this);
            p.Show();
            WireUp();
            
        }
        public void ComplePrize(PrizeModel model)
        {
            selectedPrizes.Add(model);
            WireUp();
        }

        public void CompleteTeam(TeamModel model)
        {
            availableTeams.Add(model);
            WireUp();
        }

       
    }
}
