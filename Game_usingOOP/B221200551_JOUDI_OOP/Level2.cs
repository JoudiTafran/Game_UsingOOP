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
    public partial class Level2 : Game
    {
        public Level2(string InterName, int Timer, int NewLives) : base(InterName)
        {
            elapsedTimeInSeconds = Timer;
            lives = NewLives + 1;
            InitializeComponent();
            InitializeGame();
        }

        private new void InitializeGame()
        {
            Lifes.Text = $"{lives}";
            this.Name = "Level2";
            this.Size = new Size(870, 550);
            LevelNumber.Text = "2";

            traps = new List<PictureBox>();
            Random random = new Random();
            for (int i = 0; i < 11; i++)
            {
                PictureBox trap = new PictureBox
                {
                    Name = "bomb" + i,
                    Size = new Size(71, 71),
                    Image = Properties.Resources.Bomb,
                    SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom,
                    Tag = "Trap",
                    Visible = false
                };

                //trap.BringToFront();
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

        protected override void TrapBoxTimer_Tick(object sender, EventArgs e)
        {
            if (!isGamePaused)
            {
                // Update trap box positions and visibility every 3 seconds
                UpdateBomd();
            }

            ChekTraps();
        }

        protected override void StartNewLevel()
        {
            MessageBox.Show("You win, Go to level3");
            var openlevel3 = new Level3(PlayerName.Text, elapsedTimeInSeconds, lives);
            openlevel3.Show();
            openlevel3.StartGame();
            this.Hide();
        }
    }
}
