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
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // any button clicks on form will handle by this object method.
            FormEventsHandler eventsHandler = new FormEventsHandler(this);
            eventsHandler.StartProcessButtons();
            eventsHandler.StartProcessFormClosing();
        }
    }

    // PLAY WITH FORM GUI
    // PUSH ON GIT 
    // PUSH ON STACK OVERFLOW
}
