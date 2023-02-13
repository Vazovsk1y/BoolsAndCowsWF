using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BoolsAndCows.Controls.Buttons;
using BoolsAndCows;
using BoolsAndCows.Models;

namespace BoolsAndCows.Controls
{
    internal class FormButtonsHandler
    {
        private GameSession GameSession { get; } = new GameSession();
        private List<Button> Buttons { get; }
        private MainForm ElementsToInterract { get; }

        public FormButtonsHandler(MainForm mainForm)
        {
            Buttons = mainForm.Controls.OfType<Button>().ToList();
            ElementsToInterract = mainForm;
        }

        public void ProcessButtons()
        {
            foreach (Button button in Buttons)
            {
                button.Click += new EventHandler(ButtonClickHandler);
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
