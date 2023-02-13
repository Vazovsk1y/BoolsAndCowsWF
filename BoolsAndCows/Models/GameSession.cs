using System;
using System.Linq;

namespace BoolsAndCows.Presenter
{
    internal class GameSession
    {
        private bool isGameStarted = false;
        private string systemNumber;
        private const int NumberLength = 4;
        private int usedHintCount = 0;
        private bool isHintsEnd = false;
        private int stepsCount = 0;

        public int UsedHintsCount
        {
            get => usedHintCount;
        }

        public int StepsCount
        {
            get => stepsCount;
        }

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
            Random randNumber = new Random();
            return string.Join("", Enumerable.Range(1, 9).OrderBy(x => randNumber.Next()).Take(NumberLength));
        }

        public int IncreaseGameSteps(string userBoxText)
        {
            return userBoxText.Where(letter => char.IsLetter(letter) || char.IsSymbol(letter)).Count().Equals(0)
                && userBoxText.Length.Equals(NumberLength) ? ++stepsCount : stepsCount;
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
            stepsCount = 0;
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
            for (int i = 0; i < systemNumber.Length; i++)
                for (int j = 0; j < systemNumber.Length; j++)
                    if (userNumber[i].Equals(systemNumber[j]) && i != j)
                        count++;

            return count;
        }
    }
}
