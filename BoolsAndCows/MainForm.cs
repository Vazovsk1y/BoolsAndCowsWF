using System;
using System.Windows.Forms;

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
            ButtonsHandler buttonHandler = new ButtonsHandler(this);
            buttonHandler.StartButtonHandler();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure that want to quit?",
                "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult.Equals(DialogResult.No))
                e.Cancel = true;
        }
    }

    // HOW TO HANDLE THE FORM CLOSING WHILE GAME IS PLAYING.

    // WORK ABOUT FORM AND CONTROLS SIZE ALSO COTROLS SCALING DEPEND ON FORM SIZE(solution)

    // PLAY WITH FORM GUI
}
