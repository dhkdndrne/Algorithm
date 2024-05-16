using static System.Console;
using System.Collections.Generic;

class Algorithm
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

	private int n, m; //세로 가로
	private int answer = 0;
	private int[,] board;

	private int[] dirX = { -1, 1, 0, 0 };
	private int[] dirY = { 0, 0, -1, 1 };

	public void Sol()
	{
		var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

		n = input[0];
		m = input[1];
		board = new int[n, m];

		for (int y = 0; y < n; y++)
		{
			input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

			for (int x = 0; x < m; x++)
			{
				board[y, x] = input[x];
			}
		}

		for (int y = 0; y < n; y++)
		{
			for (int x = 0; x < m; x++)
			{
				FindShape(x, y, -1, -1, 0, 0);
				FindTShape(x, y);
			}
		}

		Write(answer);
	}

	private void FindShape(int x, int y, int px, int py, int length, int sum)
	{
		if (length == 4)
		{
			answer = Math.Max(sum, answer);
			return;
		}

		int cnt = 0;

		for (int i = 0; i < 4; i++)
		{
			int nx = x + dirX[i];
			int ny = y + dirY[i];

			if (nx < 0 || nx >= m || ny < 0 || ny >= n) continue;
			if (nx == px && ny == py) continue;

			FindShape(nx, ny, x, y, length + 1, sum + board[ny, nx]);
		}
	}
	private void FindTShape(int x, int y)
	{
		int sum = 0;
		for (int i = 0; i < 4; i++)
		{
			sum = board[y, x];
			for (int d = 0; d < 4; d++)
			{
				if (i == d)
					continue;

				int nx = x + dirX[d];
				int ny = y + dirY[d];

				if (nx < 0 || nx >= m || ny < 0 || ny >= n) continue;

				sum += board[ny, nx];
			}

			answer = Math.Max(answer, sum);
		}
	}
}