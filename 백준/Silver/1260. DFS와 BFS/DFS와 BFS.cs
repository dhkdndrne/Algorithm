using System;
using System.Collections.Generic;
using static System.Console;

internal class Algorithm
{
	public static void Main(string[] args)
	{
		var t = Array.ConvertAll(ReadLine().Split(), int.Parse);

		int n = t[0];
		int m = t[1];
		int start = t[2] - 1;

		int[,] map = new int[n, n];

		for (int i = 0; i < m; i++)
		{
			var numbers = Array.ConvertAll(ReadLine().Split(), int.Parse);

			map[numbers[0] - 1, numbers[1] - 1] = 1;
			map[numbers[1] - 1, numbers[0] - 1] = 1;
		}
		bool[] visited = new bool[n];

		DFS(start, visited, map);
		Write("\n");
		BFS(start, visited, map);
	}

	private static void DFS(int num, bool[] visited, int[,] map)
	{
		visited[num] = true;
		Write($"{num + 1} ");
		
		for (int i = 0; i < map.GetLength(0); i++)
		{
			if (map[num, i] == 1)
			{
				if (!visited[i])
					DFS(i, visited, map);
			}
		}
	}

	private static void BFS(int start, bool[] visited, int[,] map)
	{
		for (int i = 0; i < visited.Length; i++)
			visited[i] = false;

		Queue<int> q = new Queue<int>();

		q.Enqueue(start);

		while (q.Count > 0)
		{
			int num = q.Dequeue();
			if (visited[num])
				continue;

			Write($"{num + 1} ");
			visited[num] = true;

			for (int i = 0; i < map.GetLength(0); i++)
			{
				if (map[num, i] == 1)
				{
					q.Enqueue(i);
				}
			}
		}
	}
}