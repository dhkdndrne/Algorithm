using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

internal class Algorithm
{
	public static void Main(string[] args)
	{
		int n = int.Parse(ReadLine());

		char[,] map = new char[n, n];
		bool[,] isVisited = new bool[n, n];

		for (int i = 0; i < n; i++)
		{
			string colors = ReadLine();
			for (int j = 0; j < n; j++)
			{
				map[i, j] = colors[j];
			}
		}

		int a1 = 0;
		int a2 = 0;

		for (int y = 0; y < n; y++)
		{
			for (int x = 0; x < n; x++)
			{
				if (!isVisited[y, x])
				{
					DFS(x, y, isVisited, map);
					a1++;
				}
			}
		}

		for (int y = 0; y < n; y++)
		{
			for (int x = 0; x < n; x++)
			{
				isVisited[y, x] = false;
				if (map[y, x] == 'R')
					map[y, x] = 'G';
			}
		}

		for (int y = 0; y < n; y++)
		{
			for (int x = 0; x < n; x++)
			{
				if (!isVisited[y, x])
				{
					DFS(x, y, isVisited, map);
					a2++;
				}
			}
		}
		Write($"{a1} {a2}");
	}

	private static void DFS(int x, int y, bool[,] isVisited, char[,] map)
	{
		if (isVisited[y, x])
			return;

		isVisited[y, x] = true;

		int[] dx = { -1, 1, 0, 0 };
		int[] dy = { 0, 0, -1, 1 };

		for (int i = 0; i < 4; i++)
		{
			int nx = x + dx[i];
			int ny = y + dy[i];

			if (nx < 0 || ny < 0 || nx >= map.GetLength(0) || ny >= map.GetLength(0))
				continue;

			if (map[ny, nx] == map[y, x])
				DFS(nx, ny, isVisited, map);
		}

	}
}