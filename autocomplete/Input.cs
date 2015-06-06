using System;
using System.IO;

namespace autocomplete
{
    public class Input
    {
        public int WordsCount { get; private set; }
        public string[] Words { get; set; }
        public int[] Frequency { get; set; }
        private int UnitsCount { get; set; }
        public string[] Units { get; private set; }
        private Func<string> readLine { get; set; }
        
        public Input()
        {
            //определяем метод чтения
            var path = @Environment.CurrentDirectory + @"\test.in";
            if (File.Exists(path))
            {
                var stream = new StreamReader(path);
                readLine = stream.ReadLine;
            } else 
                readLine = Console.ReadLine;

            //Считываем данные
            WordsCount = Convert.ToInt32(readLine());

            Words = new string[WordsCount];
            Frequency = new int[WordsCount];

            for (var i = 0; i < WordsCount; i++)
            {
                var parsedLine = readLine().Split(new[] { ' ' });

                Words[i] = parsedLine[0];
                Frequency[i] = Convert.ToInt32(parsedLine[1]);
            }

            UnitsCount = Convert.ToInt32(readLine());

            Units = new string[UnitsCount];
            for (var j = 0; j < UnitsCount; j++)
                Units[j] = readLine();
        }
    }
}
