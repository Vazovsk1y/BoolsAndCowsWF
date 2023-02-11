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

        // MAKE A BUTTON HANDLER
        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            actionsField.Text += userNumberBox.Text.Equals(string.Empty) ? "You didn't enter the number!\n" : $"{userNumberBox.Text}\n";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int cursorPosition = userNumberBox.SelectionStart;

            // if user add number in some not standart cursor position
            if (!cursorPosition.Equals(userNumberBox.Text.Length))
            {
                userNumberBox.Text = userNumberBox.Text.Insert(cursorPosition, "1");
                userNumberBox.SelectionStart += cursorPosition + 1;
                return;
            }

            // if user add in the end, common click to add the number to the field
            userNumberBox.Text += "1";
            userNumberBox.SelectionStart = userNumberBox.Text.Length;
            userNumberBox.SelectionLength = 0;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int cursorPosition = userNumberBox.SelectionStart;
            userNumberBox.Text = userNumberBox.Text.Insert(cursorPosition, "2");
            userNumberBox.SelectionStart = userNumberBox.Text.Length;
            userNumberBox.SelectionLength = 0;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            int cursorPosition = userNumberBox.SelectionStart;
            userNumberBox.Text = userNumberBox.Text.Insert(cursorPosition, "3");
            userNumberBox.SelectionStart = userNumberBox.Text.Length;
            userNumberBox.SelectionLength = 0;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            int cursorPosition = userNumberBox.SelectionStart;
            userNumberBox.Text = userNumberBox.Text.Insert(cursorPosition, "4");
            userNumberBox.SelectionStart = userNumberBox.Text.Length;
            userNumberBox.SelectionLength = 0;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            int cursorPosition = userNumberBox.SelectionStart;
            userNumberBox.Text = userNumberBox.Text.Insert(cursorPosition, "5");
            userNumberBox.SelectionStart = userNumberBox.Text.Length;
            userNumberBox.SelectionLength = 0;
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            int cursorPosition = userNumberBox.SelectionStart;
            userNumberBox.Text = userNumberBox.Text.Insert(cursorPosition, "6");
            userNumberBox.SelectionStart = userNumberBox.Text.Length;
            userNumberBox.SelectionLength = 0;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int cursorPosition = userNumberBox.SelectionStart;
            userNumberBox.Text = userNumberBox.Text.Insert(cursorPosition, "7");
            userNumberBox.SelectionStart = userNumberBox.Text.Length;
            userNumberBox.SelectionLength = 0;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int cursorPosition = userNumberBox.SelectionStart;
            userNumberBox.Text = userNumberBox.Text.Insert(cursorPosition, "8");
            userNumberBox.SelectionStart = userNumberBox.Text.Length;
            userNumberBox.SelectionLength = 0;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int cursorPosition = userNumberBox.SelectionStart;
            userNumberBox.Text = userNumberBox.Text.Insert(cursorPosition, "9");
            userNumberBox.SelectionStart = userNumberBox.Text.Length;
            userNumberBox.SelectionLength = 0;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            userNumberBox.Text = string.Empty;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (userNumberBox.Text.Equals(string.Empty)) 
                return;

            userNumberBox.Text = userNumberBox.Text.Remove(userNumberBox.Text.Length-1, 1);
        }

        
    }
}
