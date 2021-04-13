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
    public partial class TournementDashboardForm : Form, ITournementRequester
    {
        List<TournementModel> availableTournements = GlobalConfig.Connection.Get_All_Tournements();
        public TournementDashboardForm()
        {
            InitializeComponent();
            WireUp();
        }
        public void WireUp()
        {
            TournementDashBoardDown.DataSource = null;
            TournementDashBoardDown.DataSource = availableTournements;
            TournementDashBoardDown.DisplayMember = "TournementName";
        }
        private void TournementDashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void TournementDashBoardDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void createTournementButton_Click(object sender, EventArgs e)
        {
            CreateTournementForm frm = new CreateTournementForm(this);
            frm.Show();
            WireUp();
        }

        public void completeTournement(TournementModel newtournement)
        {
            availableTournements.Add(newtournement);
            WireUp();
        }

        private void loadTournementButton_Click(object sender, EventArgs e)
        {
            TournementModel tm = (TournementModel)TournementDashBoardDown.SelectedItem;
            TournementDashForm fm = new TournementDashForm(tm);
            fm.Show();
        }
    }
}
