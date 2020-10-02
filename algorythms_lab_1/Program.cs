using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static System.Console;

namespace algorythms_lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Temp();


            var iterationNumbers = new List<int> { 10, 20, 50, 100, 200, 500, 1000, 2000, 5000, 10000, 20000, 50000, 100000, 200000 };

            foreach (var number in iterationNumbers)
            {
                var bt = new BinaryTree<int>(new Random().Next(int.MinValue, int.MaxValue));
                for (var i = 0; i < number; i++)
                    while (!bt.Add(new Random().Next(int.MinValue, int.MaxValue)))
                        bt.Add(new Random().Next(int.MinValue, int.MaxValue));

                var testingStructure = new TestingStructure(
                    typeof(BinaryTree<int>),
                    bt,
                    "Add",
                    new object[] { new Random().Next(int.MinValue, int.MaxValue) });

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
            a.Add(1);
            a.Add(10);
            a.Add(4);
            a.Add(3);
            a.Add(2);
            a.Add(9);
            a.Add(2);

        }
    }
}
