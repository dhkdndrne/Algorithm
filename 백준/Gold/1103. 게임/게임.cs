using static System.Console;
using System.Collections.Generic;
using System.Text;

class Algorithm
{
	public static void Main(string[] args)
	{
		Solution solution = new Solution();
		solution.solution();
	}
}

public class Solution
{
	private int n, m;
	private int[,] board;
	private bool[,] visit;
	private int[,] dp;
	private bool isCycle;
	private int[] dirX = { -1, 1, 0, 0 };
	private int[] dirY = { 0, 0, -1, 1 };

	private int answer = 0;

	public void solution()
	{
		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);

		n = input[0];
		m = input[1];

		board = new int[n, m];
		visit = new bool[n, m];
		dp = new int[n, m];

		for (int i = 0; i < n; i++)
		{
			string s = ReadLine();
			for (int j = 0; j < m; j++)
			{
				board[i, j] = s[j] == 'H' ? -1 : int.Parse(s[j].ToString());
			}
		}

		visit[0, 0] = true;
		Find(0, 0, 0);
		WriteLine(isCycle ? -1 : answer + 1);
	}

	private void Find(int x, int y, int cnt)
	{
		answer = Math.Max(answer, cnt);
		dp[y, x] = cnt;
		int num = board[y, x];
		
		for (int i = 0; i < 4; i++)
		{
			if (answer == -1)
				return;
			
			int nx = x + (dirX[i] * num);
			int ny = y + (dirY[i] * num);

			if (nx > m - 1 || nx < 0 || ny > n - 1 || ny < 0 || board[ny, nx] == -1)
				continue;
	
			if(dp[ny,nx] > cnt) continue;
			
			if (visit[ny, nx])
			{
				isCycle = true;
				return;
			}
			
			visit[ny, nx] = true;
			Find(nx, ny, cnt + 1);
			visit[ny, nx] = false;
		}
		
	}
}