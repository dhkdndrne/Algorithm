using static System.Console;
using System.Collections.Generic;

class Solutuin
{
	public static void Main(string[] args)
	{
		Solution solution = new Solution();
		solution.Sol();
	}
}

public class Solution
{
	static StreamReader sr = new StreamReader(new BufferedStream(OpenStandardInput()));
	static StreamWriter sw = new StreamWriter(new BufferedStream(OpenStandardOutput()));

	public void Sol()
	{
		var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
		
		int n = input[0];
		int k = input[1];

		int[] dp = new int[10001];
		int[] coins = new int[n];

		for (int i = 0; i < n; i++)
		{
			coins[i] = int.Parse(sr.ReadLine());
		}

		dp[0] = 1;
		for (int i = 0; i < n; i++)
		{
			for (int j = coins[i]; j <= k; j++)
			{
				dp[j] +=dp[j - coins[i]];
			}
		}
		
		Write(dp[k]);
	}
}