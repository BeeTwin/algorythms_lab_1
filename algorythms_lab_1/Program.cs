using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using static System.Console;

namespace algorythms_lab_1
{
    class Program
    {
        private static readonly List<int> _counts = new List<int>
        {
            100, 100, 100, 10000, 1000000
        };
        private static readonly float _iterations = 1000000;

        static void Main(string[] args)
        {
            foreach (var count in _counts)
            {
                var bt = new BinaryTree<int>(new Random().Next(int.MinValue, int.MaxValue));
                for (var i = 0; i < count; i++)
                    bt.AddNR(new Random().Next(int.MinValue, int.MaxValue));

                var analyzer = new TimeAnalyzer(
                    new TestingStructure(typeof(BinaryTree<int>), bt, "ContainsNR"));
                Out(count, Math.Round(Analyze(analyzer), 10));
            }

            ForegroundColor = ConsoleColor.Green;
            WriteLine("Analyzation ended successfully.");
            ResetColor();
            ReadKey();
        }

        private static double Analyze(TimeAnalyzer analyzer)
        {
            double result = 0;
            for (var i = 0; i < _iterations; i++)
                result += analyzer.Analyze(
                    new object[] { new Random().Next(int.MinValue, int.MaxValue) },
                    false);

            return result / _iterations;
        }

        private static void Out(int number, double time)
        {
            Write($"Structure size:\t");
            ForegroundColor = ConsoleColor.Blue;
            Write($"{number}");
            ResetColor();
            Write($"\tTotal milliseconds: \t");
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
            a.AddNR(4);
            a.AddNR(3);
            a.AddNR(2);
            a.AddNR(9);
            a.AddNR(12);
            a.AddNR(11);
            a.AddNR(4);
            a.AddNR(54);
            a.AddNR(788);
            a.AddNR(int.MaxValue);
            var c = a.ContainsNR(7);
            var c2 = a.ContainsNR(20);
            var c1 = a.ContainsNR(13);
            var c3 = a.ContainsNR(4);
            a.RemoveNR(10);
            var c5e = a.ContainsNR(11);
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
