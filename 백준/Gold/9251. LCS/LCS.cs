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
		string a = ReadLine();
		string b = ReadLine();

		WriteLine(LCS(a, b));
	}

	private int LCS(string a, string b)
	{
		int n = a.Length;
		int m = b.Length;

		int[,] dp = new int[n + 1, m + 1];

		for (int i = 1; i <= n; i++)
		{
			for (int j = 1; j <= m; j++)
			{
				if (a[i - 1] == b[j- 1])
				{
					dp[i, j] = dp[i - 1, j - 1] + 1;
				}
				else
				{
					dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
				}
			}
		}

		return dp[n, m];
	}

}