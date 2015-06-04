using System.Collections.Generic;
using System.Linq;

namespace autocomplete
{
    public class Sort
    {
        private const int maxWordLenght = 15;
        private const int charackterLenght = 26;

        private int[] wordTracker { get; set; }
        private int[,] letterTracker { get; set; }
        private char[] latinCharackter { get; set; }

        public void SortWordsDictionary(int wordsCount, Dictionary<string, int> wordsAndFrequency)
        {
            wordTracker = new int[wordsCount];
            letterTracker = SetDefaultLetterTracker();
            latinCharackter = SetLatinCharacter();

            var i = 0;
            foreach (var word in wordsAndFrequency)
            {
                for (var j = 0; j < latinCharackter.Length; j++)
                {
                    if (word.Key[0] == latinCharackter[j])
                    {
                        wordTracker[i] = letterTracker[0,j];
                        letterTracker[0,j] = i;
                    }
                }
                i++;
            }
        }

        private int[,] SetDefaultLetterTracker()
        {
            letterTracker = new int[maxWordLenght, charackterLenght];

            for (var i = 0; i < maxWordLenght; i++)
                for (var j = 0; j < charackterLenght; j++)
                    letterTracker[i,j] = 0;

            return letterTracker;
        }

        private char[] SetLatinCharacter()
        {
            latinCharackter = new char[charackterLenght];

            latinCharackter[0] = 'a';
            latinCharackter[1] = 'b';
            latinCharackter[2] = 'c';
            latinCharackter[3] = 'd';
            latinCharackter[4] = 'e';
            latinCharackter[5] = 'f';
            latinCharackter[6] = 'g';
            latinCharackter[7] = 'h';
            
            latinCharackter[8] = 'i';
            latinCharackter[9] = 'j';
            latinCharackter[10] = 'k';
            latinCharackter[11] = 'l';
            latinCharackter[12] = 'm';
            latinCharackter[13] = 'n';
            latinCharackter[14] = 'o';
            latinCharackter[15] = 'p';
            
            latinCharackter[16] = 'q';
            latinCharackter[17] = 'r';
            latinCharackter[18] = 's';
            latinCharackter[19] = 't';
            latinCharackter[20] = 'u';
            latinCharackter[21] = 'v';
            latinCharackter[22] = 'w';
            latinCharackter[23] = 'x';
            
            latinCharackter[24] = 'y';
            latinCharackter[25] = 'z';

            return latinCharackter;
        }
    }
}
