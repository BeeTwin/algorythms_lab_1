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
            Temp();
            foreach (var count in _counts)
            {
                var bt = new BinaryTree<int>(new Random().Next(int.MinValue, int.MaxValue));
                for (var i = 0; i < count; i++)
                    bt.AddNR(new Random().Next(int.MinValue, int.MaxValue));

                var analyzer = new TimeAnalyzer(
                    new TestingStructure(typeof(BinaryTree<int>), bt, "RemoveNR"));
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
            var a = new BinarySearchTree(7);
            a.AddNRBinarySearchTree(1);
            a.AddNRBinarySearchTree(2);
            
            var a14 = new TestingStructure(typeof(BinarySearchTree), a, "deleteKey");
            a14.Test(new object[] { 1 });
            a14.Refresh();
            a14.Test(new object[] { 1 });
            a14.Test(new object[] { 1 });
            a14.Test(new object[] { 1 });
            a14.Test(new object[] { 1 });
            a14.Test(new object[] { 1 });
            a14.Refresh();
        }

        //0 - лучший случай, 1 - средний случай, 2 - худший случай

        public BinarySearchTree InitializeBinarySearchTree(int idenify, int size)
        {
            var bST = new BinarySearchTree(0);
            if (idenify == 0)
                for (var i = 0; i < size - 1; i++)
                    bST.AddNRBinarySearchTree(new Random().Next(int.MinValue, int.MaxValue));
            else if (idenify == 1)
                for (var i = 0; i < size - 1; i++)
                    bST.AddNRBinarySearchTree(new Random().Next(int.MinValue, int.MaxValue));
            else if (idenify == 2)
                for (var i = 0; i < size - 1; i++)
                   bST.AddNRBinarySearchTree(i);
            return bST;
        }

        public BinaryTree<int> InitializeBinaryTree(int idenify, int size)
        {
            var bT = new BinaryTree<int>(0);
            if (idenify == 0)
                for (var i = 0; i < size - 1; i++)
                    bT.AddNR(new Random().Next(int.MinValue, int.MaxValue));
            else if (idenify == 1)
                for (var i = 0; i < size - 1; i++)
                    bT.AddNR(new Random().Next(int.MinValue, int.MaxValue));
            else if (idenify == 2)
                for (var i = 0; i < size - 1; i++)
                    bT.AddNR(i);
            return bT;
        }
    }
}
