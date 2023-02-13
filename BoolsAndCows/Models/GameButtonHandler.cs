using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoolsAndCows.Models
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
