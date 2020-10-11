using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace algorythms_lab_1
{
    public class BinaryTree<T> where T : IComparable
    {
        public T Head;
        public BinaryTree<T> Parent;

        private BinaryTree<T> _right;
        public BinaryTree<T> Right 
        { 
            get => _right; 
            set 
            { 
                _right = value; 
                if(value != null)
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
                if (value != null)
                    value.Parent = this;
            }
        }

        public BinaryTree(T head)
        {
            Head = head;
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
        }

        public void AddNR(T value)
        {
            var goal = new BinaryTree<T>(value);
            var currentNode = this;
            while(currentNode != goal)
                if (value.CompareTo(currentNode.Head) >= 0)
                    currentNode = (currentNode.Right ??= goal);
                else
                    currentNode = (currentNode.Left ??= goal);
        }

        public void Add(T value)
        {
            var comp = value.CompareTo(Head);

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
            var removing = Find(value);
            if (removing == null)
                return false;

            var rightMin = removing.Right?.Min() ?? removing;
            var left = removing.Left;
            rightMin.Left = left;
            var parent = removing.Parent;

            var cmp = removing.Head.CompareTo(parent.Head);
            if (cmp >= 0)
                parent.Right = removing.Right;
            else
                parent.Left = removing.Right;

            return true;
        }
    }
}