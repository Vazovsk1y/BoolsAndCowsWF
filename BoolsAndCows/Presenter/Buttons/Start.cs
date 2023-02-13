using System.Linq;
using BoolsAndCows.Presenter;

namespace BoolsAndCows.Presenter.Buttons
{
    internal class Start : GameButtonHandler, IGameButtonHandler
    {
        public Start(MainForm mainForm, GameSession gameSession) : base(mainForm, gameSession) { }

        public void ProcessButtonClick()
        {
            if (gameSession.IsGameStarted)
            {
                elementsToInterract.actionsField.Text += "You are already in the game!\n";
            }
            else
            {
                StartGame();
            }

            void StartGame()
            {
                gameSession.Start();
                elementsToInterract.resultLabel.Text = string.Empty;
                elementsToInterract.actionsField.Text = "Welcome to the game!\n";
                elementsToInterract.systemNumberBox.Text = string.Join("", gameSession.SystemNumber.ToCharArray().Select(i => i = '*'));
            }
        }
    }
}
