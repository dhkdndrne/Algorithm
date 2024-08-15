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
		int N = int.Parse(ReadLine());
		int[] L = new int[N + 1];
		int[] J = new int[N + 1];

		string[] LInput = ReadLine().Split();
		string[] JInput = ReadLine().Split();

		for (int i = 1; i <= N; i++)
		{
			L[i] = int.Parse(LInput[i - 1]);
			J[i] = int.Parse(JInput[i - 1]);
		}

		int[,] dp = new int[N + 1, 101];

		for (int i = 1; i <= N; i++)
		{
			for (int j = 1; j <= 100; j++)
			{
				if (L[i] <= j)
				{
					dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - L[i]] + J[i]);
				}
				else
				{
					dp[i, j] = dp[i - 1, j];
				}
			}
		}

		WriteLine(dp[N, 99]);
	}
}