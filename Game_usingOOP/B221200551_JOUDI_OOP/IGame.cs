// Student Name : Joudi Tafran
// Student Number : B221200551
// Major : Information System Engineering
// Group : B

namespace B221200551_JOUDI_OOP
{
    //Those who inherit from this interface must have the methods and variables I defined.
    interface IGame
    {
        void StartGame();
        void StopGame();
        void TogglePause();
        int CalculateScore();
        void UpdateScoreLabel();
        void UpdatePlayerHealthLabel();
        void InitializeGame();
        void MovePlayer(int deltaX, int deltaY);
        void ResetGame();
        void SaveHighScoresToFile();
    }
}
