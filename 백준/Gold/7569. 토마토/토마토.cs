using System;
using System.Collections;
using System.Collections.Generic;
using static System.Console;

internal class Algorithm
{
	public static void Main(string[] args)
	{
		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);
		int[] xDir = new[] { 1, -1, 0, 0, 0, 0 };
		int[] yDir = new[] { 0, 0, 1, -1, 0, 0 };
		int[] zDir = new[] { 0, 0, 0, 0, 1, -1 };

		int M = input[0]; // X
		int N = input[1]; // Z
		int H = input[2]; // Y

		int answer = -1;
		int[,,] container = new int[H, N, M];
		Queue<(int, int, int)> q = new Queue<(int, int, int)>();

		for (int y = 0; y < H; y++)
		{
			for (int z = 0; z < N; z++)
			{
				var lineValue = Array.ConvertAll(ReadLine().Split(), int.Parse);
				for (int x = 0; x < M; x++)
				{
					container[y, z, x] = lineValue[x];
					if (lineValue[x] == 1)
					{
						q.Enqueue((y, z, x));
					}
				}
			}
		}

		while (q.Count > 0)
		{
			var t = q.Dequeue();

			int curY = t.Item1;
			int curZ = t.Item2;
			int curX = t.Item3;

			for (int i = 0; i < 6; i++)
			{
				int y = curY + yDir[i];
				int z = curZ + zDir[i];
				int x = curX + xDir[i];

				if (x >= 0 && x < M && container[curY, curZ, x] == 0)
				{
					container[curY, curZ, x] = container[curY, curZ, curX] + 1;
					q.Enqueue((curY, curZ, x));
				}

				if (y >= 0 && y < H && container[y, curZ, curX] == 0)
				{
					container[y, curZ, curX] = container[curY, curZ, curX] + 1;
					q.Enqueue((y, curZ, curX));
				}

				if (z >= 0 && z < N && container[curY, z, curX] == 0)
				{
					container[curY, z, curX] = container[curY, curZ, curX] + 1;
					q.Enqueue((curY, z, curX));
				}
			}
		}

		bool check = false;
		for (int y = 0; y < H; y++)
		{
			for (int z = 0; z < N; z++)
			{
				for (int x = 0; x < M; x++)
				{
					if (container[y, z, x] == 0)
					{
						check = true;
						answer = -1;
						break;
					}
					if (container[y, z, x] > answer)
						answer = container[y,z,x] -1;
				}
				if (check)
					break;
			}
			if (check)
				break;
		}
		
		Write(answer);
	}
}