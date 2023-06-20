using System;
using System.Collections.Generic;
using static System.Console;

internal class Algorithm
{
	static int[,] map;

	public static void Main(string[] args)
	{
		var t = Array.ConvertAll(ReadLine().Split(), int.Parse);

		int n = t[0];
		int m = t[1];

		map = new int[n, n];
		
		for (int i = 0; i < m; i++)
		{
			var node = Array.ConvertAll(ReadLine().Split(), int.Parse);
			map[node[0] - 1, node[1] - 1] = 1;
			map[node[1] - 1, node[0] - 1] = 1;
		}

		int min = Int32.MaxValue;
		int minIndex = 0;

		for (int i = 0; i < n; i++)
		{
			bool[] visited = new bool[n];
			int cnt = Find(i,visited);
			
			if (cnt < min)
			{
				min = cnt;
				minIndex = i + 1;
			}
		}
		
		Write(minIndex);
	}

	private static int Find(int start, bool[] visited)
	{
		int answer = 0;
		visited[start] = true;
		Queue<(int,int)> q = new Queue<(int,int)>();
		q.Enqueue((start,0));
	
		while (q.Count >0)
		{
			var v = q.Dequeue();
			int num = v.Item1;
			int distance = v.Item2;
			
			for (int i = 0; i < map.GetLength(0); i++)
			{
				if (!visited[i] && map[num,i] == 1)
				{
					q.Enqueue((i,distance +1));
					visited[i] = true;
					answer += distance + 1;
				}
			}
		}

		return answer;
	}
}