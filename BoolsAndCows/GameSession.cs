using System;
using System.Linq;

namespace BoolsAndCows
{

    internal class GameSession
    {
        private bool isGameStarted = false;
        private string systemNumber;

        public bool IsGameStarted
        { 
            get => isGameStarted;
        }

        public string SystemNumber
        {
            get => systemNumber;
        }

        private string GenerateSystemNumber()
        {
            const int NumberLength = 4;
            Random randNumber = new Random();

            return string.Join("", Enumerable.Range(1, 9).OrderBy(x => randNumber.Next()).Take(NumberLength));
        }

        public void Start()
        {
            isGameStarted = true;
            systemNumber = GenerateSystemNumber();
        }

        public void Stop()
        {
            isGameStarted = false;
        }

        public int GetBoolsCount(string userNumber, string systemNumber)
        {
            int count = 0;
            for (int i = 0; i < systemNumber.Length; i++)
            {
                count = systemNumber[i].Equals(userNumber[i]) ? ++count : count;
            }
            return count;
        }

        public int GetCowsCount(string userNumber, string systemNumber)
        {
            int count = 0;
            foreach (var item in systemNumber)
                if (userNumber.Contains(item))
                    count++;
            return count;
        }
    }
}
