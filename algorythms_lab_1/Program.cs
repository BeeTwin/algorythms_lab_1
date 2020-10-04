﻿using System;
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
            Temp();


            var iterationNumbers = new List<int> 
            { 
                100, 10000, 1000000
            };

            foreach (var number in iterationNumbers)
            {
                var btAverage = new GFG();
                for (var i = 0; i < number; i++)
                {
                    btAverage.insert(i);
                }



                var testingStructure = new TestingStructure(    
                    typeof(GFG),
                    btAverage,
                    "ifNodeExists",
                    new object[] { btAverage.root, number + 1});

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
            var a2 = new BinaryTree<int>(10);
            var a3 = new BinaryTree<int>(1);
            var a4 = new BinaryTree<int>(7, a2, a3);
            a.Add(1);
            a.Add(10);
            a.Add(10);
            a.Add(10);
            a.Add(10);
            a.Add(4);
            a.Add(3);
            a.Add(2);
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
            a.Remove(10);
            var c5e = a.Contains(11);
        }
    }
}
