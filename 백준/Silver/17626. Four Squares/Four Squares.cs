using System;
using static System.Console;

internal class Algorithm
{
	public static void Main(string[] args)
	{
		int n = int.Parse(ReadLine());
		int[] dp = new int[50001];

		for (int i = 1; i <= n; i++)
		{
			dp[i] = dp[i - 1] + 1;
			for (int j = 1; j * j <= i; j++)
			{
				dp[i] = Math.Min(dp[i], dp[i - j * j] + 1);
			}
		}
		
		Write(dp[n]);
	}
}