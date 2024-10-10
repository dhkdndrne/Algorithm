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
	public void solution()
	{
		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);

		int n = input[0];
		int m = input[1];

		int[,] board = new int[n, m];

		for (int y = 0; y < n; y++)
		{
			string s = ReadLine();
			for (int x = 0; x < m; x++)
			{
				board[y, x] = int.Parse(s[x].ToString());
			}
		}

		int max = -1;
		
		for (int y = 0; y < n; y++)
		{
			for (int x = 0; x < m; x++)
			{
				for (int dy = -n; dy < n; dy++)
				{
					for (int dx = -m; dx < m; dx++)
					{
						if (dy == 0 && dx == 0) continue;
						string numStr = "";
						int row = y, col = x;

						while (row >= 0 && row < n && col >= 0 && col < m)
						{
							numStr += board[row,col];      // 숫자를 이어 붙임
							int num = int.Parse(numStr); // 문자열을 숫자로 변환

							// 완전 제곱수인지 확인
							if (IsPerfectSquare(num))
							{
								max = Math.Max(max, num);
							}

							// 다음 칸으로 이동
							row += dy;
							col += dx;
						}
					}
				}
			}
		}
		
		WriteLine(max);
	}

	// 완전 제곱수 판별 함수
	private bool IsPerfectSquare(long n)
	{
		if (n < 0) return false;
		long sqrt = (long)Math.Sqrt(n);
		return sqrt * sqrt == n;
	}
}