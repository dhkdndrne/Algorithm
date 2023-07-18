using System;
using System.IO;
using static System.Console;
using System.Collections.Generic;
using System.Text;

internal class Algorithm
{
	private static StreamReader sr = new StreamReader(new BufferedStream(OpenStandardInput()));

	private static int N, M;
	private static int[,] map;
	private static int[] dx = { -1, 1, 0, 0 };
	private static int[] dy = { 0, 0, -1, 1 };
	public static void Main(string[] args)
	{
		var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
		N = input[0];
		M = input[1];

		map = new int[N, M];
		
		for (int i = 0; i < N; i++)
		{
			var arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

			for (int j = 0; j < arr.Length; j++)
			{
				map[i, j] = arr[j];
			}
		}

		int answer = 0;
		bool remainCheese = true;
		while (remainCheese)
		{
			answer++;
			remainCheese = BFS();
			
		}
		Write(answer);
	}
	
	private static bool BFS()
	{
		bool[,] visited = new bool[N, M];
		Queue<(int x, int y)> q = new Queue<(int x, int y)>();
		Queue<(int x, int y)> remainCheese = new Queue<(int x, int y)>();
		
		q.Enqueue((0, 0));
		visited[0, 0] = true;
		
		for (int y = 0; y < N; y++)
		{
			for (int x = 0; x < M; x++)
			{
				if (map[y, x] == -1)
					map[y, x] = 0;
				
				if (map[y, x] == 1)
				{
					remainCheese.Enqueue((x,y));
				}
			}
		}
		
		if (remainCheese.Count == 0)
			return false;

		int cheeseCount = remainCheese.Count;
		
		while (q.Count > 0)
		{
			var pos = q.Dequeue();

			for (int i = 0; i < 4; i++)
			{
				if (map[pos.y, pos.x] == 0)
					map[pos.y, pos.x] = -1;
				
				int x = pos.x + dx[i];
				int y = pos.y + dy[i];

				if (x < 0 || y < 0 || x > M - 1 || y > N - 1) continue;
				if (visited[y, x]) continue;

				visited[y, x] = true;

				if (map[y, x] == 0)
				{
					q.Enqueue((x, y));
				}
			}
		}
		
		while (remainCheese.Count > 0)
		{
			var v = remainCheese.Dequeue();

			int x = v.x;
			int y = v.y;
			
			if (CanRemove(x,y))
			{
				map[y, x] = 0;
				cheeseCount--;
			}
		}

		return cheeseCount > 0;
	}

	private static bool CanRemove(int x, int y)
	{
		int cnt = 0;
		for (int i = 0; i < 4; i++)
		{
			int curX = x + dx[i];
			int curY = y + dy[i];

			if (map[curY, curX] == -1)
				cnt++;
		}

		return cnt >= 2;
	}
}