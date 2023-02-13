using System.Linq;
using BoolsAndCows.Models;

namespace BoolsAndCows.Controls.Buttons
{
    internal class Check : GameButtonHandler, IGameButtonHandler
    {
        public Check(MainForm mainForm, GameSession gameSession) : base(mainForm, gameSession) { }

        public void ProcessButtonClick()
        {
            if (gameSession.IsGameStarted.Equals(false))
                elementsToInterract.actionsField.Text += "You didn't start the game!\n";

            else if (elementsToInterract.userNumberBox.Text.Equals(string.Empty))
                elementsToInterract.actionsField.Text += "You didn't enter the number!\n";

            else if (elementsToInterract.userNumberBox.Text.ToCharArray().Where(i => char.IsLetter(i) || char.IsSymbol(i)).Any())
                elementsToInterract.actionsField.Text += "You number contains letters or symbols!\n";

            else if (elementsToInterract.userNumberBox.Text.Length != 4)
                elementsToInterract.actionsField.Text += $"Your number is not foursign!\n";

            else
            {
                int boolsCount = gameSession.GetBoolsCount(elementsToInterract.userNumberBox.Text, gameSession.SystemNumber);
                int cowsCount = gameSession.GetCowsCount(elementsToInterract.userNumberBox.Text, gameSession.SystemNumber);

                if (!boolsCount.Equals(elementsToInterract.systemNumberBox.Text.Length))
                {
                    elementsToInterract.actionsField.Text += $"{elementsToInterract.userNumberBox.Text} Bools: " +
                        $"{boolsCount} " +
                        $"Cows: {cowsCount}\n";
                    gameSession.IncreaseGameSteps(elementsToInterract.userNumberBox.Text);
                }
                else
                {
                    elementsToInterract.resultLabel.Text += $"Your result:\nSteps spend - {gameSession.StepsCount}";
                    elementsToInterract.actionsField.Text += "CONGRATULATION, YOU WON!";
                    elementsToInterract.systemNumberBox.Text = string.Empty;
                    gameSession.Stop();
                }
            }
        }
    }
}
