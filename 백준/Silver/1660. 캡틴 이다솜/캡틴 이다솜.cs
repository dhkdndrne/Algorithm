using System.Text;
using static System.Console;

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
		int n = int.Parse(ReadLine());
		int max = 300000;
		int[] dp = new int[n + 1];
		List<int> sq = new List<int>{1};
		

		for (int i = 1, num = 1; i <= n; i++)
		{
			num += (i + 1);

			if (num > max) break;
			sq.Add(sq[i - 1] + num);
		}

		for (int i = 0; i <= n; i++)
		{
			dp[i] = i;
		}

		for (int i = 0; i < sq.Count; i++)
		{
			for (int j = sq[i]; j <= n; j++)
			{
				dp[j] = Math.Min(dp[j], dp[j - sq[i]] + 1);
			}
		}

		WriteLine(dp[n]);
	}
}