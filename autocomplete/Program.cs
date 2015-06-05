using System;
using autocomplete;

namespace Autocomplete
{
    static class Program
    {
        static void Main(string[] args)
        {
            var input = new Input();
            var sort = new Sort();
            var search = new Search();

            input.GetDataIn();

            input.WordsAndFrequency = sort.SortWordsDictionary(input.WordsCount, input.WordsAndFrequency);

            foreach (var unit in input.Units)
            {
                var resultForCurrentUnit = search.TryFindWordsForUnit(input.WordsCount, input.WordsAndFrequency, unit);

                if (resultForCurrentUnit.Length > 0)
                {
                    Console.WriteLine("{0}", String.Join("\n", resultForCurrentUnit));
                    Console.WriteLine("\n");
                }
            }

            //Console.ReadKey();
        }
    }
}
