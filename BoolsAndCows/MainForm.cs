using System;
using System.Windows.Forms;
using BoolsAndCows.Controls;
using BoolsAndCows.Controls.Buttons;

namespace BoolsAndCows
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FormButtonsHandler buttonHandler = new FormButtonsHandler(this);   // any button clicks on form will handle by this object.
            buttonHandler.ProcessButtons();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure that want to quit?",
                "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult.Equals(DialogResult.No))
                e.Cancel = true;
        }
    }

    // PLAY WITH FORM GUI
}
