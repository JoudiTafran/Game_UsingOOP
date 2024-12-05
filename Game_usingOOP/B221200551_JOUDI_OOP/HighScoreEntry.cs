// Student Name : Joudi Tafran
// Student Number : B221200551
// Major : Information System Engineering
// Group : B

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace B221200551_JOUDI_OOP
{
    public class HighScoreEntry
    {
        public string PlayerName { get; }
        public int Score { get; }

        public HighScoreEntry(string playerName, int score)
        {
            PlayerName = playerName;
            Score = score;
        }
    }
    public class HighScoreManager
    {
        public const string HighScoresFilePath = "highscores.txt";

        public List<HighScoreEntry> HighScores { get; private set; }

        public HighScoreManager()
        {
            LoadHighScores();
        }

        public void LoadHighScores()
        {
            HighScores = new List<HighScoreEntry>();

            try
            {
                if (File.Exists(HighScoresFilePath))
                {
                    string[] lines = File.ReadAllLines(HighScoresFilePath);

                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 2 && int.TryParse(parts[1], out int score))
                        {
                            HighScores.Add(new HighScoreEntry(parts[0], score));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading high scores: {ex.Message}");
            }

            // Sort high scores by score in descending order
            HighScores = HighScores.OrderByDescending(entry => entry.Score).ToList();
        }

        public void AddHighScore(string playerName, int score)
        {
            HighScores.Add(new HighScoreEntry(playerName, score));

            // Sort high scores by score in descending order
            HighScores = HighScores.OrderByDescending(entry => entry.Score).ToList();

            // Keep only the top 5 scores
            HighScores = HighScores.Take(5).ToList();

            SaveHighScores();
        }

        public void SaveHighScores()
        {
            try
            {
                // Read existing high scores from the file
                List<string> existingScores = new List<string>();
                if (File.Exists(HighScoresFilePath))
                {
                    existingScores = File.ReadAllLines(HighScoresFilePath).ToList();
                }

                // Add the new high score
                existingScores.Add($"{HighScores.Last().PlayerName} : {HighScores.Last().Score}");

                // Sort high scores by score in descending order
                existingScores = existingScores.OrderByDescending(entry => int.Parse(entry.Split(':')[1].Trim())).ToList();

                // Keep only the top 5 scores
                existingScores = existingScores.Take(5).ToList();

                // Write all the scores back to the file
                File.WriteAllLines(HighScoresFilePath, existingScores);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving high scores: {ex.Message}");
            }
        }

    }  
}
