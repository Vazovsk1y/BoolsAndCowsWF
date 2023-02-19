using System.Linq;
using System.Runtime.InteropServices;
using BoolsAndCows.View;

namespace BoolsAndCows.Presenter.Buttons
{
    internal class Start : GameButtonHandler, IGameButtonHandler
    {
        private const char _tabulation = '\t';

        public Start(MainForm mainForm, GameSession gameSession) : base(mainForm, gameSession) { }

        public void ProcessButtonClick()
        {
            if (gameSession.IsGameStarted)
            {
                elementsToInterract.actionsField.Texts += $"{_tabulation}You are already in the game!\n";
            }
            else
            {
                StartGame();
            }

            void StartGame()
            {
                gameSession.Start();
                elementsToInterract.actionsField.Texts = $"{_tabulation}Welcome to the game!\n";
                elementsToInterract.systemNumberBox.Text = string.Join("", gameSession.SystemNumber.ToCharArray().Select(i => i = '*'));
            }
        }
    }
}
