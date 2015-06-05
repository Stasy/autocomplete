using System;
using System.Collections.Generic;
using System.IO;

namespace autocomplete
{
    public class Input
    {
        public int WordsCount { get; private set; }
        public Dictionary<string, Int32> WordsAndFrequency { get; set; }
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
        }

        public void GetDataIn(){
            
            WordsCount = Convert.ToInt32(readLine());

            WordsAndFrequency = new Dictionary<string, int>();
            for (var i = 0; i < WordsCount; i++)
            {
                var parsedLine = readLine().Split(new[] { ' ' });
                WordsAndFrequency.Add(parsedLine[0], Convert.ToInt32(parsedLine[1]));
            }

            UnitsCount = Convert.ToInt32(readLine());

            Units = new string[UnitsCount];
            for (var j = 0; j < UnitsCount; j++)
                Units[j] = readLine();
        }
    }
}
