using System;
using System.Collections.Generic;
using System.Text;

namespace algorythms_lab_1
{
    public class BinaryTree<T> where T : IComparable
    {
        public T Head;
        public BinaryTree<T> Right;
        public BinaryTree<T> Left;

        public BinaryTree(T head)
        {
            Head = head;
        }

        public BinaryTree(T head, BinaryTree<T> right, BinaryTree<T> left)
            : this(head)
        {
            Right = right;
            Left = left;
        }
    }
}
