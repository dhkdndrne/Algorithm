using System;
using System.IO;
using static System.Console;

internal class Algorithm
{
	static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));

	public static void Main(string[] args)
	{
		int n = int.Parse(sr.ReadLine());

		int[,] map = new int[n, 3];

		for (int i = 0; i < n; i++)
		{
			var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

			for (int j = 0; j < 3; j++)
				map[i, j] = input[j];

		}

		Write(FindMax(map, n) + " " + FindMin(map, n));
	}

	private static int FindMax(int[,] map, int n)
	{
		int[,] dp = map.Clone() as int[,];
		
		for (int i = 1; i < n; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				dp[i, j] = j switch
				{
					0 => Math.Max(dp[i, j] + dp[i - 1, 0], dp[i, j] + dp[i - 1, 1]),
					1 => Max(dp[i, j] + dp[i - 1, 0], dp[i, j] + dp[i - 1, 1], dp[i, j] + dp[i - 1, 2]),
					2 => Math.Max(dp[i, j] + dp[i - 1, 1], dp[i, j] + dp[i - 1, 2])
				};
			}
		}

		return Max(dp[n - 1, 0], dp[n - 1, 1], dp[n - 1, 2]);
	}

	private static int FindMin(int[,] map, int n)
	{
		for (int i = 1; i < n; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				map[i, j] = j switch
				{
					0 => Math.Min(map[i, j] + map[i - 1, 0], map[i, j] + map[i - 1, 1]),
					1 => Min(map[i, j] + map[i - 1, 0], map[i, j] + map[i - 1, 1], map[i, j] + map[i - 1, 2]),
					2 => Math.Min(map[i, j] + map[i - 1, 1], map[i, j] + map[i - 1, 2])
				};
			}
		}

		return Min(map[n - 1, 0], map[n - 1, 1], map[n - 1, 2]);
	}
	private static int Max(int a, int b, int c)
	{
		int max = Math.Max(a, b);
		max = Math.Max(max, c);

		return max;
	}

	private static int Min(int a, int b, int c)
	{
		int min = Math.Min(a, b);
		min = Math.Min(min, c);

		return min;
	}
}