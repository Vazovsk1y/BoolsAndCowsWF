using System.Windows.Forms;
using BoolsAndCows.View;

namespace BoolsAndCows.Presenter.Buttons
{
    internal class Hint : GameButtonHandler, IGameButtonHandler
    {
        private const char _tabulation = '\t';
        public Hint(MainForm elementsToInteractWith, GameSession gameSession) : base(elementsToInteractWith, gameSession) { }

        public void ProcessButtonClick()
        {
            if (!gameSession.IsGameStarted)
            {
                elementsToInterract.actionsField.Texts += $"{_tabulation}You didn't start the new game!\n";
            }
            else if(gameSession.IsHintsEnd)
            {
                var dialogResult = MessageBox.Show("Are you sure?\nIf you will use last hint you loose.", "Question", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    elementsToInterract.actionsField.Texts = $"{_tabulation}You loose! The game is end!\n";
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
