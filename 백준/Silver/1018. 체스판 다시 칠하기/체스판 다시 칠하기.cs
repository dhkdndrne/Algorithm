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
	private int answer = int.MaxValue;
	private int[,] board;

	public void solution()
	{
		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);

		n = input[0]; // row
		m = input[1]; // col

		board = new int[n, m];

		for (int y = 0; y < n; y++)
		{
			var s = ReadLine();
			for (int x = 0; x < m; x++)
			{
				board[y, x] = s[x].Equals('B') ? 0 : 1;
			}
		}
		
		for (int y = 0; y <= n - 8; y++)
		{
			for (int x = 0; x <= m - 8; x++)
			{
				Find(x, y,true);
				Find(x, y,false);
			}
		}
		
		WriteLine(answer);
	}

	private void Find(int startX, int startY,bool isBlack)
	{
		bool flag = !isBlack; //다음줄 체크
		int count = 0;

		for (int y = startY; y < startY + 8; y++)
		{
			for (int x = startX; x < startX + 8; x++)
			{
				if (isBlack && board[y, x] == 1)
				{
					count++;
				}
				else if (!isBlack && board[y, x] == 0)
				{
					count++;
				}
				isBlack = !isBlack;
			}
			isBlack = flag;
			flag = !flag;
		}

		answer = Math.Min(answer, count);
	}
}