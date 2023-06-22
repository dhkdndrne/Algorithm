using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static System.Console;

internal class Algorithm
{
	public static void Main(string[] args)
	{
		var mapSize = Array.ConvertAll(ReadLine().Split(), int.Parse);

		int n = mapSize[0];
		int m = mapSize[1];

		int[] xDir = new[] { -1, 1, 0, 0 };
		int[] yDir = new[] { 0, 0, -1, 1 };

		int[,] map = new int[n, m];
		bool[,] isVisited = new bool[n, m];

		Queue<(int, int)> q = new Queue<(int, int)>();
		StringBuilder sb = new StringBuilder();

		for (int y = 0; y < n; y++)
		{
			var mapInfo = Array.ConvertAll(ReadLine().Split(), int.Parse);
			for (int x = 0; x < m; x++)
			{
				if (mapInfo[x] == 2)
				{
					q.Enqueue((x, y));
					map[y, x] = 0;
					continue;
				}
				
				map[y, x] = mapInfo[x] == 1 ? -1 : 0;
			}
		}

		while (q.Count > 0)
		{
			var pos = q.Dequeue();

			int curX = pos.Item1;
			int curY = pos.Item2;
			
			for (int i = 0; i < 4; i++)
			{
				int x = curX + xDir[i];
				int y = curY + yDir[i];
				
				if(x < 0 || x >= m || y < 0 || y>=n) continue;
				if(map[y,x] == 0) continue;
				if (isVisited[y, x]) continue;
				
				map[y,x] = map[curY, curX] + 1;
				q.Enqueue((x,y));
				isVisited[y, x] = true;
			}
		}
		for (int y = 0; y < n; y++)
		{
			for (int x = 0; x < m; x++)
			{
				sb.Append($"{map[y, x]}");

				if (x < m -1)
					sb.Append(" ");
			}
			sb.Append("\n");
		}

		Write(sb.ToString());
	}
}