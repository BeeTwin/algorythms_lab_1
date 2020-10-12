using System;
using System.Collections.Generic;
using System.Text;

namespace algorythms_lab_1
{
	public class BinarySearchTree
	{
		public class Node
		{
			public int key;
			public Node left, right;

			public Node(int item)
			{
				key = item;
				left = right = null;
			}

			public Node(Node node)
            {
				key = node.key;
				left = node.left;
				right = node.right;
            }
		}

		Node root;

		public BinarySearchTree(int value)
		{
			root = new Node(value);
		}

		public BinarySearchTree(BinarySearchTree bst)
        {
			root = new Node(bst.root);
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

		public void deleteKey(int key)
		{
			root = deleteRec(root, key);
		}

		Node deleteRec(Node root, int key)
		{
			if (root == null) 
				return root;

			if (key < root.key)
				root.left = deleteRec(root.left, key);
			else if (key > root.key)
				root.right = deleteRec(root.right, key);

			else
			{
				if (root.left == null)
					return root.right;
				else if (root.right == null)
					return root.left;

				root.key = minValue(root.right);

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

		public void insert(int key)
		{
			root = insertRec(root, key);
		}

		Node insertRec(Node root, int key)
		{

			if (root == null)
			{
				root = new Node(key);
				return root;
			}

			if (key < root.key)
				root.left = insertRec(root.left, key);
			else if (key > root.key)
				root.right = insertRec(root.right, key);

			return root;
		}

		void inorder()
		{
			inorderRec(root);
		}

		void inorderRec(Node root)
		{
			if (root != null)
			{
				inorderRec(root.left);
				Console.Write(root.key + " ");
				inorderRec(root.right);
			}
		}

		public bool ifNodeExists(Node node, int key)
		{
			if (node == null)
				return false;

			if (node.key == key)
				return true;

			bool res1 = ifNodeExists(node.left, key);
			if (res1) return true; 
 
			bool res2 = ifNodeExists(node.right, key);

			return res2;
		}
	}
}