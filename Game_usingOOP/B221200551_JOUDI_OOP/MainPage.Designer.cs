
namespace B221200551_JOUDI_OOP
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.Folder = new System.Windows.Forms.PictureBox();
            this.Info = new System.Windows.Forms.PictureBox();
            this.Home = new System.Windows.Forms.PictureBox();
            this.players = new System.Windows.Forms.PictureBox();
            this.StartGame = new System.Windows.Forms.Label();
            this.Scores = new System.Windows.Forms.Label();
            this.Keypad = new System.Windows.Forms.Label();
            this.InterNameBox = new System.Windows.Forms.TextBox();
            this.InterNameLable = new System.Windows.Forms.Label();
            this.Player = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Folder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Info)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Home)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.players)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.SuspendLayout();
            // 
            // Folder
            // 
            this.Folder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Folder.Image = ((System.Drawing.Image)(resources.GetObject("Folder.Image")));
            this.Folder.Location = new System.Drawing.Point(285, 469);
            this.Folder.Name = "Folder";
            this.Folder.Size = new System.Drawing.Size(46, 27);
            this.Folder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Folder.TabIndex = 31;
            this.Folder.TabStop = false;
            this.Folder.Click += new System.EventHandler(this.Folder_Click);
            // 
            // Info
            // 
            this.Info.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Info.Image = ((System.Drawing.Image)(resources.GetObject("Info.Image")));
            this.Info.Location = new System.Drawing.Point(285, 405);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(45, 35);
            this.Info.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Info.TabIndex = 30;
            this.Info.TabStop = false;
            this.Info.Click += new System.EventHandler(this.Info_Click);
            // 
            // Home
            // 
            this.Home.Image = ((System.Drawing.Image)(resources.GetObject("Home.Image")));
            this.Home.Location = new System.Drawing.Point(285, 328);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(46, 37);
            this.Home.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Home.TabIndex = 29;
            this.Home.TabStop = false;
            // 
            // players
            // 
            this.players.Image = ((System.Drawing.Image)(resources.GetObject("players.Image")));
            this.players.Location = new System.Drawing.Point(849, 304);
            this.players.Name = "players";
            this.players.Size = new System.Drawing.Size(199, 222);
            this.players.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.players.TabIndex = 28;
            this.players.TabStop = false;
            // 
            // StartGame
            // 
            this.StartGame.Font = new System.Drawing.Font("Tahoma", 14F);
            this.StartGame.Location = new System.Drawing.Point(347, 323);
            this.StartGame.Name = "StartGame";
            this.StartGame.Size = new System.Drawing.Size(455, 80);
            this.StartGame.TabIndex = 27;
            this.StartGame.Text = "Enter your information and press enter to start the game";
            // 
            // Scores
            // 
            this.Scores.AutoSize = true;
            this.Scores.Font = new System.Drawing.Font("Tahoma", 14F);
            this.Scores.Location = new System.Drawing.Point(347, 469);
            this.Scores.Name = "Scores";
            this.Scores.Size = new System.Drawing.Size(367, 34);
            this.Scores.TabIndex = 26;
            this.Scores.Text = "Click to view the best scores";
            // 
            // Keypad
            // 
            this.Keypad.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.Keypad.AutoSize = true;
            this.Keypad.BackColor = System.Drawing.Color.Thistle;
            this.Keypad.Font = new System.Drawing.Font("Tahoma", 14F);
            this.Keypad.Location = new System.Drawing.Point(347, 407);
            this.Keypad.Name = "Keypad";
            this.Keypad.Size = new System.Drawing.Size(439, 34);
            this.Keypad.TabIndex = 25;
            this.Keypad.Text = "Click for game keypad information";
            // 
            // InterNameBox
            // 
            this.InterNameBox.BackColor = System.Drawing.Color.Black;
            this.InterNameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InterNameBox.Font = new System.Drawing.Font("Tahoma", 13F);
            this.InterNameBox.ForeColor = System.Drawing.Color.White;
            this.InterNameBox.Location = new System.Drawing.Point(727, 162);
            this.InterNameBox.Name = "InterNameBox";
            this.InterNameBox.Size = new System.Drawing.Size(200, 39);
            this.InterNameBox.TabIndex = 24;
            this.InterNameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InterNameBox_KeyDown);
            // 
            // InterNameLable
            // 
            this.InterNameLable.BackColor = System.Drawing.Color.GhostWhite;
            this.InterNameLable.Font = new System.Drawing.Font("Tahoma", 14F);
            this.InterNameLable.ForeColor = System.Drawing.Color.Black;
            this.InterNameLable.Location = new System.Drawing.Point(498, 146);
            this.InterNameLable.Name = "InterNameLable";
            this.InterNameLable.Size = new System.Drawing.Size(442, 67);
            this.InterNameLable.TabIndex = 23;
            this.InterNameLable.Text = "Inter you name :";
            this.InterNameLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Player
            // 
            this.Player.Image = ((System.Drawing.Image)(resources.GetObject("Player.Image")));
            this.Player.Location = new System.Drawing.Point(294, 76);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(160, 197);
            this.Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Player.TabIndex = 22;
            this.Player.TabStop = false;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(1278, 644);
            this.Controls.Add(this.Folder);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.Home);
            this.Controls.Add(this.players);
            this.Controls.Add(this.StartGame);
            this.Controls.Add(this.Scores);
            this.Controls.Add(this.Keypad);
            this.Controls.Add(this.InterNameBox);
            this.Controls.Add(this.InterNameLable);
            this.Controls.Add(this.Player);
            this.Name = "MainPage";
            this.Text = "MainPage";
            ((System.ComponentModel.ISupportInitialize)(this.Folder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Info)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Home)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.players)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Folder;
        private System.Windows.Forms.PictureBox Info;
        private System.Windows.Forms.PictureBox Home;
        private System.Windows.Forms.PictureBox players;
        private System.Windows.Forms.Label StartGame;
        private System.Windows.Forms.Label Scores;
        private System.Windows.Forms.Label Keypad;
        private System.Windows.Forms.TextBox InterNameBox;
        private System.Windows.Forms.Label InterNameLable;
        private System.Windows.Forms.PictureBox Player;
    }
}

