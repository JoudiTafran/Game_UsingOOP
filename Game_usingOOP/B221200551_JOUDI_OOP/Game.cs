// Student Name : Joudi Tafran
// Student Number : B221200551
// Major : Information System Engineering
// Group : B

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Timer = System.Windows.Forms.Timer;
using System.Windows.Forms;

namespace B221200551_JOUDI_OOP
{
    public partial class Game : Form, IGame
    {
        public HighScoreManager highScoreManager;
        public List<PictureBox> blocks;
        public List<PictureBox> traps;
        public PictureBox player;
        public Timer trapBoxTimer;
        public Timer secretBoxTimer;
        public Timer gameTimer;
        public int elapsedTimeInSeconds = 0;
        public bool isGamePaused = false;
        public int lives;

        public Game(string InterNameBox)
        { 
            InitializeComponent();
            PlayerName.Text = InterNameBox;
            InitializeSecretBoxTimer();
            InitializeGame();
            InitializeTrapTimer();
            gameTimer = new Timer();
            gameTimer.Interval = 1000; // Set the interval to 1000 milliseconds (1 second)
            gameTimer.Tick += GameTimer_Tick;
            highScoreManager = new HighScoreManager();
            SaveHighScoresToFile();
        }

        public void GameTimer_Tick(object sender, EventArgs e)
        {
            elapsedTimeInSeconds++;

            Time.Text = $"{elapsedTimeInSeconds}";
        }

        // Method to start the game and the timer
        public void StartGame()
        {
            gameTimer.Start();
        }

        // Method to stop the game and the timer
        public void StopGame()
        {
            gameTimer.Stop();
        }

        public void TogglePause()
        {
            isGamePaused = !isGamePaused;

            if (isGamePaused)
            {
                StopGame(); // Stop the timer or any other game-related activities
                MessageBox.Show("Game Paused");
            }
            else
            {
                StartGame(); // Resume the timer or any other game-related activities
                MessageBox.Show("Game Resumed");
            }
        }

        public int CalculateScore()
        {
            // Calculate the score based on the given formula
            int score = lives * 500 + (1000 - elapsedTimeInSeconds);
            return score;
        }

        public void UpdateScoreLabel()
        {
            // Update the score label text with the current score
            Points.Text = $"{CalculateScore()}";
        }

        public void InitializeSecretBoxTimer()
        {
            secretBoxTimer = new Timer();
            secretBoxTimer.Interval = 10000; // 10 seconds
            secretBoxTimer.Tick += SecretBoxTimer_Tick;
            secretBoxTimer.Start();
        }

        public void SecretBoxTimer_Tick(object sender, EventArgs e)
        {
            if (!isGamePaused)
            {
                // Show the SecretBox when the timer ticks
                SecretBox.Visible = !SecretBox.Visible;
            }
        }

        public void SecretBox_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int randomNumber = random.Next(100);
            if (!isGamePaused)
            {
                // 80% chance of benefiting
                if (randomNumber < 80)
                {
                    lives++;
                    MessageBox.Show("You gained +1 health!");
                    UpdatePlayerHealthLabel();
                }
                // 20% chance of causing damage
                else
                {
                    lives--;
                    MessageBox.Show("Ouch! You lost -1 health!");
                    UpdatePlayerHealthLabel();
                }

                // Hide the SecretBox after it's clicked
                SecretBox.Visible = false;

                if (lives == 0)
                {
                    UpdateScoreLabel();
                    StopGame();
                    MessageBox.Show("Game Over! You lost all your lives.");
                    ResetGame();
                    return;
                }
            }
        }

        public void UpdatePlayerHealthLabel()
        {
            // Update the player health label
            Lifes.Text = $"{lives}";
        }

        public void InitializeGame()
        {
            // Create player
            player = new PictureBox
            {
                Name = "player",
                Size = new Size(44, 48),
                Image = Properties.Resources.Player,
                SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom,
            };
            player.Location = new System.Drawing.Point(15, 283);
            Controls.Add(player);

            // Create 30 blocks
            blocks = new List<PictureBox>();
            for (int i = 0; i < 30; i++)
            {
                PictureBox block = new PictureBox
                {
                    Name = "block" + i,
                    Size = new Size(71, 71),
                    Image = Properties.Resources.Block,
                    SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom,
                    Tag = "Block"
                };

                // Calculate the position based on the index i
                int x = 73 + (i % 10) * 71;  // 10 blocks per row
                int y = 200 + (i / 10) * 71;  // 3 blocks per column

                block.Location = new Point(x, y);

                blocks.Add(block);
                Controls.Add(block);
            }
                // Attach key events for player movement
                KeyDown += Game_KeyDown;

                // Set focus on the form to capture key events
                this.Focus();
        }

        public void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isGamePaused)
            {
                if (e.KeyCode == Keys.Up)
                {
                    MovePlayer(0, -71);
                }
                if (e.KeyCode == Keys.Down)
                {
                    MovePlayer(0, 71);
                }
                if (e.KeyCode == Keys.Left && player.Left > 15)
                {
                    MovePlayer(-71, 0);
                }
                if (e.KeyCode == Keys.Right && player.Left < 796)
                {
                    MovePlayer(71, 0);
                }

                if (player.Top < 211)
                {
                    player.Top = 355;
                }

                if (player.Top > 365)
                {
                    player.Top = 211;
                }
            }

            if (e.KeyCode == Keys.P)
            {
                TogglePause();
            }

        }

        public void MovePlayer(int deltaX, int deltaY)
        {
            // Update the player's position
            player.Location = new Point(player.Location.X + deltaX, player.Location.Y + deltaY); ;

            if (player.Location.X == 796)
            {
                UpdateScoreLabel();
                StopGame();
                CheckAndUpdateHighScores();
                StartNewLevel();
            }

            ChekTraps();
        }

        protected virtual void ChekTraps()
        {
            foreach (PictureBox trap in traps)
            {
                if (player.Bounds.IntersectsWith(trap.Bounds) && trap.Visible == true && !isGamePaused)
                {
                    lives = lives - 1;
                    Lifes.Text = "" + lives;
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

        protected virtual void StartNewLevel() { }

        public void InitializeTrapTimer()
        {
            trapBoxTimer = new Timer();
            trapBoxTimer.Interval = 500; // Set the interval to 1500 milliseconds (1.5 seconds)
            trapBoxTimer.Tick += TrapBoxTimer_Tick;
            trapBoxTimer.Start(); // Start the timer
        }

        protected virtual void TrapBoxTimer_Tick(object sender, EventArgs e) { }

        public void UpdateBomd()
        {
            Random random = new Random();
            foreach (PictureBox trap in traps)
            {
                trap.Visible = !trap.Visible;
                int randomBlockIndex = random.Next(30);
                PictureBox block = blocks[randomBlockIndex];
                trap.Location = new Point(block.Location.X, block.Location.Y);
            }
        }

        public void ResetGame()
        {
            StartGame();
            Lifes.Text = "3";
            lives = 3;

            // Reset player position
            player.Location = new System.Drawing.Point(15, 283);

            // Randomly reposition
            Random random = new Random();
            foreach (PictureBox trap in traps)
            {
                trap.Visible = false;
                int randomBlockIndex = random.Next(30);
                PictureBox block = blocks[randomBlockIndex];
                trap.Location = new Point(block.Location.X , block.Location.Y ); // Adjust position above the block
            }
        }

        public void SaveHighScoresToFile()
        {
            // Save high scores to file using the HighScoreManager
            highScoreManager.SaveHighScores();
        }

        public void CheckAndUpdateHighScores()
        {
            // Check if the current score is among the top 5
            int currentScore = CalculateScore();
            if (highScoreManager.HighScores.Count < 5 || currentScore > highScoreManager.HighScores.Last().Score)
            {
                // Prompt the user for their name (you may want to use an input dialog)
                string playerName = PlayerName.Text; // Replace with actual user input

                // Add the new high score
                highScoreManager.AddHighScore(playerName, currentScore);
            }
        }
    }
}
