using System.Collections.Generic;
using System.Linq;

namespace autocomplete
{
    public class Sort
    {
        private int[] wordTracker { get; set; }
        private int[] letterTracker { get; set; }
        private char[] latinCharackter { get; set; }

        public void SortWordsDictionary(int wordsCount, Dictionary<string, int> wordsAndFrequency)
        {
            wordTracker = new int[wordsCount];
            letterTracker = SetDefaultLetterTracker();
            latinCharackter = SetLatinCharacter();
            
            for (var i = 0; i < wordsAndFrequency.Count; i++)
            {
                var currentWord = wordsAndFrequency.ElementAt(1).Key;

                for (var j = 0; j < latinCharackter.Length; j++)
                {
                    if (currentWord[0] == latinCharackter[j])
                    {
                        wordTracker[i] = letterTracker[j];
                        letterTracker[j] = i;
                    }
                }
            }
        }

        private int[] SetDefaultLetterTracker()
        {
            letterTracker = new int[26];

            for (var i = 0; i < letterTracker.Length; i++)
                letterTracker[i] = 0;

            return letterTracker;
        }

        private char[] SetLatinCharacter()
        {
            latinCharackter = new char[26];

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
