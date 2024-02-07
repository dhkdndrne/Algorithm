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
		int n = int.Parse(sr.ReadLine());
		int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
		int[] dp = new int[100001];

	    dp[0] = nums[0];
		int max = dp[0];
		for (int i = 1; i < n; i++)
		{
			dp[i] = Math.Max(dp[i - 1] + nums[i], nums[i]);

			max = Math.Max(max, dp[i]);
		}

		Write(max);
	}
}