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
            Temp();


            var iterationNumbers = new List<int> 
            { 
                100, 10000, 1000000
            };

            foreach (var number in iterationNumbers)
            {
                var btAverage = new GFG(0);
                for (var i = 0; i < number; i++)
                {
                    btAverage.AddNRGFG(i);
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
            a.AddNR(1);
            a.AddNR(10);
            a.AddNR(10);
            a.AddNR(10);
            a.AddNR(10);
            a.AddNR(4);
            a.AddNR(3);
            a.AddNR(2);
            a.AddNR(9);
            a.AddNR(11);
            a.AddNR(12);
            a.AddNR(4);
            a.AddNR(54);
            a.AddNR(788);
            a.AddNR(int.MaxValue);
            var c = a.Contains(7);
            var c2 = a.Contains(20);
            var c1 = a.Contains(13);
            a.Remove(10);
            var c5e = a.Contains(11);
        }

        //0 - лучший случай, 1 - средний случай, 2 - худший случай
        public GFG InitializeGFG(int idenify, int size) 
        {
            var gFG = new GFG(0);
            if(idenify == 0)
            {
                for (var i = 0; i < size - 1; i++)
                {
                    gFG.AddNRGFG(new Random().Next(int.MinValue, int.MaxValue));
                }
            }
            else if(idenify == 1)
            {
                for(var i = 0; i < size - 1; i++)
                {
                    gFG.AddNRGFG(new Random().Next(int.MinValue, int.MaxValue));
                }
            }
            else if(idenify == 2)
            {
                for (var i = 0; i < size - 1; i++)
                {
                    gFG.AddNRGFG(i);
                }
            }
            return gFG;
        }

        public BinarySearchTree InitializeBinarySearchTree(int idenify, int size)
        {
            var bST = new BinarySearchTree(0);
            if (idenify == 0)
            {
                for (var i = 0; i < size - 1; i++)
                {
                    bST.AddNRBinarySearchTree(new Random().Next(int.MinValue, int.MaxValue));
                }
            }
            else if (idenify == 1)
            {
                for (var i = 0; i < size - 1; i++)
                {
                    bST.AddNRBinarySearchTree(new Random().Next(int.MinValue, int.MaxValue));
                }
            }
            else if (idenify == 2)
            {
                for (var i = 0; i < size - 1; i++)
                {
                   bST.AddNRBinarySearchTree(i);
                }
            }
            return bST;
        }

        public BinaryTree<int> InitializeBinaryTree(int idenify, int size)
        {
            var bT = new BinaryTree<int>(0);
            if (idenify == 0)
            {
                for (var i = 0; i < size - 1; i++)
                {
                    bT.AddNR(new Random().Next(int.MinValue, int.MaxValue));
                }
            }
            else if (idenify == 1)
            {
                for (var i = 0; i < size - 1; i++)
                {
                    bT.AddNR(new Random().Next(int.MinValue, int.MaxValue));
                }
            }
            else if (idenify == 2)
            {
                for (var i = 0; i < size - 1; i++)
                {
                    bT.AddNR(i);
                }
            }
            return bT;
        }
    }
}
