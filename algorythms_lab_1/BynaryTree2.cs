﻿using System;
using System.Collections.Generic;
using System.Text;

namespace algorythms_lab_1
{
    // C# program to demonstrate delete 
// operation in binary search tree 

	public class BinarySearchTree
	{
		/* Class containing left and right 
		child of current node and key value*/
		class Node
		{
			public int key;
			public Node left, right;

			public Node(int item)
			{
				key = item;
				left = right = null;
			}
		}

		// Root of BST 
		Node root;

		// Constructor 
		public BinarySearchTree(int value)
		{
			AddNRBinarySearchTree(value);
		}

		public void AddNRBinarySearchTree(int value)
		{
			var goal = new BinarySearchTree(value).root;
			var currentNode = root;
			while (currentNode != goal)
				if (value.CompareTo(currentNode.key) >= 0)
					currentNode = (currentNode.right ??= goal);
				else
					currentNode = (currentNode.left ??= goal);
		}

		// This method mainly calls deleteRec() 
		public void deleteKey(int key)
		{
			root = deleteRec(root, key);
		}

		/* A recursive function to insert a new key in BST */
		Node deleteRec(Node root, int key)
		{
			/* Base Case: If the tree is empty */
			if (root == null) return root;

			/* Otherwise, recur down the tree */
			if (key < root.key)
				root.left = deleteRec(root.left, key);
			else if (key > root.key)
				root.right = deleteRec(root.right, key);

			// if key is same as root's key, then This is the node 
			// to be deleted 
			else
			{
				// node with only one child or no child 
				if (root.left == null)
					return root.right;
				else if (root.right == null)
					return root.left;

				// node with two children: Get the 
				// inorder successor (smallest 
				// in the right subtree) 
				root.key = minValue(root.right);

				// Delete the inorder successor 
				root.right = deleteRec(root.right, root.key);
			}
			return root;
		}

		int minValue(Node root)
		{
			int minv = root.key;
			while (root.left != null)
			{
				minv = root.left.key;
				root = root.left;
			}
			return minv;
		}

		// This method mainly calls insertRec() 
		public void insert(int key)
		{
			root = insertRec(root, key);
		}

		/* A recursive function to insert a new key in BST */
		Node insertRec(Node root, int key)
		{

			/* If the tree is empty, return a new node */
			if (root == null)
			{
				root = new Node(key);
				return root;
			}

			/* Otherwise, recur down the tree */
			if (key < root.key)
				root.left = insertRec(root.left, key);
			else if (key > root.key)
				root.right = insertRec(root.right, key);

			/* return the (unchanged) node pointer */
			return root;
		}

		// This method mainly calls InorderRec() 
		void inorder()
		{
			inorderRec(root);
		}

		// A utility function to do inorder traversal of BST 
		void inorderRec(Node root)
		{
			if (root != null)
			{
				inorderRec(root.left);
				Console.Write(root.key + " ");
				inorderRec(root.right);
			}
		}
	}

	// This code has been contributed 
	// by PrinciRaj1992 
	public class GFG
	{
		public Node root;
		// Binary tree node  
		public class Node
		{
			public int key;
			public Node left, right;
			public Node(int data)
			{
				this.key = data;
				left = right = null;
			}
		};

		public GFG(int value)
        {
			AddNRGFG(value);
        }

		// Function to traverse the tree in preorder  
		// and check if the given node exists in it  
		public bool ifNodeExists(Node node, int key)
		{
			if (node == null)
				return false;

			if (node.key == key)
				return true;

			// then recur on left sutree / 
			bool res1 = ifNodeExists(node.left, key);
			if (res1) return true; // node found, no need to look further 

			// node is not found in left, so recur on right subtree / 
			bool res2 = ifNodeExists(node.right, key);

			return res2;
		}

		public void insert(int key)
		{
			root = insertRec(root, key);
		}

		/* A recursive function to insert a new key in BST */
		Node insertRec(Node root, int key)
		{

			/* If the tree is empty, return a new node */
			if (root == null)
			{
				root = new Node(key);
				return root;
			}

			/* Otherwise, recur down the tree */
			if (key < root.key)
				root.left = insertRec(root.left, key);
			else if (key > root.key)
				root.right = insertRec(root.right, key);

			/* return the (unchanged) node pointer */
			return root;
		}

		public void AddNRGFG(int value)
        {
			var goal = new GFG(value).root;
			var currentNode = root;
			while (currentNode != goal)
				if (value.CompareTo(currentNode.key) >= 0)
					currentNode = (currentNode.right ??= goal);
				else
					currentNode = (currentNode.left ??= goal);
		}

	}
}
