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
        public int Count;

        public BinaryTree(T head)
        {
            Head = head;
            Count = 1;
        }

        public BinaryTree(T head, BinaryTree<T> right, BinaryTree<T> left)
            : this(head)
        {
            Right = right;
            Left = left;
            Count += right.Count + left.Count;
        }

        public bool Add(T value)
        {
            var comp = value.CompareTo(Head);

            Count++;
            if (comp > 0)
                return Add(ref Right, value);
            else if (comp < 0)
                return Add(ref Left, value);
            else
            {
                Count--;
                return false;
            }
        }
        private bool Add(ref BinaryTree<T> node, T value)
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

        public bool Contains(T value)
        {
            var comp = value.CompareTo(Head);
            if (comp > 0)
                return Right?.Contains(value) ?? false;
            else if (comp < 0)
                return Left?.Contains(value) ?? false;
            return true;
        }

        public void Remove(T value)
        { 
            //if(this.Contains(value))

        }
    }
}
