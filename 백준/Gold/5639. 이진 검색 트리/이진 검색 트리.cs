using System;
using System.IO;
using static System.Console;
using System.Collections.Generic;
using System.Collections;
using System.Text;

internal class Algorithm
{
	static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));

	private class Node
	{
		public int key;
		public Node left;
		public Node right;
	}

	private static Node CreateNode(int key)
	{
		Node node = new Node();
		node.key = key;

		return node;
	}

	private static void RegistNode(Node root, int key)
	{
		if (root.key > key)
		{
			if (root.left == null)
			{
				Node node = CreateNode(key);
				root.left = node;
			}
			else
			{
				RegistNode(root.left, key);
			}
		}
		else
		{
			if (root.right == null)
			{
				Node node = CreateNode(key);
				root.right = node;
			}
			else
			{
				RegistNode(root.right, key);
			}
		}
	}

	public static void Main(string[] args)
	{
		Node root = null;
		while (int.TryParse(sr.ReadLine(), out int num))
		{
			if (root == null)
			{
				root = CreateNode(num);
				continue;
			}

			RegistNode(root, num);
		}

		Postorder(root);
	}

	private static void Postorder(Node node)
	{
		if (node != null)
		{
			Postorder(node.left);
			Postorder(node.right);
			Write($"{node.key}\n");
		}
	}
}