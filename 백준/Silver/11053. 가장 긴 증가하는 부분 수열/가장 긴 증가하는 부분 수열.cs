using System;
using System.IO;
using static System.Console;

internal class Algorithm
{
	static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
	
	public static void Main(string[] args)
	{
		int n = int.Parse(sr.ReadLine());
		int[] dp = new int[n];
		int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

		int answer = 0;
		
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < i; j++)
			{
				if (arr[i]> arr[j] && dp[i] <= dp[j])
				{
					dp[i] = Math.Max(dp[i], dp[j] + 1);
				}
			}

			answer = Math.Max(answer, dp[i]);
		}
		
		Write(answer + 1);
	}
}