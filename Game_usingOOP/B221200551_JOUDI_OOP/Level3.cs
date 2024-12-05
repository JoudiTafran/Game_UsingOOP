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
    public partial class Level3 : Game
    {
        public bool isFirstTick = true;
        public Level3(string InterName, int Timer, int NewLives) : base(InterName)
        {
            elapsedTimeInSeconds = Timer;
            lives = NewLives + 1;
            InitializeComponent();
            InitializeGame();
        }

        private new void InitializeGame()
        {
            Lifes.Text = $"{lives}";
            this.Name = "Level3";
            this.Size = new Size(870, 550);
            LevelNumber.Text = "3";

            // Create 5 enemy
            traps = new List<PictureBox>();
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                PictureBox trap = new PictureBox
                {
                    Name = "bomb" + i,
                    Size = new Size(71,71),
                    Image = (Image)Properties.Resources.Enemy,
                    SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom,
                    Tag = "Trap",
                    Visible = false
                };

                int randomBlockIndex;
                randomBlockIndex = random.Next(30);
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

        private void MoveTrapBoxesLeft()
        {
            // Move each trap box to the left by one step
            foreach (PictureBox trap in traps)
            {
                if (trap.Location.X > 73)
                {
                    trap.Left -= 71;
                }  
            }
        }

        protected override void TrapBoxTimer_Tick(object sender, EventArgs e)
        {
            if (isFirstTick)
            {
                // Update trap box positions and visibility when they first appear
                if (!isGamePaused)
                {
                    UpdateBomd();
                }
            }
            else
            {
                // Move the trap boxes to the left one step after one second
                if (!isGamePaused)
                {
                    MoveTrapBoxesLeft();
                }
            }

            // Toggle the flag for the next tick
            isFirstTick = !isFirstTick;

            ChekTraps();
        }

        protected override void StartNewLevel()
        {
            MessageBox.Show("You win the game, view your scores on home page");
            var openHome = new MainPage();
            openHome.Show();
            this.Hide();
        }  
    }
}
