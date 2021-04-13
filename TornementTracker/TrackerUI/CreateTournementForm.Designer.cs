namespace TrackerUI
{
    partial class CreateTournementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.createTournementLabel = new System.Windows.Forms.Label();
            this.tournementNameLabel = new System.Windows.Forms.Label();
            this.tournementNameText = new System.Windows.Forms.TextBox();
            this.entryFeeText = new System.Windows.Forms.TextBox();
            this.entryFeeLabel = new System.Windows.Forms.Label();
            this.selectTeamLabel = new System.Windows.Forms.Label();
            this.selectTeamDown = new System.Windows.Forms.ComboBox();
            this.createNewLink = new System.Windows.Forms.LinkLabel();
            this.createPrizeButton = new System.Windows.Forms.Button();
            this.addTeamButton = new System.Windows.Forms.Button();
            this.createTournementButton = new System.Windows.Forms.Button();
            this.TournementPlayersListBox = new System.Windows.Forms.ListBox();
            this.teamPlayersLabel = new System.Windows.Forms.Label();
            this.deleteSelectedTeamPlayerButton = new System.Windows.Forms.Button();
            this.deleteSelectedPrizeButton = new System.Windows.Forms.Button();
            this.PrizesLabel = new System.Windows.Forms.Label();
            this.PrizesListBox = new System.Windows.Forms.ListBox();
            this.teamModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.teamModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // createTournementLabel
            // 
            this.createTournementLabel.AutoSize = true;
            this.createTournementLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createTournementLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.createTournementLabel.Location = new System.Drawing.Point(12, 9);
            this.createTournementLabel.Name = "createTournementLabel";
            this.createTournementLabel.Size = new System.Drawing.Size(173, 25);
            this.createTournementLabel.TabIndex = 1;
            this.createTournementLabel.Text = "Create Tournement";
            // 
            // tournementNameLabel
            // 
            this.tournementNameLabel.AutoSize = true;
            this.tournementNameLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tournementNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.tournementNameLabel.Location = new System.Drawing.Point(12, 57);
            this.tournementNameLabel.Name = "tournementNameLabel";
            this.tournementNameLabel.Size = new System.Drawing.Size(173, 25);
            this.tournementNameLabel.TabIndex = 2;
            this.tournementNameLabel.Text = " Tournement Name";
            // 
            // tournementNameText
            // 
            this.tournementNameText.Location = new System.Drawing.Point(17, 85);
            this.tournementNameText.Name = "tournementNameText";
            this.tournementNameText.Size = new System.Drawing.Size(168, 35);
            this.tournementNameText.TabIndex = 10;
            // 
            // entryFeeText
            // 
            this.entryFeeText.Location = new System.Drawing.Point(96, 146);
            this.entryFeeText.Name = "entryFeeText";
            this.entryFeeText.Size = new System.Drawing.Size(59, 35);
            this.entryFeeText.TabIndex = 12;
        
            // 
            // entryFeeLabel
            // 
            this.entryFeeLabel.AutoSize = true;
            this.entryFeeLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entryFeeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.entryFeeLabel.Location = new System.Drawing.Point(12, 153);
            this.entryFeeLabel.Name = "entryFeeLabel";
            this.entryFeeLabel.Size = new System.Drawing.Size(89, 25);
            this.entryFeeLabel.TabIndex = 11;
            this.entryFeeLabel.Text = "Entry Fee";
            // 
            // selectTeamLabel
            // 
            this.selectTeamLabel.AutoSize = true;
            this.selectTeamLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectTeamLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.selectTeamLabel.Location = new System.Drawing.Point(7, 245);
            this.selectTeamLabel.Name = "selectTeamLabel";
            this.selectTeamLabel.Size = new System.Drawing.Size(116, 25);
            this.selectTeamLabel.TabIndex = 13;
            this.selectTeamLabel.Text = " Select Team";
            // 
            // selectTeamDown
            // 
            this.selectTeamDown.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectTeamDown.FormattingEnabled = true;
            this.selectTeamDown.ItemHeight = 21;
            this.selectTeamDown.Location = new System.Drawing.Point(12, 273);
            this.selectTeamDown.Name = "selectTeamDown";
            this.selectTeamDown.Size = new System.Drawing.Size(168, 29);
            this.selectTeamDown.Sorted = true;
            this.selectTeamDown.TabIndex = 14;
            // 
            // createNewLink
            // 
            this.createNewLink.AutoSize = true;
            this.createNewLink.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createNewLink.Location = new System.Drawing.Point(125, 246);
            this.createNewLink.Name = "createNewLink";
            this.createNewLink.Size = new System.Drawing.Size(91, 21);
            this.createNewLink.TabIndex = 15;
            this.createNewLink.TabStop = true;
            this.createNewLink.Text = "Create New";
            this.createNewLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.createNewLink_LinkClicked);
            // 
            // createPrizeButton
            // 
            this.createPrizeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.createPrizeButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.createPrizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.createPrizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(22)))), ((int)(((byte)(242)))));
            this.createPrizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createPrizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.createPrizeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.createPrizeButton.Location = new System.Drawing.Point(48, 388);
            this.createPrizeButton.Name = "createPrizeButton";
            this.createPrizeButton.Size = new System.Drawing.Size(107, 23);
            this.createPrizeButton.TabIndex = 16;
            this.createPrizeButton.Text = "Create Prize";
            this.createPrizeButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.createPrizeButton.UseVisualStyleBackColor = true;
            this.createPrizeButton.Click += new System.EventHandler(this.createPrizeButton_Click);
            // 
            // addTeamButton
            // 
            this.addTeamButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.addTeamButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.addTeamButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.addTeamButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(22)))), ((int)(((byte)(242)))));
            this.addTeamButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTeamButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.addTeamButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.addTeamButton.Location = new System.Drawing.Point(48, 320);
            this.addTeamButton.Name = "addTeamButton";
            this.addTeamButton.Size = new System.Drawing.Size(107, 23);
            this.addTeamButton.TabIndex = 17;
            this.addTeamButton.Text = "Add Team";
            this.addTeamButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.addTeamButton.UseVisualStyleBackColor = true;
            this.addTeamButton.Click += new System.EventHandler(this.addTeamButton_Click);
            // 
            // createTournementButton
            // 
            this.createTournementButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.createTournementButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.createTournementButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.createTournementButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(22)))), ((int)(((byte)(242)))));
            this.createTournementButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createTournementButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.createTournementButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.createTournementButton.Location = new System.Drawing.Point(228, 421);
            this.createTournementButton.Name = "createTournementButton";
            this.createTournementButton.Size = new System.Drawing.Size(135, 23);
            this.createTournementButton.TabIndex = 18;
            this.createTournementButton.Text = "Cretae Tournement";
            this.createTournementButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.createTournementButton.UseVisualStyleBackColor = true;
            this.createTournementButton.Click += new System.EventHandler(this.createTournementButton_Click);
            // 
            // TournementPlayersListBox
            // 
            this.TournementPlayersListBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TournementPlayersListBox.FormattingEnabled = true;
            this.TournementPlayersListBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TournementPlayersListBox.Location = new System.Drawing.Point(237, 85);
            this.TournementPlayersListBox.Name = "TournementPlayersListBox";
            this.TournementPlayersListBox.ScrollAlwaysVisible = true;
            this.TournementPlayersListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.TournementPlayersListBox.Size = new System.Drawing.Size(266, 121);
            this.TournementPlayersListBox.TabIndex = 19;
            // 
            // teamPlayersLabel
            // 
            this.teamPlayersLabel.AutoSize = true;
            this.teamPlayersLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamPlayersLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.teamPlayersLabel.Location = new System.Drawing.Point(232, 57);
            this.teamPlayersLabel.Name = "teamPlayersLabel";
            this.teamPlayersLabel.Size = new System.Drawing.Size(131, 25);
            this.teamPlayersLabel.TabIndex = 20;
            this.teamPlayersLabel.Text = "Teams/Players";
            // 
            // deleteSelectedTeamPlayerButton
            // 
            this.deleteSelectedTeamPlayerButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.deleteSelectedTeamPlayerButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.deleteSelectedTeamPlayerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.deleteSelectedTeamPlayerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(22)))), ((int)(((byte)(242)))));
            this.deleteSelectedTeamPlayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteSelectedTeamPlayerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.deleteSelectedTeamPlayerButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.deleteSelectedTeamPlayerButton.Location = new System.Drawing.Point(518, 125);
            this.deleteSelectedTeamPlayerButton.Name = "deleteSelectedTeamPlayerButton";
            this.deleteSelectedTeamPlayerButton.Size = new System.Drawing.Size(90, 53);
            this.deleteSelectedTeamPlayerButton.TabIndex = 21;
            this.deleteSelectedTeamPlayerButton.Text = "Delete Selected Team/Player";
            this.deleteSelectedTeamPlayerButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.deleteSelectedTeamPlayerButton.UseVisualStyleBackColor = true;
            this.deleteSelectedTeamPlayerButton.Click += new System.EventHandler(this.deleteSelectedTeamPlayerButton_Click);
            // 
            // deleteSelectedPrizeButton
            // 
            this.deleteSelectedPrizeButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.deleteSelectedPrizeButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.deleteSelectedPrizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.deleteSelectedPrizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(22)))), ((int)(((byte)(242)))));
            this.deleteSelectedPrizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteSelectedPrizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.deleteSelectedPrizeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.deleteSelectedPrizeButton.Location = new System.Drawing.Point(518, 306);
            this.deleteSelectedPrizeButton.Name = "deleteSelectedPrizeButton";
            this.deleteSelectedPrizeButton.Size = new System.Drawing.Size(90, 37);
            this.deleteSelectedPrizeButton.TabIndex = 24;
            this.deleteSelectedPrizeButton.Text = "Delete Selected Prize";
            this.deleteSelectedPrizeButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.deleteSelectedPrizeButton.UseVisualStyleBackColor = true;
            this.deleteSelectedPrizeButton.Click += new System.EventHandler(this.deleteSelectedPrizeButton_Click);
            // 
            // PrizesLabel
            // 
            this.PrizesLabel.AutoSize = true;
            this.PrizesLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrizesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.PrizesLabel.Location = new System.Drawing.Point(232, 245);
            this.PrizesLabel.Name = "PrizesLabel";
            this.PrizesLabel.Size = new System.Drawing.Size(62, 25);
            this.PrizesLabel.TabIndex = 23;
            this.PrizesLabel.Text = "Prizes";
            // 
            // PrizesListBox
            // 
            this.PrizesListBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrizesListBox.FormattingEnabled = true;
            this.PrizesListBox.Location = new System.Drawing.Point(237, 273);
            this.PrizesListBox.Name = "PrizesListBox";
            this.PrizesListBox.Size = new System.Drawing.Size(266, 108);
            this.PrizesListBox.Sorted = true;
            this.PrizesListBox.TabIndex = 19;
            // 
            // teamModelBindingSource
            // 
            this.teamModelBindingSource.DataSource = typeof(TrackerLibrary.Models.TeamModel);
            // 
            // CreateTournementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(625, 446);
            this.Controls.Add(this.deleteSelectedPrizeButton);
            this.Controls.Add(this.PrizesLabel);
            this.Controls.Add(this.PrizesListBox);
            this.Controls.Add(this.deleteSelectedTeamPlayerButton);
            this.Controls.Add(this.teamPlayersLabel);
            this.Controls.Add(this.TournementPlayersListBox);
            this.Controls.Add(this.createTournementButton);
            this.Controls.Add(this.addTeamButton);
            this.Controls.Add(this.createPrizeButton);
            this.Controls.Add(this.createNewLink);
            this.Controls.Add(this.selectTeamDown);
            this.Controls.Add(this.selectTeamLabel);
            this.Controls.Add(this.entryFeeText);
            this.Controls.Add(this.entryFeeLabel);
            this.Controls.Add(this.tournementNameText);
            this.Controls.Add(this.tournementNameLabel);
            this.Controls.Add(this.createTournementLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "CreateTournementForm";
            this.Text = "CreateTournementForm";
            ((System.ComponentModel.ISupportInitialize)(this.teamModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label createTournementLabel;
        private System.Windows.Forms.Label tournementNameLabel;
        private System.Windows.Forms.TextBox tournementNameText;
        private System.Windows.Forms.TextBox entryFeeText;
        private System.Windows.Forms.Label entryFeeLabel;
        private System.Windows.Forms.Label selectTeamLabel;
        private System.Windows.Forms.ComboBox selectTeamDown;
        private System.Windows.Forms.LinkLabel createNewLink;
        private System.Windows.Forms.Button createPrizeButton;
        private System.Windows.Forms.Button addTeamButton;
        private System.Windows.Forms.Button createTournementButton;
        private System.Windows.Forms.ListBox TournementPlayersListBox;
        private System.Windows.Forms.Label teamPlayersLabel;
        private System.Windows.Forms.Button deleteSelectedTeamPlayerButton;
        private System.Windows.Forms.Button deleteSelectedPrizeButton;
        private System.Windows.Forms.Label PrizesLabel;
        private System.Windows.Forms.ListBox PrizesListBox;
        private System.Windows.Forms.BindingSource teamModelBindingSource;
    }
}