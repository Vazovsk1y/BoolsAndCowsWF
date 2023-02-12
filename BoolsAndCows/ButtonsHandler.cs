using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BoolsAndCows
{
    internal class ButtonsHandler
    {
        private GameSession CurrentGameSession { get; } = new GameSession();
        private List<Button> Buttons { get; }
        private MainForm MainForm { get; }

        public ButtonsHandler(MainForm mainForm)
        {
            Buttons = mainForm.Controls.OfType<Button>().ToList();
            MainForm = mainForm;
        }

        public void StartButtonHandler()
        {
            foreach (Button button in Buttons)
            {
                button.Click += new EventHandler(ButtonClickHandler);
            }
        }

        public void ButtonClickHandler(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            List<string> buttonNumbersText = new List<string>()
            { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            foreach (string item in buttonNumbersText)
            {
                if (item.Equals(button.Text))
                {
                    ProcessNumberButtonClick(button.Text);
                    return;
                }
            }

            switch (button.Text)
            {
                case "Clear":
                    MainForm.userNumberBox.Text = string.Empty;
                    break;
                case "<=":
                    ProcessDeleteButton();
                    break;
                case "Start":
                    ProcessStartButton();
                    break;
                case "Check":
                    ProcessCheckButton();
                    break;
                case "Hint":
                    ProcessHintButton();
                    break;
                default:
                    return;
            }
        }

        private void ProcessHintButton()
        {
            if (!CurrentGameSession.IsGameStarted)
            {
                MainForm.actionsField.Text += "You didn't start the new game!\n";
            }
            else if (CurrentGameSession.IsHintsEnd)
            {
                MainForm.actionsField.Text = "You loose! The game is end!\n";
                MainForm.textBox1.Text = string.Empty;
                CurrentGameSession.Stop();
            }
            else
            {
                MainForm.textBox1.Text = CurrentGameSession.GetHint(MainForm.textBox1.Text);
            }
        }

        private void ProcessDeleteButton()
        {
            if (MainForm.userNumberBox.Text.Equals(string.Empty))
                return;
            MainForm.userNumberBox.Text = MainForm.userNumberBox.Text.Remove(MainForm.userNumberBox.Text.Length - 1, 1);
            MainForm.userNumberBox.SelectionStart = MainForm.userNumberBox.Text.Length;
        }

        private void ProcessNumberButtonClick(string buttonText)
        {
            int currentCursorPosition = MainForm.userNumberBox.SelectionStart;
            if (!currentCursorPosition.Equals(MainForm.userNumberBox.Text.Length))
            {
                MainForm.userNumberBox.Text = MainForm.userNumberBox.Text.Insert(currentCursorPosition, buttonText);
                MainForm.userNumberBox.SelectionStart += ++currentCursorPosition;
                return;
            }

            MainForm.userNumberBox.Text += buttonText;
            MainForm.userNumberBox.SelectionStart = MainForm.userNumberBox.Text.Length;
            MainForm.userNumberBox.SelectionLength = 0;
        }

        private void ProcessStartButton()
        {
            if (CurrentGameSession.IsGameStarted)
                MainForm.actionsField.Text += "You are already in the game!\n";
            else
            {
                CurrentGameSession.Start();
                MainForm.actionsField.Text = "Welcome to the game!\n";
                MainForm.textBox1.Text = string.Join("", CurrentGameSession.SystemNumber.ToCharArray().Select(i => i = '*'));
            }
        }

        private void ProcessCheckButton()
        {
            if (CurrentGameSession.IsGameStarted.Equals(false))
                MainForm.actionsField.Text += "You didn't start the game!\n";

            else if (MainForm.userNumberBox.Text.Equals(string.Empty))
                MainForm.actionsField.Text += "You didn't enter the number!\n";

            else if (MainForm.userNumberBox.Text.ToCharArray().Where(i => char.IsLetter(i) || char.IsSymbol(i)).Any())
                MainForm.actionsField.Text += "You number contains letters or symbols!\n";

            else if (MainForm.userNumberBox.Text.Length != 4)
                MainForm.actionsField.Text += $"Your number is not foursign!\n";

            else
            {
                int boolsCount = CurrentGameSession.GetBoolsCount(MainForm.userNumberBox.Text, CurrentGameSession.SystemNumber);
                int cowsCount = CurrentGameSession.GetCowsCount(MainForm.userNumberBox.Text, CurrentGameSession.SystemNumber);

                if (!boolsCount.Equals(MainForm.textBox1.Text.Length))
                    MainForm.actionsField.Text += $"{MainForm.userNumberBox.Text} Bools: " +
                        $"{boolsCount} " +
                        $"Cows: {cowsCount}\n";
                else
                {
                    CurrentGameSession.Stop();
                    MainForm.actionsField.Text += "CONGRATULATION, YOU WON!";
                    MainForm.textBox1.Text = string.Empty;
                }
            }
        }

    }
}
