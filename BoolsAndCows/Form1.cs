using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoolsAndCows
{
    public partial class MainForm : Form
    {
        private bool IsGameStarted = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void ButtonClickHandler(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            try
            {
                switch (button.Text)
                {
                    case "1":
                        ProcessButtonClick(button.Text);
                        break;
                    case "2":
                        ProcessButtonClick(button.Text);
                        break;
                    case "3":
                        ProcessButtonClick(button.Text);
                        break;
                    case "4":
                        ProcessButtonClick(button.Text);
                        break;
                    case "5":
                        ProcessButtonClick(button.Text);
                        break;
                    case "6":
                        ProcessButtonClick(button.Text);
                        break;
                    case "7":
                        ProcessButtonClick(button.Text);
                        break;
                    case "8":
                        ProcessButtonClick(button.Text);
                        break;
                    case "9":
                        ProcessButtonClick(button.Text);
                        break;
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
                    default:
                        return;
                }
            }
            catch(Exception ex)
            {
                actionsField.Text += $"{ex.Message}\n";
            }

            void ProcessStartButton()
            {
                if (IsGameStarted)
                    actionsField.Text += "You are already in the game!\n";
                else
                {
                    actionsField.Text = string.Empty;
                    textBox1.Text = GenerateSystemNumber();
                    IsGameStarted = true;
                }
            }

            void ProcessDeleteButton()
            {
                if (userNumberBox.Text.Equals(string.Empty))
                    return;
                userNumberBox.Text = userNumberBox.Text.Remove(userNumberBox.Text.Length - 1, 1);
                userNumberBox.SelectionStart = userNumberBox.Text.Length;
            }

            void ProcessCheckButton()
            {
                if (IsGameStarted.Equals(false))
                    actionsField.Text += "You didn't start the game!\n";

                else if (userNumberBox.Text.Equals(string.Empty))
                    actionsField.Text += "You didn't enter the number!\n";

                else if (userNumberBox.Text.ToCharArray().Where(i => char.IsLetter(i) || char.IsSymbol(i)).Any())
                    actionsField.Text += "You number contains letters or symbols!\n";

                else if (userNumberBox.Text.Length != 4)
                    actionsField.Text += $"Your number is not foursign!\n";

                else
                {
                    if (!GetBoolsCount(userNumberBox.Text, textBox1.Text).Equals(textBox1.Text.Length))
                        actionsField.Text += $"{userNumberBox.Text} Bools: " +
                            $"{GetBoolsCount(userNumberBox.Text, textBox1.Text)} " +
                            $"Cows: {GetCowsCount(userNumberBox.Text, textBox1.Text)}\n";
                    else
                    {
                        actionsField.Text += "CONGRATULATION, YOU WON!";
                        textBox1.Text = string.Empty;
                        IsGameStarted = false;
                    }
                }
            }

            void ProcessButtonClick(string buttonText)
            {
                int currentCursorPosition = userNumberBox.SelectionStart;
                if (!currentCursorPosition.Equals(userNumberBox.Text.Length))
                {
                    userNumberBox.Text = userNumberBox.Text.Insert(currentCursorPosition, button.Text);
                    userNumberBox.SelectionStart += ++currentCursorPosition;
                    return;
                }

                userNumberBox.Text += button.Text;
                userNumberBox.SelectionStart = userNumberBox.Text.Length;
                userNumberBox.SelectionLength = 0;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // every button must be subscribe to EventHandler class.
            startButton.Click += new EventHandler(ButtonClickHandler);
            button1.Click += new EventHandler(ButtonClickHandler);
            button2.Click += new EventHandler(ButtonClickHandler);
            button3.Click += new EventHandler(ButtonClickHandler);
            button4.Click += new EventHandler(ButtonClickHandler);
            button5.Click += new EventHandler(ButtonClickHandler);
            button6.Click += new EventHandler(ButtonClickHandler);
            button7.Click += new EventHandler(ButtonClickHandler);
            button8.Click += new EventHandler(ButtonClickHandler);
            button9.Click += new EventHandler(ButtonClickHandler);
            delete.Click += new EventHandler(ButtonClickHandler);
            clear.Click   += new EventHandler(ButtonClickHandler);
            checkButton.Click += new EventHandler(ButtonClickHandler);
        }

        private static string GenerateSystemNumber()
        {
            const int NumberLength = 4;
            Random randNumber = new Random();

            return string.Join("", Enumerable.Range(1, 9).OrderBy(x => randNumber.Next()).Take(NumberLength));
        }

        private static int GetBoolsCount(string userNumber, string systemNumber)
        {
            int count = 0;
            for (int i = 0; i < systemNumber.Length; i++)
            {
                count = systemNumber[i].Equals(userNumber[i]) ? ++count : count;
            }
            return count;
        }

        private static int GetCowsCount(string userNumber, string systemNumber)
        {
            int count = 0;
            foreach(var item in systemNumber)
                if(userNumber.Contains(item))
                    count++;
            return count;
        }

    }

    /* 
     
     SET A CODE STRUCTURE AND DO A REFACTORING:
     * class ButtonsHandler - work with buttonsClick event;
     * class GameSession - work with userNumber, systemNumber, actionsField, buttonCheck; 
     
     */

    // WORK ABOUT FORM AND CONTROLS SIZE ALSO COTROLS SCALING DEPEND ON FORM SIZE(solution)

    // PLAY WITH FORM GUI
}
