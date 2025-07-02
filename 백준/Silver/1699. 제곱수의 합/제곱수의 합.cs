using static System.Console;
using System.Collections.Generic;
using System.Text;

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
	public void Solve()
	{
		int n = int.Parse(ReadLine());
		int[] dp = new int[n + 1];

		for (int i = 1; i <= n; i++)
		{
			dp[i] = i; // 최악의 경우 = 전부 1^2로 더했을때
			for (int j = 1; j * j <= i; j++)
			{
				dp[i] = Math.Min(dp[i], dp[i - j * j] + 1);
			}
		}

		WriteLine(dp[n]);
	}
}