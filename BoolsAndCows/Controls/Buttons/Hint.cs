using BoolsAndCows.Models;

namespace BoolsAndCows.Controls.Buttons
{
    internal class Hint : GameButtonHandler, IGameButtonHandler
    {
        public Hint(MainForm elementsToInteractWith, GameSession gameSession) : base(elementsToInteractWith, gameSession) { }

        public void ProcessButtonClick()
        {
            if (!gameSession.IsGameStarted)
            {
                elementsToInterract.actionsField.Text += "You didn't start the new game!\n";
            }
            else if (gameSession.IsHintsEnd)
            {
                elementsToInterract.actionsField.Text = "You loose! The game is end!\n";
                elementsToInterract.systemNumberBox.Text = string.Empty;
                gameSession.Stop();
            }
            else
            {
                elementsToInterract.systemNumberBox.Text = gameSession.GetHint(elementsToInterract.systemNumberBox.Text);
            }
        }
    }
}
