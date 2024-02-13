using static System.Console;
using System.Collections.Generic;

class Solutuin
{
	public static void Main(string[] args)
	{
		Solution solution = new Solution();
		solution.Sol();
	}
}

public class Solution
{
	static StreamReader sr = new StreamReader(new BufferedStream(OpenStandardInput()));
	static StreamWriter sw = new StreamWriter(new BufferedStream(OpenStandardOutput()));

	private int n, answer = int.MaxValue;
	private int[,] board;
	private int[] dirX = { -1, 1, 0, 0 };
	private int[] dirY = { 0, 0, -1, 1 };

	public void Sol()
	{
		n = int.Parse(sr.ReadLine());
		board = new int[n, n];
		bool[,] visit = new bool[n, n];

		for (int y = 0; y < n; y++)
		{
			var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
			for (int x = 0; x < n; x++)
			{
				board[y, x] = input[x];
			}
		}

		int num = 1;
		for (int y = 0; y < n; y++)
		{
			for (int x = 0; x < n; x++)
			{
				if (!visit[y, x] && board[y, x] == 1)
				{
					FindArea(x, y, num, visit);
					num++;
				}
				
				if (board[y, x] != 0)
				{
					Find(x, y);
				}
			}
		}
		
		sw.Write(answer);

		sw.Close();
		sr.Close();
	}

	private void FindArea(int x, int y, int num, bool[,] visit)
	{
		Queue<(int x, int y)> q = new Queue<(int x, int y)>();
		q.Enqueue((x, y));
		visit[y, x] = true;
		
		while (q.Count > 0)
		{
			var cur = q.Dequeue();
			int curX = cur.x;
			int curY = cur.y;

			board[curY, curX] = num;
			
			for (int i = 0; i < 4; i++)
			{
				int nx = curX + dirX[i];
				int ny = curY + dirY[i];

				if (nx < 0 || ny < 0 || nx >= n || ny >= n) continue;
				if (visit[ny, nx]) continue;
				if (board[ny, nx] != 1) continue;

				visit[ny, nx] = true;
				q.Enqueue((nx, ny));
			}
		}
	}
	private void Find(int x, int y)
	{
		int cnt = 0;
		Queue<(int x, int y, int dist)> q = new Queue<(int x, int y, int dist)>();
		bool[,] tVisit = new bool[n, n];

		q.Enqueue((x, y, 0));
		tVisit[y, x] = true;
		
		while (q.Count > 0)
		{
			var cur = q.Dequeue();
			if (cur.dist >= answer)
				return;
			
			for (int i = 0; i < 4; i++)
			{
				int nx = cur.x + dirX[i];
				int ny = cur.y + dirY[i];

				if (nx < 0 || ny < 0 || nx >= n || ny >= n) continue;
				if (tVisit[ny, nx]) continue;

				if (board[ny, nx] == 0)
				{
					q.Enqueue((nx, ny, cur.dist + 1));
					tVisit[ny, nx] = true;
				}
				else if (board[ny, nx] != board[y, x])
				{
					answer = Math.Min(answer, cur.dist);
				}
			}
		}
	}
}