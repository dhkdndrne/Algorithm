using static System.Console;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class Program
{
	public static void Main(string[] args)
	{
		Solution solution = new Solution();
		solution.Solve();
	}
}

public class Solution
{
	private char[,] board;
	public void Solve()
	{
		StringBuilder sb = new  StringBuilder();
		int n = int.Parse(ReadLine());
		board = new char[n, n];

		FillBoard(0, 0, n, false);
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < n; j++)
				sb.Append(board[i, j]);
			sb.AppendLine();
		}
		
		WriteLine(sb.ToString());
	}
	private void FillBoard(int x, int y, int size, bool isBlank)
	{
		if (isBlank)
		{
			for (int i = x; i < x + size; i++)
			{
				for (int j = y; j < y + size; j++)
				{
					board[i, j] = ' ';
				}
			}
			return;
		}

		if (size == 1)
		{
			board[x, y] = '*';
			return;
		}

		int newSize = size / 3;
		int count = 0;
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				count++;
				FillBoard(x + i * newSize, y + j * newSize, newSize, count == 5);
			}
		}
	}
}