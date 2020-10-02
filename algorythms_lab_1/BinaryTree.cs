using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public bool Add(T value)
        {
            var comp = value.CompareTo(Head);

            if (comp > 0)
                return _Add(ref Right, value);
            else if (comp < 0)
                return _Add(ref Left, value);
            else
                return false;
        }
        private bool _Add(ref BinaryTree<T> node, T value)
        {
            if (node != null)
                return node.Add(value);
            else
            {
                node = new BinaryTree<T>(value);
                return true;
            }
        }

        public override string ToString() => Head.ToString();
    }
}
