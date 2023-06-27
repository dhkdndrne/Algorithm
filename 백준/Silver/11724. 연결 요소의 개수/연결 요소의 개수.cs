using System;
using System.Collections.Generic;
using System.IO;
using static System.Console;

internal class Algorithm
{
	static StreamReader sr = new StreamReader(new BufferedStream(OpenStandardInput()));
	public static void Main(string[] args)
	{
		var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

		int n = input[0];
		int m = input[1];
		int answer = 0;

		int[,] map = new int[n, n];
		bool[] isVisited = new bool[n];

		for (int i = 0; i < m; i++)
		{
			var v = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
			int num1 = v[0] - 1;
			int num2 = v[1] - 1;

			map[num1,num2] = map[num2,num1] = 1;
		}

		for (int i = 0; i < n; i++)
		{
			if (!isVisited[i])
			{
				BFS(i, map, isVisited);
				answer++;
			}
		}
		
		Write(answer);
	}

	private static void BFS(int num, int[,] map, bool[] isVisited)
	{
		Queue<int> q = new Queue<int>();
		q.Enqueue(num);
		isVisited[num] = true;

		while (q.Count > 0)
		{
			int cur = q.Dequeue();

			for (int i = 0; i < map.GetLength(0); i++)
			{
				if (!isVisited[i] && map[cur, i] == 1)
				{
					q.Enqueue(i);
					isVisited[i] = true;
				}
			}
		}
	}
}