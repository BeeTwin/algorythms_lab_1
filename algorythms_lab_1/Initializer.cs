using System;
using System.Collections.Generic;
using System.Text;

namespace algorythms_lab_1
{
    public enum Case
    {
        Best, Average, Worst
    };

    public static class Initializer
    {
        public static BinarySearchTree InitializeBinarySearchTree(Case @case, int size)
        {
            var bST = new BinarySearchTree(0);
            switch (@case)
            {
                case Case.Best:
                    bST.AddNRBinarySearchTree(-1);
                    for (var i = 0; i < size - 2; i++)
                        bST.AddNRBinarySearchTree(i);
                    break;
                case Case.Average:
                for (var i = 0; i < size - 1; i++)
                    bST.AddNRBinarySearchTree(new Random().Next(int.MinValue, int.MaxValue));
                    break;
                case Case.Worst:
                for (var i = 0; i < size - 1; i++)
                    bST.AddNRBinarySearchTree(i);
                    break;
            }
            return bST;
        }

        public static BinaryTree<int> InitializeBinaryTree(Case @case, int size)
        {
            var bT = new BinaryTree<int>(0);
            switch (@case)
            {
                case Case.Best:
                    bT.AddNR(-1);
                    for (var i = 0; i < size - 2; i++)
                        bT.AddNR(i);
                    break;
                case Case.Average:
                    for (var i = 0; i < size - 1; i++)
                        bT.AddNR(new Random().Next(int.MinValue, int.MaxValue));
                    break;
                case Case.Worst:
                    for (var i = 0; i < size - 1; i++)
                        bT.AddNR(i);
                    break;
            }
            return bT;
        }
    }
}
