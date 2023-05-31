using System;
using System.Collections.Generic;
using static System.Console;

internal class Algorithm
{
	public static void Main(string[] args)
	{
		int n = int.Parse(ReadLine());
		int[,] map = new int[n, n];
		bool[,] visited = new bool[n, n];

		for (int i = 0; i < n; i++)
		{
			string value = ReadLine();

			for (int j = 0; j < n; j++)
			{
				map[i, j] = int.Parse(value[j].ToString());
			}
		}

		List<int> result = new List<int>();

		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < n; j++)
			{
				if (!visited[i, j])
				{
					int apartAmount = BFS(j, i, map, visited);

					if (apartAmount != 0)
						result.Add(apartAmount);
				}
			}
		}

		result.Sort((x, y) => x.CompareTo(y));
		Write(result.Count + "\n");

		foreach (var num in result)
		{
			Write(num + "\n");
		}
	}

	private static int BFS(int nx, int ny, int[,] map, bool[,] visited)
	{
		visited[ny, nx] = true;
		if (map[ny, nx] == 0)
			return 0;

		Queue<(int, int)> q = new Queue<(int, int)>();
		q.Enqueue((nx, ny));

		int[] dx = { 0, 0, -1, 1 };
		int[] dy = { -1, 1, 0, 0 };
		int cnt = 1;

		while (q.Count > 0)
		{
			var cur = q.Dequeue();
			int x = cur.Item1;
			int y = cur.Item2;

			for (int i = 0; i < 4; i++)
			{
				int tempX = x + dx[i];
				int tempY = y + dy[i];

				if (tempX >= 0 && tempX < map.GetLength(0) && tempY >= 0 && tempY < map.GetLength(0))
				{
					if (!visited[tempY, tempX] && map[tempY, tempX] == 1)
					{
						q.Enqueue((tempX,tempY));
						visited[tempY,tempX] = true;
						cnt++;
					}
				}
			}

		}
		return cnt;
	}
}