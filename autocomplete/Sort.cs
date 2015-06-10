using System;
using System.Threading;

namespace autocomplete
{
    public class Sort
    {
        private Input DataIn { get; set; }
        
        private const int maxWordLenght = 15;
        private const int charackterLenght = 26;

        private int[] wordTracker { get; set; }
        private int[,] letterTracker { get; set; }
        private char[] latinCharackter { get; set; }

        public string[] sortedWords { get; private set; }
        public int[] sortedFrequency { get; private set; }

        public void SortWordsAndFrequency(Input dataIn)
        {
            DataIn = dataIn;

            wordTracker = new int[DataIn.WordsCount];
            letterTracker = new int[maxWordLenght, charackterLenght];
            latinCharackter = new char[charackterLenght];

            SetDefaultLetterTracker();
            SetLatinCharacter();

            for (var i = 0; i < maxWordLenght; i++)
            {
                int i1 = i;
                var InstanceCaller = new Thread(
                    () => SortForCurrentDigit(i1), 4194304);
                InstanceCaller.Start();

                //подумать, нужно ли останавливать поток
            }
        }

        private void SortForCurrentDigit(int digit)
        {
            Array.Clear(wordTracker, 0, wordTracker.Length);

            for(var i = 0; i < DataIn.WordsCount; i++)
            {
                var word = DataIn.Words[i];

                if (word.Length > digit)
                {
                    for (var j = 0; j < latinCharackter.Length; j++)
                    {
                        if (word[digit] == latinCharackter[j])
                        {
                            wordTracker[i] = letterTracker[digit, j];
                            letterTracker[digit, j] = i;
                        }
                    }
                }
            }

            //сортировка
            sortedWords = new string[DataIn.WordsCount];
            sortedFrequency = new int[DataIn.WordsCount];

            var counter = 0;

            for (var j = 0; j < latinCharackter.Length; j++)
            {
                var lastWordIndex = letterTracker[digit, j];

                //взять по lastWordIndex индексу пару из wordsAndFrequency
                sortedWords[counter] = DataIn.Words[lastWordIndex];
                sortedFrequency[counter] = DataIn.Frequency[lastWordIndex];
                counter++;

                //затем взять из wordTracker элемент с индексом lastWordIndex - это и будет индекс следующей пары
                //затем взять из wordTracker элемент с индексом из предыдущей строки - содержимое и будет индексом слледующего слова
                //обернуть это в рекурсию и продолжать пока содержимое wordTracker не будет = 0

                recursiya(lastWordIndex, counter);
            }
        }

        private void recursiya(int index, int counter)
        {
            var currentIndex = wordTracker[index];
            sortedWords[counter] = DataIn.Words[currentIndex];
            sortedFrequency[counter] = DataIn.Frequency[currentIndex];

            counter++;
            if (currentIndex != 0)
                recursiya(currentIndex, counter);
        }

        private void SetDefaultLetterTracker()
        {
            for (var i = 0; i < maxWordLenght; i++)
                for (var j = 0; j < charackterLenght; j++)
                    letterTracker[i,j] = 0;
        }

        private void SetLatinCharacter()
        {
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
        }
    }
}
