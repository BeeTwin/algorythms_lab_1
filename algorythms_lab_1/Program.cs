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
            Temp();


            var iterationNumbers = new List<int> { 10, 20, 50, 100, 200, 500, 1000, 2000, 5000, 10000, 20000, 50000, 100000, 200000 };

            foreach (var number in iterationNumbers)
            {
                var testingStructure = new TestingStructure(
                    typeof(Temp),
                    "Tempo",
                    new object[] { number },
                    new object[] { });

                var analyzer = new TimeAnalyzer(testingStructure);

                Out(number, Math.Round(analyzer.Analyze(), 10));
            }

            ForegroundColor = ConsoleColor.Green;
            WriteLine("Analyzation ended successfully.");
            ResetColor();
            ReadKey();
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

        static void Temp()
        {
            var a = new BinaryTree<int>(7);
            a.Add(2);
            a.Add(10);
            a.Add(6);
            a.Add(3);
            a.Add(20);
            a.Add(1);
            a.Add(8);
            a.Add(21);
            a.Add(9);
            a.Add(11);
            a.Add(12);
            a.Add(4);
            a.Add(54);
            a.Add(788);
            a.Add(int.MaxValue);
            var c = a.Contains(7);
            var c2 = a.Contains(20);
            var c1 = a.Contains(13);
        }
    }
}
