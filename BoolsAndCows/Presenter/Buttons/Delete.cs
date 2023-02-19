using BoolsAndCows.View;

namespace BoolsAndCows.Presenter.Buttons
{
    internal class Delete : GameButtonHandler, IGameButtonHandler
    {
        public Delete(MainForm mainForm, GameSession gameSession) : base(mainForm, gameSession) { }

        public void ProcessButtonClick()
        {
            if (elementsToInterract.userNumberBox.textBox1.Text.Equals(string.Empty))
                return;
            elementsToInterract.userNumberBox.textBox1.Text = elementsToInterract.userNumberBox.textBox1.Text.Remove(elementsToInterract.userNumberBox.textBox1.Text.Length - 1, 1);
            elementsToInterract.userNumberBox.textBox1.SelectionStart = elementsToInterract.userNumberBox.textBox1.Text.Length;
        }
    }
}
