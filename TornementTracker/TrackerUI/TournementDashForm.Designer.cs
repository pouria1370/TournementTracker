namespace TrackerUI
{
    partial class TournementDashboardForm
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
            this.LoadExistingTournemetLabel = new System.Windows.Forms.Label();
            this.TournementDashLabel = new System.Windows.Forms.Label();
            this.TournementDashBoardDown = new System.Windows.Forms.ComboBox();
            this.loadTournementButton = new System.Windows.Forms.Button();
            this.createTournementButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoadExistingTournemetLabel
            // 
            this.LoadExistingTournemetLabel.AutoSize = true;
            this.LoadExistingTournemetLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadExistingTournemetLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.LoadExistingTournemetLabel.Location = new System.Drawing.Point(117, 54);
            this.LoadExistingTournemetLabel.Name = "LoadExistingTournemetLabel";
            this.LoadExistingTournemetLabel.Size = new System.Drawing.Size(229, 25);
            this.LoadExistingTournemetLabel.TabIndex = 1;
            this.LoadExistingTournemetLabel.Text = "Load Existing Tournement";
            // 
            // TournementDashLabel
            // 
            this.TournementDashLabel.AutoSize = true;
            this.TournementDashLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TournementDashLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.TournementDashLabel.Location = new System.Drawing.Point(117, 9);
            this.TournementDashLabel.Name = "TournementDashLabel";
            this.TournementDashLabel.Size = new System.Drawing.Size(210, 25);
            this.TournementDashLabel.TabIndex = 2;
            this.TournementDashLabel.Text = "Tournement Dashboard";
            // 
            // TournementDashBoardDown
            // 
            this.TournementDashBoardDown.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TournementDashBoardDown.FormattingEnabled = true;
            this.TournementDashBoardDown.Location = new System.Drawing.Point(122, 100);
            this.TournementDashBoardDown.Name = "TournementDashBoardDown";
            this.TournementDashBoardDown.Size = new System.Drawing.Size(217, 25);
            this.TournementDashBoardDown.TabIndex = 18;
            this.TournementDashBoardDown.SelectedIndexChanged += new System.EventHandler(this.TournementDashBoardDown_SelectedIndexChanged);
            // 
            // loadTournementButton
            // 
            this.loadTournementButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.loadTournementButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.loadTournementButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.loadTournementButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(22)))), ((int)(((byte)(242)))));
            this.loadTournementButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadTournementButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.loadTournementButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.loadTournementButton.Location = new System.Drawing.Point(170, 167);
            this.loadTournementButton.Name = "loadTournementButton";
            this.loadTournementButton.Size = new System.Drawing.Size(110, 23);
            this.loadTournementButton.TabIndex = 19;
            this.loadTournementButton.Text = "Load Tournement";
            this.loadTournementButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.loadTournementButton.UseVisualStyleBackColor = true;
            this.loadTournementButton.Click += new System.EventHandler(this.loadTournementButton_Click);
            // 
            // createTournementButton
            // 
            this.createTournementButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.createTournementButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.createTournementButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.createTournementButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(22)))), ((int)(((byte)(242)))));
            this.createTournementButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createTournementButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createTournementButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.createTournementButton.Location = new System.Drawing.Point(140, 245);
            this.createTournementButton.Name = "createTournementButton";
            this.createTournementButton.Size = new System.Drawing.Size(187, 64);
            this.createTournementButton.TabIndex = 20;
            this.createTournementButton.Text = "Create Tournement";
            this.createTournementButton.UseVisualStyleBackColor = true;
            this.createTournementButton.Click += new System.EventHandler(this.createTournementButton_Click);
            // 
            // TournementDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 344);
            this.Controls.Add(this.createTournementButton);
            this.Controls.Add(this.loadTournementButton);
            this.Controls.Add(this.TournementDashBoardDown);
            this.Controls.Add(this.TournementDashLabel);
            this.Controls.Add(this.LoadExistingTournemetLabel);
            this.Name = "TournementDashboardForm";
            this.Text = "TournementDashboardForm";
            this.Load += new System.EventHandler(this.TournementDashboardForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LoadExistingTournemetLabel;
        private System.Windows.Forms.Label TournementDashLabel;
        private System.Windows.Forms.ComboBox TournementDashBoardDown;
        private System.Windows.Forms.Button loadTournementButton;
        private System.Windows.Forms.Button createTournementButton;
    }
}