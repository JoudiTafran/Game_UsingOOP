// Student Name : Joudi Tafran
// Student Number : B221200551
// Major : Information System Engineering
// Group : B

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace B221200551_JOUDI_OOP
{
    public partial class Level1 : Game
    {
        public Level1(string InterNameBox) : base(InterNameBox)
        {
            InitializeComponent();
            InitializeGame(); 
        }
        private new void InitializeGame()
        {
            lives = 3;
            Lifes.Text = "3";
            this.Name = "Level1";
            this.Size = new Size(870, 550);
            LevelNumber.Text = "1";

            // Create 10 traps with different images from resources and randomly hide them in blocks
            traps = new List<PictureBox>();
            Random random = new Random();
            string[] trapResourceNames = { "trap1", "trap2", "trap3" };

            for (int i = 0; i < 11; i++)
            {
                PictureBox trap = new PictureBox
                {
                    Name = "trap" + i,
                    Size = new Size(71,71),
                    Image = (Image)Properties.Resources.ResourceManager.GetObject(trapResourceNames[i % 3]), // Cycles through the 3 trap types
                    SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom,
                    Tag = "Trap",
                    Visible = false
                };

                int randomBlockIndex = random.Next(30);
                PictureBox block = blocks[randomBlockIndex];
                trap.Location = new Point(block.Location.X, block.Location.Y);
                traps.Add(trap);
            }
            // Add traps after blocks
            foreach (PictureBox trap in traps)
            {
                Controls.Add(trap);
            }

            // Send blocks to the back
            foreach (PictureBox block in blocks)
            {
                block.SendToBack();
            }
        }

        protected override void ChekTraps()
        {
            foreach (PictureBox trap in traps)
            {
                if (player.Bounds.IntersectsWith(trap.Bounds) && !isGamePaused)
                {
                    lives = lives - 1;
                    Lifes.Text = "" + lives;
                    trap.Visible = true;
                    if (lives == 0)
                    {
                        UpdateScoreLabel();
                        StopGame();
                        MessageBox.Show("Game Over! You lost all your lives.");
                        ResetGame();
                        return;
                    }
                    return;
                }
            }
        }

        protected override void StartNewLevel()
        {
            MessageBox.Show("You win, Go to level2");
            var openlevel2 = new Level2(PlayerName.Text, elapsedTimeInSeconds, lives);
            openlevel2.Show();
            openlevel2.StartGame();
            this.Hide();
        }
    }
}

