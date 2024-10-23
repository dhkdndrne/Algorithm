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
	private int[] answer = new int[3];
	public void solution()
	{
		n = int.Parse(ReadLine());
		board = new int[n, n];

		for (int i = 0; i < n; i++)
		{
			var input = Array.ConvertAll(ReadLine().Split(), int.Parse);

			for (int j = 0; j < n; j++)
			{
				board[i, j] = input[j];
			}
		}

		Divide(0, 0, n);
		for (int i = 0; i < 3; i++)
		{
			WriteLine(answer[i]);
		}
	}
	private void Divide(int x, int y, int size)
	{
		if (CheckSame(x, y, size))
		{
			answer[board[y, x] + 1]++;
		}
		else
		{
			int newSize = size / 3;
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					Divide(newSize * j + x, newSize * i + y, newSize);
				}
			}
		}
	}

	private bool CheckSame(int x, int y, int size)
	{
		int first = board[y, x];

		for (int i = y; i < y + size; i++)
		{
			for (int j = x; j < x + size; j++)
			{
				if (board[i, j] != first) return false;
			}
		}

		return true;
	}
}