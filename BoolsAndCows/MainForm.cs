using System;
using System.Windows.Forms;
using BoolsAndCows.Controls;
using BoolsAndCows.Controls.Buttons;

namespace BoolsAndCows
{
    /* 
      In MainForm class we handle all events that occur with this form.
    */

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // any button clicks on form will handle by this object method.
            FormButtonsHandler buttonHandler = new FormButtonsHandler(this);   
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
