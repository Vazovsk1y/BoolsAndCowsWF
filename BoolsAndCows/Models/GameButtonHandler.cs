using BoolsAndCows.View;

namespace BoolsAndCows.Presenter
{
    abstract class GameButtonHandler
    {
        protected MainForm elementsToInterract;
        protected GameSession gameSession;

        protected GameButtonHandler(MainForm elementsToInterract, GameSession gameSession)
        {
            this.elementsToInterract = elementsToInterract;
            this.gameSession = gameSession;
        }
    }
}
