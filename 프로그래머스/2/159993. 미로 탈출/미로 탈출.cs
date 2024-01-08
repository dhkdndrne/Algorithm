using System;
using System.Collections.Generic;

public class Solution 
{
	private int col, row;
	private string[,] map;
	private Index[] pos = new Index[3];
	public int solution(string[] maps)
	{
		int answer = 0;
		col = maps[0].Length;
		row = maps.Length;

		map = new string[row, col];

		for (int y = 0; y < row; y++)
		{
			for (int x = 0; x < col; x++)
			{
				string s = maps[y][x].ToString();
				map[y, x] = s;

				int index = 0;

				if (s.Equals("S"))
					index = 0;
				else if (s.Equals("L"))
					index = 1;
				else if (s.Equals("E"))
					index = 2;
				else index = -1;

				if (index != -1)
					pos[index] = new Index(x, y);
			}
		}

		answer = Find(pos[0], pos[1]);

		if (answer == 0)
			return -1;
		
		int temp = Find(pos[1], pos[2]);
		
		if (temp == 0)
			return -1;

		return answer + temp;
	}

	private int Find(Index start, Index target)
	{
		int answer = 0;
		int[] dirX = { -1, 1, 0, 0 };
		int[] dirY = { 0, 0, -1, 1 };

		Queue<Index> q = new Queue<Index>();
		int[,] visit = new int[row, col];

		q.Enqueue(start);

		while (q.Count > 0)
		{
			var cur = q.Dequeue();
			int x = cur.x;
			int y = cur.y;

			if (x == target.x && y == target.y)
			{
				answer += visit[y, x];
				break;
			}

			for (int i = 0; i < 4; i++)
			{
				int nx = x + dirX[i];
				int ny = y + dirY[i];

				if (nx < 0 || ny < 0 || nx >= col || ny >= row) continue;
				if (visit[ny, nx] != 0) continue;
				if (map[ny, nx].Equals("X")) continue;

				visit[ny, nx] = visit[y, x] + 1;
				q.Enqueue(new Index(nx, ny));
			}
		}

		return answer;
	}

	private struct Index
	{
		public int x;
		public int y;

		public Index(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}
}