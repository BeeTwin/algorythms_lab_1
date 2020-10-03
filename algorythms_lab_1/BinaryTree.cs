using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace algorythms_lab_1
{
    public class BinaryTree<T> where T : IComparable
    {
        public T Head;

        private BinaryTree<T> _right;
        public BinaryTree<T> Right 
        { 
            get => _right; 
            set 
            { 
                _right = value; 
                value.Parent = this; 
            } 
        }

        private BinaryTree<T> _left;
        public BinaryTree<T> Left 
        { 
            get => _left; 
            set 
            { 
                _left = value; 
                value.Parent = this; 
            } 
        }

        public BinaryTree<T> Parent;
        public int Count;

        public BinaryTree(T head)
        {
            Head = head;
            Count = 1;
        }

        private BinaryTree(T head, BinaryTree<T> parent)
            : this(head)
        {
            Parent = parent;
        }

        public BinaryTree(T head, BinaryTree<T> right, BinaryTree<T> left)
            : this(head)
        {
            Right = right;
            Right.Parent = this;
            Left = left;
            Left.Parent = this;
            Count += right.Count + left.Count;
        }

        public void Add(T value)
        {
            var comp = value.CompareTo(Head);

            Count++;
            if (comp >= 0)
                Add(ref _right, value);
            else
                Add(ref _left, value);
        }

        private void Add(ref BinaryTree<T> node, T value)
        {
            if (node != null)
                node.Add(value);
            else
                node = new BinaryTree<T>(value, this);
        }

        public override string ToString() => Head.ToString();

        public bool Contains(T value) => Find(value) != null;

        private BinaryTree<T> Find(T value)
        {
            var comp = value.CompareTo(Head);
            if (comp > 0)
                return Right?.Find(value);
            else if (comp < 0)
                return Left?.Find(value);
            return this;
        }

        public BinaryTree<T> Min() => Left?.Min() ?? this;

        public BinaryTree<T> Max() => Right?.Max() ?? this;


        public bool Remove(T value)
        {
            var f = Find(value);
            if (f == null)
                return false;

            var rightMin = f.Right.Min();
            var left = f.Left;
            rightMin.Left = left;
            var p = f.Parent;

            var cmp = f.Head.CompareTo(p.Head);
            if (cmp >= 0)
                p.Right = f.Right;
            else if (cmp < 0)
                p.Left = f.Right;

            return true;
        }
    }
}