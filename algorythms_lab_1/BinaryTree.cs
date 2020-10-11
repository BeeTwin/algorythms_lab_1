﻿using System;

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

        public bool ContainsNR(T value) => FindNR(value) != null;

        public BinaryTree<T> FindNR2(T value)
        {
            var node = this;
            while(node != null)
            {
                var comp = value.CompareTo(node.Head);
                if (comp == 0)
                    break;
                else if (comp > 0)
                    node = node.Right;
                else
                    node = node.Left;
            }
            return node;
        }

        public BinaryTree<T> FindNR(T value)
        {
            var currentNode = this;
            int cmp;
            while (currentNode != null)
                if ((cmp = value.CompareTo(currentNode.Head)) > 0)
                    currentNode = currentNode.Right;
                else if (cmp < 0)
                    currentNode = currentNode.Left;
                else
                    break;
            return currentNode;
        }


        public BinaryTree<T> Min() => Left?.Min() ?? this;

        public BinaryTree<T> MinNR()
        {
            var currentNode = this;
            while (currentNode.Left != null)
                currentNode = currentNode.Left;
            return currentNode;
        }

        public BinaryTree<T> Max() => Right?.Max() ?? this;

        public BinaryTree<T> MaxNR()
        {
            var currentNode = this;
            while (currentNode.Right != null)
                currentNode = currentNode.Right;
            return currentNode;
        }

        public void Remove(T value)
        {
            var removing = Find(value);
            if (removing == null)
                return;

            var rightMin = removing.Right?.Min() ?? removing;
            var left = removing.Left;
            rightMin.Left = left;
            var parent = removing.Parent;

            var cmp = removing.Head.CompareTo(parent.Head);
            if (cmp >= 0)
                parent.Right = removing.Right;
            else
                parent.Left = removing.Right;
        }

        public void RemoveNR(T value)
        {
            var removing = FindNR(value);
            if (removing == null)
                return;

            (removing.Right?.MinNR() ?? removing).Left = removing.Left;

            var cmp = removing.Head.CompareTo(removing.Parent.Head);
            if (cmp >= 0)
                removing.Parent.Right = removing.Right;
            else
                removing.Parent.Left = removing.Right;
        }
    }
}