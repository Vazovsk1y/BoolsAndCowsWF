using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BoolsAndCows.Presenter.Buttons;

namespace BoolsAndCows.Presenter
{
    internal class FormEventsHandler
    {
        private GameSession GameSession { get; } = new GameSession();
        private List<Button> Buttons { get; }
        private MainForm ElementsToInterract { get; }

        public FormEventsHandler(MainForm mainForm)
        {
            Buttons = mainForm.Controls.OfType<Button>().ToList();
            ElementsToInterract = mainForm;
        }

        public void StartProcessButtons()
        {
            foreach (Button button in Buttons)
            {
                button.Click += new EventHandler(ButtonClickHandler);
            }
        }

        public void StartProcessFormClosing()
        {
            ElementsToInterract.FormClosing += new FormClosingEventHandler(FormClosingHandler);
        }

        private void FormClosingHandler(object sender, FormClosingEventArgs e)
        {
            if(GameSession.IsGameStarted)
            {
                DialogResult dialogResult = MessageBox.Show("Game is not ending.\nAre you sure that want to quit?\n",
                     "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult.Equals(DialogResult.No))
                    e.Cancel = true;
            }
        }

        private void ButtonClickHandler(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            List<string> numberWritingButtons = new List<string>()
            { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            foreach (string item in numberWritingButtons)
            {
                if (item.Equals(button.Text))
                {
                    GameNumbersKeyboard keyboard = new GameNumbersKeyboard(ElementsToInterract);
                    keyboard.ProcessButtonClick(button.Text);
                    return;
                }
            }

            var gameButtons = new Dictionary<string, IGameButtonHandler>()
            {
                {"Start", new Start(ElementsToInterract, GameSession)},
                {"Hint" , new Hint(ElementsToInterract, GameSession)},
                {"Clear", new  Clear(ElementsToInterract, GameSession) },
                {"<=", new  Delete(ElementsToInterract, GameSession)},
                { "Check", new Check(ElementsToInterract, GameSession) }
            };

            foreach (var item in gameButtons)
                if (button.Text.Equals(item.Key))
                    item.Value.ProcessButtonClick();
        }
    }
}
