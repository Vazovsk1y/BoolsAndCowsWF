using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BoolsAndCows
{
    public partial class MainForm : Form
    {
        private GameSession CurrentGameSession { get; } = new GameSession();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            startButton.Click += new EventHandler(ButtonClickHandler);
            delete.Click += new EventHandler(ButtonClickHandler);
            clear.Click += new EventHandler(ButtonClickHandler);
            checkButton.Click += new EventHandler(ButtonClickHandler);
            hintButton.Click += new EventHandler(ButtonClickHandler);
            button1.Click += new EventHandler(ButtonClickHandler);
            button2.Click += new EventHandler(ButtonClickHandler);
            button3.Click += new EventHandler(ButtonClickHandler);
            button4.Click += new EventHandler(ButtonClickHandler);
            button5.Click += new EventHandler(ButtonClickHandler);
            button6.Click += new EventHandler(ButtonClickHandler);
            button7.Click += new EventHandler(ButtonClickHandler);
            button8.Click += new EventHandler(ButtonClickHandler);
            button9.Click += new EventHandler(ButtonClickHandler);
        }

        private void ButtonClickHandler(object sender, EventArgs e)
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
                    userNumberBox.Text = string.Empty;
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
            if(!CurrentGameSession.IsGameStarted)
            {
                actionsField.Text += "You didn't start the game!\n";
            }
            else if (CurrentGameSession.IsHintsEnd)
            {
                actionsField.Text = "You loose! The game is end!\n";
                textBox1.Text = string.Empty;
                CurrentGameSession.Stop();
            }
            else
            {
                textBox1.Text = CurrentGameSession.GetHint(textBox1.Text);
            }
        }

        private void ProcessDeleteButton()
        {
            if (userNumberBox.Text.Equals(string.Empty))
                return;
            userNumberBox.Text = userNumberBox.Text.Remove(userNumberBox.Text.Length - 1, 1);
            userNumberBox.SelectionStart = userNumberBox.Text.Length;
        }

        private void ProcessNumberButtonClick(string buttonText)
        {
            int currentCursorPosition = userNumberBox.SelectionStart;
            if (!currentCursorPosition.Equals(userNumberBox.Text.Length))
            {
                userNumberBox.Text = userNumberBox.Text.Insert(currentCursorPosition, buttonText);
                userNumberBox.SelectionStart += ++currentCursorPosition;
                return;
            }

            userNumberBox.Text += buttonText;
            userNumberBox.SelectionStart = userNumberBox.Text.Length;
            userNumberBox.SelectionLength = 0;
        }

        private void ProcessStartButton()
        {
            if (CurrentGameSession.IsGameStarted)
                actionsField.Text += "You are already in the game!\n";
            else
            {
                CurrentGameSession.Start();
                actionsField.Text = "Welcome to the game!\n";
                textBox1.Text = string.Join("",CurrentGameSession.SystemNumber.ToCharArray().Select(i => i = '*'));
            }
        }

        private void ProcessCheckButton()
        {
            if (CurrentGameSession.IsGameStarted.Equals(false))
                actionsField.Text += "You didn't start the game!\n";

            else if (userNumberBox.Text.Equals(string.Empty))
                actionsField.Text += "You didn't enter the number!\n";

            else if (userNumberBox.Text.ToCharArray().Where(i => char.IsLetter(i) || char.IsSymbol(i)).Any())
                actionsField.Text += "You number contains letters or symbols!\n";

            else if (userNumberBox.Text.Length != 4)
                actionsField.Text += $"Your number is not foursign!\n";

            else
            {
                int boolsCount = CurrentGameSession.GetBoolsCount(userNumberBox.Text, CurrentGameSession.SystemNumber);
                int cowsCount = CurrentGameSession.GetCowsCount(userNumberBox.Text, CurrentGameSession.SystemNumber);

                if (!boolsCount.Equals(textBox1.Text.Length))
                    actionsField.Text += $"{userNumberBox.Text} Bools: " +
                        $"{boolsCount} " +
                        $"Cows: {cowsCount}\n";
                else
                {
                    CurrentGameSession.Stop();
                    actionsField.Text += "CONGRATULATION, YOU WON!";
                    textBox1.Text = string.Empty;
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(CurrentGameSession.IsGameStarted)
            {
                DialogResult dialogResult = MessageBox.Show("The game is active.\nAre you sure that want to quit?",
                    "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult.Equals(DialogResult.No))
                    e.Cancel = true;
            }
        }
    }

    /* 
     
     SET A CODE STRUCTURE AND DO A REFACTORING:
     * class ButtonsHandler - work with buttonsClick event;
     
     */

    // WORK ABOUT FORM AND CONTROLS SIZE ALSO COTROLS SCALING DEPEND ON FORM SIZE(solution)

    // PLAY WITH FORM GUI
}
