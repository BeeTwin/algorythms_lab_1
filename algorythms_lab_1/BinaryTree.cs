﻿using System;
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

        public void Add(T value)
        {
            var comp = value.CompareTo(Head);

            if (comp > 0)
                Add(ref Right, value);
            else if (comp < 0)
                Add(ref Left, value);
            else
                throw new ArgumentException("The value must be unique.");
        }

        private void Add(ref BinaryTree<T> node, T value)
        {
            if (node != null)            
                node.Add(value);
            else
                node = new BinaryTree<T>(value);
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
