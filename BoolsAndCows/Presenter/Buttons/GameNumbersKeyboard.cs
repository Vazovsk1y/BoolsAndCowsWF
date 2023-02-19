using BoolsAndCows.View;

namespace BoolsAndCows.Presenter.Buttons
{
    internal class GameNumbersKeyboard 
    {
        private MainForm ElementsToInterract { get; }

        public GameNumbersKeyboard(MainForm currentForm)
        {
            ElementsToInterract = currentForm;
        }

        public void ProcessButtonClick(string buttonText)   
        {
            int currentCursorPosition = ElementsToInterract.userNumberBox.textBox1.SelectionStart;
            if (!currentCursorPosition.Equals(ElementsToInterract.userNumberBox.textBox1.Text.Length))
            {
                ElementsToInterract.userNumberBox.textBox1.Text = ElementsToInterract.userNumberBox.textBox1.Text.Insert(currentCursorPosition, buttonText);
                ElementsToInterract.userNumberBox.textBox1.SelectionStart += ++currentCursorPosition;
                return;
            }

            ElementsToInterract.userNumberBox.textBox1.Text += buttonText;
            ElementsToInterract.userNumberBox.textBox1.SelectionStart = ElementsToInterract.userNumberBox.textBox1.Text.Length;
            ElementsToInterract.userNumberBox.textBox1.SelectionLength = 0;
        }
    }
}
