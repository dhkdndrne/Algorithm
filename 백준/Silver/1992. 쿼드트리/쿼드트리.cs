using System.Text;
using System;
using static System.Console;
using System.Collections.Generic;

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
	private int n;
	private int[,] board;
	StringBuilder sb = new StringBuilder();
	public void solution()
	{
		n = int.Parse(ReadLine());
		board = new int[n, n];

		for (int i = 0; i < n; i++)
		{
			string s = ReadLine();
			for (int j = 0; j < n; j++)
			{
				board[i, j] = int.Parse(s[j].ToString());
			}
		}
		Divide(0, 0, n);
		WriteLine(sb.ToString());

	}

	private void Divide(int x, int y, int size)
	{
		if (CheckSame(x, y, size))
		{
			sb.Append(board[y, x]);
		}
		else
		{
			sb.Append('(');
			int newSize = size / 2;
			for (int i = y; i < y + size; i += newSize)
			{
				for (int j = x; j < x + size; j += newSize)
				{
					Divide(j, i, newSize);
				}
			}
			sb.Append(')');
		}
	}

	private bool CheckSame(int x, int y, int size)
	{
		int firstNum = board[y, x];

		for (int i = y; i < y + size; i++)
		{
			for (int j = x; j < x + size; j++)
			{
				if (board[i, j] != firstNum) return false;
			}
		}
		return true;
	}
}