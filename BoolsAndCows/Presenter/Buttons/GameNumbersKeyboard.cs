
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
            int currentCursorPosition = ElementsToInterract.userNumberBox.SelectionStart;
            if (!currentCursorPosition.Equals(ElementsToInterract.userNumberBox.Text.Length))
            {
                ElementsToInterract.userNumberBox.Text = ElementsToInterract.userNumberBox.Text.Insert(currentCursorPosition, buttonText);
                ElementsToInterract.userNumberBox.SelectionStart += ++currentCursorPosition;
                return;
            }

            ElementsToInterract.userNumberBox.Text += buttonText;
            ElementsToInterract.userNumberBox.SelectionStart = ElementsToInterract.userNumberBox.Text.Length;
            ElementsToInterract.userNumberBox.SelectionLength = 0;
        }
    }
}
