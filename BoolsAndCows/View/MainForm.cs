using System;
using System.Windows.Forms;
using BoolsAndCows.Presenter;

namespace BoolsAndCows
{
    /* 
      In MainForm class we dont't handle all events that occur with this form, it happens in Presenters Classes 
      with Models classes. So View and Model are not interacting between each other directly, only by Presenter.
    */

    public partial class MainForm : Form
    {
        private FormEventsHandler eventsHandler;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // any event that occurs with form will handle by this apropriate object method.
            eventsHandler = new FormEventsHandler(this);
            eventsHandler.StartProcessButtonsClicks();
            eventsHandler.StartProcessFormClosing();
            eventsHandler.StartProcessKeysClick();
        }
    }
    // PUSH ON GIT 
    // PUSH ON STACK OVERFLOW
}
