using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoolsAndCows
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ButtonClickHandler(object sender, EventArgs e)
        {
            Button button = (Button)sender;
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
                    {
                        if (userNumberBox.Text.Equals(string.Empty))
                            return;
                        userNumberBox.Text = userNumberBox.Text.Remove(userNumberBox.Text.Length - 1, 1);
                    }
                    break;
                case "Check":
                    actionsField.Text += userNumberBox.Text.Equals(string.Empty) 
                        ? "You didn't enter the number!\n" : $"{userNumberBox.Text}\n";
                    break;
                default:
                    return;
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

        // BUTTONS HANDLER
        private void MainForm_Load(object sender, EventArgs e)
        {
            // every button must be subscribe to EventHandler class.
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
    }
        
    /* 
    ADD THE LOGICAL PART:
         * searcing bools and cows count depend on user and 
         * generate system number
         * process the next step after winning
         * hand the others type of input data 
    */

    // WORK ABOUT FORM AND CONTROLS SIZE ALSO COTROLS SCALING DEPEND ON FORM SIZE(solution)
    // SET A CODE STRUCTURE AND DO A REFACTORING
    // PLAY WITH FORM GUI
}
