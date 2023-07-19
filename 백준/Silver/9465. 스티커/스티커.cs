using System;
using System.Collections.Generic;
using System.IO;
using static System.Console;

internal class Algorithm
{
	private static StreamReader sr = new StreamReader(new BufferedStream(OpenStandardInput()));

	private static int[,] arr;
	private static int[,] dp;

	public static void Main(string[] args)
	{
		int T = int.Parse(sr.ReadLine());

		while (T > 0)
		{
			int n = int.Parse(sr.ReadLine());

			arr = new int[2, n + 1];
			dp = new int[2, n + 1];

			for (int i = 0; i < 2; i++)
			{
				int[] v = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
				for (int j = 1; j <= n; j++)
				{
					arr[i, j] = v[j - 1];
				}
			}

			dp[0, 0] = dp[1, 0] = 0;
			dp[0, 1] = arr[0, 1];
			dp[1, 1] = arr[1, 1];

			for (int i = 2; i <= n; i++)
			{
				dp[0, i] = Math.Max(dp[1, i - 1], dp[1, i - 2]) + arr[0, i];
				dp[1, i] = Math.Max(dp[0, i - 1], dp[0, i - 2]) + arr[1, i];
			}

			Write(Math.Max(dp[0, n], dp[1, n])+"\n");

			T--;
		}
	}

}