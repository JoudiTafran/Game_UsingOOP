// Student Name : Joudi Tafran
// Student Number : B221200551
// Major : Information System Engineering
// Group : B

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace B221200551_JOUDI_OOP
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Info_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Use the arrow keys to move your avatar. Press P to stop the game.");
        }

        private void Folder_Click(object sender, EventArgs e)
        {
            // Specify the path to the highscore.txt file
            string filePath = "highscores.txt";

            // Check if the file exists before attempting to open it
            if (File.Exists(filePath))
            {
                // Open the file with the default text editor
                Process.Start(filePath);
            }

        }

        private void InterNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            var game = new Game(InterNameBox.Text);
            if (e.KeyCode == Keys.Enter)
            {
                var openlevel1 = new Level1(InterNameBox.Text);
                openlevel1.Show();
                openlevel1.StartGame();
                this.Hide();
            }
        }
    }
}
