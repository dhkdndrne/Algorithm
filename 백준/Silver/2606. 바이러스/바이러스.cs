using System;
using System.Collections.Generic;
using static System.Console;

internal class Algorithm
{
	public static void Main(string[] args)
	{
		int computers = int.Parse(ReadLine());
		int n = int.Parse(ReadLine());

		int[,] nodes = new int[computers, computers];
		bool[] visited = new bool[computers];
		
		for (int i = 0; i < n; i++)
		{
			int[] node = Array.ConvertAll(ReadLine().Split(), Int32.Parse);

			nodes[node[0] - 1, node[1] - 1] = 1;
			nodes[node[1] - 1, node[0] - 1] = 1;
		}
		
		Write(BFS(nodes, visited, computers) -1);
	}

	private static int BFS(int[,] nodes, bool[] visited, int computers)
	{
		int answer = 0;
		Queue<int> q = new Queue<int>();
		q.Enqueue(0);
		visited[0] = true;

		while (q.Count > 0)
		{
			int node = q.Dequeue();
			answer++;

			for (int i = 0; i < computers; i++)
			{
				if (!visited[i] && nodes[node, i] == 1)
				{
					visited[i] = true;
					q.Enqueue(i);
				}
			}
		}

		return answer;
	}

}