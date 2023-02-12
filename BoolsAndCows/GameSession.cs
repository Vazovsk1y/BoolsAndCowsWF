using System;
using System.Linq;

namespace BoolsAndCows
{

    internal class GameSession
    {
        private bool isGameStarted = false;
        private string systemNumber;
        private int usedHintCount = 0;
        private bool isHintsEnd = false;

        public bool IsHintsEnd
        {
            get
            {
                if (usedHintCount == 3)
                    isHintsEnd = true;
                return isHintsEnd;
            }
        }

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

        public string GetHint(string currentNumber)
        {
            var symbols = currentNumber.ToCharArray();
            var hintNumber = SystemNumber[usedHintCount];
            symbols[usedHintCount] = hintNumber;
            usedHintCount++;

            return new string(symbols);
        }

        public void Start()
        {
            isGameStarted = true;
            systemNumber = GenerateSystemNumber();
        }

        public void Stop()
        {
            isGameStarted = false;
            usedHintCount = 0;
            isHintsEnd = false;
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
