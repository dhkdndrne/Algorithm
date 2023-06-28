using System;
using System.IO;
using System.Collections.Generic;

internal class Algorithm
{
	static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));

	private static int v;
	private static int farNode;
	private static int max;

	public static void Main(string[] args)
	{
		v = int.Parse(sr.ReadLine());

		Dictionary<int, List<(int, int)>> graph = new Dictionary<int, List<(int, int)>>();
		for (int i = 0; i < v; i++)
		{
			string[] input = sr.ReadLine().Split();
			int node = int.Parse(input[0]);
			graph[node] = new List<(int, int)>();

			for (int j = 1; j < input.Length - 1; j += 2)
			{
				int adjacentNode = int.Parse(input[j]);
				int distance = int.Parse(input[j + 1]);
				graph[node].Add((adjacentNode, distance));
			}
		}

		bool[] isVisit = new bool[v + 1];
		Find(1, 0, graph, isVisit);

		for (int i = 1; i <= v; i++)
			isVisit[i] = false;

		max = 0;
		Find(farNode, 0, graph, isVisit);

		Console.WriteLine(max);
	}

	private static void Find(int node, int dist, Dictionary<int, List<(int, int)>> graph, bool[] isVisit)
	{
		if (dist > max)
		{
			max = dist;
			farNode = node;
		}

		isVisit[node] = true;

		foreach (var adjacentNode in graph[node])
		{
			int next = adjacentNode.Item1;
			int nextDist = adjacentNode.Item2;

			if (!isVisit[next])
			{
				Find(next, dist + nextDist, graph, isVisit);
			}
		}
	}
}