using System;
using System.IO;
using static System.Console;

internal class Algorithm
{
	static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
	
	public class Node
	{
		public char key;
		public Node left;
		public Node right;
	}

	private static Node CreateNode(char key)
	{
		Node node = new Node();
		node.key = key;

		return node;
	}

	private static Node SearchNode(Node root,char key)
	{
		if (key == root.key)
			return root;

		Node node = null;
		
		if (root.left != null)
			node = SearchNode(root.left, key);
		
		if (root.right != null && node == null)
			node = SearchNode(root.right, key);

		return node;
	}
	
	public static void Main(string[] args)
	{
		int N = int.Parse(sr.ReadLine());
		Node root = null;
		
		for (int i = 0; i < N; i++)
		{
			char[] input = Array.ConvertAll(sr.ReadLine().Split(), char.Parse);
			
			if (root == null)
				root = CreateNode(input[0]);

			Node node = SearchNode(root, input[0]);
			
			if (input[1] != '.')
			{
				Node leftNode = CreateNode(input[1]);
				leftNode.key = input[1];
				node.left = leftNode;
			}
			
			if (input[2] != '.')
			{
				Node rightNode = CreateNode(input[2]);
				rightNode.key = input[2];
				node.right = rightNode;
			}
		}

		Preorder(root);
		Write("\n");
		Inorder(root);
		Write("\n");
		Postorder(root);

	}

	private static void Preorder(Node node)
	{
		if (node != null)
		{
			Write(node.key);
			Preorder(node.left);
			Preorder(node.right);
		}
	}
	
	private static void Inorder(Node node)
	{
		if (node != null)
		{
			Inorder(node.left);
			Write(node.key);
			Inorder(node.right);
		}
	}
	
	private static void Postorder(Node node)
	{
		if (node != null)
		{
			Postorder(node.left);
			Postorder(node.right);
			Write(node.key);
		}
	}
}