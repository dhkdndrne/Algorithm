using System;
using System.Collections.Generic;
using static System.Console;

internal class Algorithm
{
	public static void Main(string[] args)
	{
		int[] xDir = new[] { -1, 1, 0, 0 };
		int[] yDir = new[] { 0, 0, 1, -1 };
		
		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);

		int M = input[0]; // x
		int N = input[1]; // y

		int answer = -1;
		int[,] container = new int[N, M];
		Queue<(int, int)> q = new Queue<(int, int)>();
		
		for (int y = 0; y < N; y++)
		{
			var tomatoState = Array.ConvertAll(ReadLine().Split(), int.Parse);
			for (int x = 0; x < M; x++)
			{
				container[y, x] = tomatoState[x];
				
				if(tomatoState[x] ==1)
					q.Enqueue((x,y));
			}
		}

		while (q.Count >0)
		{
			var t = q.Dequeue();
			
			int curX = t.Item1;
			int curY = t.Item2;

			for (int i = 0; i < 4; i++)
			{
				int x = curX + xDir[i];
				int y = curY + yDir[i];

				if (x >= 0 && x < M && container[curY, x] == 0)
				{
					q.Enqueue((x,curY));
					container[curY, x] = container[curY, curX] + 1;
				}
				
				if (y >= 0 && y < N && container[y, curX] == 0)
				{
					q.Enqueue((curX,y));
					container[y, curX] = container[curY, curX] + 1;
				}
			}
		}

		bool check = false;
		for (int y = 0; y < N; y++)
		{
			for (int x = 0; x < M; x++)
			{
				if (container[y, x] == 0)
				{
					check = true;
					answer = -1;
					break;
				}

				if (answer < container[y, x])
					answer = container[y, x] - 1;
			}
			if (check)
				break;
		}
		
		Write(answer);
	}
}