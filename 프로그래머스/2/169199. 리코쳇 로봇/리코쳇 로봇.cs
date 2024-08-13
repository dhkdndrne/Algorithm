using System;
using System.Collections.Generic;

public class Solution
{
	private int answer = int.MaxValue;
	private int col, row;
	private int[] dirX = { -1, 1, 0, 0 };
	private int[] dirY = { 0, 0, -1, 1 };
	public int solution(string[] board)
	{
		row = board.GetLength(0);
		col = board[0].Length;

		var start = FindTargetIndex(board, 'R');
		var goal = FindTargetIndex(board, 'G');

		Find(start, goal, board);
		
		return answer == int.MaxValue ? -1 : answer;
	}
	private (int x, int y) FindTargetIndex(string[] board, char target)
	{
		for (int i = 0; i < row; i++)
		{
			string s = board[i];

			for (int j = 0; j < s.Length; j++)
			{
				if (s[j] == target)
				{
					return (j, i);
				}
			}
		}

		return (-1, -1);
	}
	private void Find((int x, int y) start, (int x, int y) goal, string[] board)
	{
		int[,] visit = new int[row, col];

		for (int y = 0; y < row; y++)
		{
			for (int x = 0; x < col; x++)
			{
				visit[y, x] = int.MaxValue;
			}
		}
		
		Queue<(int x, int y, int cnt)> q = new Queue<(int, int, int)>();
		q.Enqueue((start.x, start.y, 0));
		visit[start.y, start.x] = 1;

		while (q.Count > 0)
		{
			var cur = q.Dequeue();

			if (cur.y == goal.y && cur.x == goal.x)
			{
				answer = Math.Min(answer, cur.cnt);
				break;
			}

			//좌우상하
			for (int i = 0; i < 4; i++)
			{
				int nx = cur.x;
				int ny = cur.y;

				while (true)
				{
					int tempX = nx + dirX[i];
					int tempY = ny + dirY[i];

					if (tempX < 0 || tempX > col - 1 || tempY < 0 || tempY > row - 1 || board[tempY][tempX].Equals('D'))
					{
						if (visit[ny, nx] <= cur.cnt + 1)
							break;

						visit[ny, nx] = cur.cnt + 1;
						q.Enqueue((nx, ny, cur.cnt + 1));
						break;
					}

					nx = tempX;
					ny = tempY;
				}
			}
		}
	}
}