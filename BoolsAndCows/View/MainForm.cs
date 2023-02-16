using BoolsAndCows.Presenter;
using System;
using System.Windows.Forms;

namespace BoolsAndCows.View
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // any event that occurs with form will handle by this apropriate object method.
            FormEventsHandler eventsHandler = new FormEventsHandler(this);
            eventsHandler.StartProcessButtonsClicks();
            eventsHandler.StartProcessFormClosing();
            eventsHandler.StartProcessKeysClick();
        }
    }
}
