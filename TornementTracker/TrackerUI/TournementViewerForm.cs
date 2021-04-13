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
    public partial class TournementDashForm : Form
    {
        private TournementModel tournement;
        BindingList<int> roundNumbers = new BindingList<int>();
        BindingList<MatchupModel> selectedmatchups = new BindingList<MatchupModel>();

        public TournementDashForm(TournementModel tm)
        {
            InitializeComponent();
            tournement = tm;
            tm.onTournementComplete += Tm_onTournementComplete;
            WireUpList();
            LoadRound();
            LoadUp();
        }

        private void Tm_onTournementComplete(object sender, DateTime e)
        {
            this.Close();
        }

        public void LoadUp()
        {
            tournementName.Text = tournement.TournementName;          
        }
        private void roundDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchUps((int)roundDropDown.SelectedItem);
        }
        private void matchupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            LoadMatchScore((MatchupModel)matchupListBox.SelectedItem);
        }
        private void LoadMatchScore(MatchupModel item)
        {

            if (item!=null)
            {
                for (int i = 0; i < item.Entries.Count; i++)
                {
                    if (i == 0)
                    {
                        if (item.Entries[i].TeamCompeting != null)
                        {
                            teamOneName.Text = item.Entries[i].TeamCompeting.TeamName;
                            teamOneScoreText.Text = item.Entries[i].Score.ToString();
                            teamTwoName.Text = "Bot";
                            teamTwoScoreText.Text = "0";
                        }
                        else
                        {
                            teamOneName.Text = "Not Set";
                            teamOneScoreText.Text = "0";
                        }

                    }
                    if (i == 1)
                    {
                        if (item.Entries[i].TeamCompeting != null)
                        {
                            teamTwoName.Text = item.Entries[i].TeamCompeting.TeamName;
                            teamTwoScoreText.Text = item.Entries[i].Score.ToString();

                        }
                        else
                        {
                            teamTwoName.Text = "Not Set";
                            teamTwoScoreText.Text = "0";
                        }

                    }
                } 
            }

        }
        private void LoadRound()
        {


            //ToDo 1:we need first all rounds for Round place grab 
            roundNumbers.Clear();
            int roundnumber = 0;
            foreach (List<MatchupModel> item in tournement.Rounds)
            {
                roundnumber++;
                roundNumbers.Add(roundnumber);
                
            }
            LoadMatchUps(1);
           // WireUpRoundsList();
        }
        private void LoadMatchUps(int round)
        {
            //int round = (int)roundDropDown.SelectedItem;
            foreach (List<MatchupModel> item in tournement.Rounds)
            {
                if (item.First().MatchupRound == round)
                {
                    selectedmatchups.Clear();
                    foreach (var matchup in item)
                    {
                        if (!unplayedCheckBox.Checked||matchup.Winner==null)
                        {
                            selectedmatchups.Add(matchup);

                        };
                    }
                }
            }
            
            if (selectedmatchups.Count>0)
            {
                LoadMatchScore(selectedmatchups.First()); 
            }
            displayMatchupInfo();
        }
        private void WireUpList()
        {
            roundDropDown.DataSource = roundNumbers;
            matchupListBox.DataSource = selectedmatchups;
            matchupListBox.DisplayMember = "matchupToString";
        }
        private void displayMatchupInfo()
        {
            bool display = selectedmatchups.Count > 0;
            teamOneName.Visible = display;
            scoreLabelTeamOne.Visible = display;
            teamOneScoreText.Visible = display;
            versusLabel.Visible = display;
            teamTwoName.Visible = display;
            scoreLabelTeamTwo.Visible = display;
            teamTwoScoreText.Visible = display;
            scoreButton.Visible = display;
        }


        private void TournementViewerForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void unplayedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LoadMatchUps((int)roundDropDown.SelectedItem);

        }
        private string isValid()
        {
            string output="";
            double ScorValueTeam1 = 0;
            double ScorValueTeam2 = 0;
            bool ScorValueTeam2bool = double.TryParse(teamTwoScoreText.Text, out ScorValueTeam2);
            bool ScorValueTeam1bool = double.TryParse(teamOneScoreText.Text, out ScorValueTeam1);
            if (!ScorValueTeam2bool)
                output = "Team Two Score is not valid";
            else if (!ScorValueTeam1bool)
                output = "Team One Score is not valid";
            else if (ScorValueTeam1 == 0 && ScorValueTeam2 == 0)
                output = "You have not entered right integer";

            else if (ScorValueTeam1 < 0 || ScorValueTeam2 < 0)
                output = "Score can not be negative.";
            return output;
        }
        private void scoreButton_Click(object sender, EventArgs e)
        {
            string output = isValid();

            if (output.Length>0)
            {
                MessageBox.Show($"{output}");
                return;
            }
            MatchupModel item = (MatchupModel)matchupListBox.SelectedItem;
            double ScorValueTeam1 = 0;
            double ScorValueTeam2 = 0;
            for (int i = 0; i < item.Entries.Count; i++)
            {
               
                if (i == 0)
                {
                    if (item.Entries[i].TeamCompeting!=null)
                    {
                        bool ScorValueTeam1bool = double.TryParse(teamOneScoreText.Text, out ScorValueTeam1);

                        if (ScorValueTeam1bool)
                        {
                            item.Entries[i].Score = ScorValueTeam1;
                        }
                        else
                        {
                            MessageBox.Show("your entity is not valid");
                            return;
                        } 
                    }
                }
                if (i == 1)
                {
                    if (item.Entries[i].TeamCompeting!=null)
                    {
                        bool ScorValueTeam2bool = double.TryParse(teamTwoScoreText.Text, out ScorValueTeam2);

                        if (ScorValueTeam2bool)
                        {
                            item.Entries[i].Score = ScorValueTeam2;
                        }
                        else
                        {
                            MessageBox.Show("your entity is not valid");
                            return;
                        } 
                    }
                }

            }

            LoadMatchUps((int)roundDropDown.SelectedItem);
            try
            {
                CreateRounds.UpdateTournementResult(tournement);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"{ex.Message}");
            }
        }
    }
}
