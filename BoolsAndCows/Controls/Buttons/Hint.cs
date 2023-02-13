using BoolsAndCows.Models;
using System.Windows.Forms;

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
            else if(gameSession.IsHintsEnd)
            {
                var dialogResult = MessageBox.Show("Are you sure?\nIf you will use last hint you loose.", "Question", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    elementsToInterract.actionsField.Text = "You loose! The game is end!\n";
                    elementsToInterract.systemNumberBox.Text = string.Empty;
                    gameSession.Stop();
                }
            }
            else
            {
                elementsToInterract.systemNumberBox.Text = gameSession.GetHint(elementsToInterract.systemNumberBox.Text);
            }
        }
    }
}
