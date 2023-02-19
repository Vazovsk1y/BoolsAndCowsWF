using System.Linq;
using BoolsAndCows.View;

namespace BoolsAndCows.Presenter.Buttons
{
    internal class Check : GameButtonHandler, IGameButtonHandler
    {
        private const char _tabulation = '\t';
        public Check(MainForm mainForm, GameSession gameSession) : base(mainForm, gameSession) { }

        public void ProcessButtonClick()
        {
            if (gameSession.IsGameStarted.Equals(false))
                elementsToInterract.actionsField.Texts += $"{_tabulation}You didn't start the game!\n";

            else if (elementsToInterract.userNumberBox.Texts.Equals(string.Empty))
                elementsToInterract.actionsField.Texts += $"{_tabulation}You didn't enter the number!\n";

            else if (elementsToInterract.userNumberBox.Texts.ToCharArray().Where(i => char.IsLetter(i) || char.IsSymbol(i)).Any())
                elementsToInterract.actionsField.Texts += "You number contains letters or symbols!\n";

            else if (elementsToInterract.userNumberBox.Texts.Length != 4)
                elementsToInterract.actionsField.Texts += $"{_tabulation}Your number is not foursign!\n";

            else
            {
                int boolsCount = gameSession.GetBoolsCount(elementsToInterract.userNumberBox.textBox1.Text, gameSession.SystemNumber);
                int cowsCount = gameSession.GetCowsCount(elementsToInterract.userNumberBox.textBox1.Text, gameSession.SystemNumber);

                if (!boolsCount.Equals(elementsToInterract.systemNumberBox.Text.Length))
                {
                    elementsToInterract.actionsField.Texts += $"{_tabulation}{elementsToInterract.userNumberBox.textBox1.Text} Bulls: " +
                        $"{boolsCount} " +
                        $"Cows: {cowsCount}\n";
                    gameSession.IncreaseGameSteps(elementsToInterract.userNumberBox.textBox1.Text);
                }
                else
                {
                    gameSession.IncreaseGameSteps(elementsToInterract.userNumberBox.textBox1.Text);
                    elementsToInterract.actionsField.Texts = "CONGRATULATION, YOU WON!" +
                       $"Steps spend - {gameSession.StepsCount}\n" +
                       $"Hints used - {gameSession.UsedHintsCount}\n";
                    elementsToInterract.systemNumberBox.Text = string.Empty;
                    gameSession.Stop();
                }
            }
        }
    }
}
