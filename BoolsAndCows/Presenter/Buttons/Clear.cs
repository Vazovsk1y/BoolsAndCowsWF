using BoolsAndCows.Presenter;

namespace BoolsAndCows.Presenter.Buttons
{
    internal class Clear : GameButtonHandler, IGameButtonHandler
    {
        public Clear(MainForm elementsToInteractWith, GameSession gameSession) : base(elementsToInteractWith, gameSession) { }

        public void ProcessButtonClick()
        {
            elementsToInterract.userNumberBox.Text = string.Empty;
        }
    }
}
