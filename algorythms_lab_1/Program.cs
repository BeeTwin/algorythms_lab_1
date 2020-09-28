using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace algorythms_lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var iterationNumbers = new List<int> { 1, 2, 5, 10, 20, 50, 100, 150, 500, 1000, 5000, 10000, 50000, 200000 };

            foreach(var number in iterationNumbers)
            {
                var testingStructure = new TestingStructure(
                    typeof(Temp),
                    "Tempo",
                    new object[] { number },
                    new object[] { });

                var analyzer = new TimeAnalyzer(testingStructure);

                Out(number, Math.Round(analyzer.Analyze(), 10));
            }   
        }

        static void Out(int number, double time)
        {
            Write($"Structure size:\t");
            ForegroundColor = ConsoleColor.Blue;
            Write($"{number}");
            ResetColor();
            Write($"\tTotal seconds: \t");
            ForegroundColor = ConsoleColor.Red;
            WriteLine($"{time}");
            ResetColor();
        }
    }
}
