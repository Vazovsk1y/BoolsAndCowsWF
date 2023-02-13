using BoolsAndCows.Presenter;

namespace BoolsAndCows.Presenter.Buttons
{
    internal class Delete : GameButtonHandler, IGameButtonHandler
    {
        public Delete(MainForm mainForm, GameSession gameSession) : base(mainForm, gameSession) { }

        public void ProcessButtonClick()
        {
            if (elementsToInterract.userNumberBox.Text.Equals(string.Empty))
                return;
            elementsToInterract.userNumberBox.Text = elementsToInterract.userNumberBox.Text.Remove(elementsToInterract.userNumberBox.Text.Length - 1, 1);
            elementsToInterract.userNumberBox.SelectionStart = elementsToInterract.userNumberBox.Text.Length;
        }
    }
}
