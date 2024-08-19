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

		LCS(a, b);
	}

	//최장 공통 문자열(Longest Common Substring)
	// private int LCS(string a, string b)
	// {
	// 	int n = a.Length;
	// 	int m = b.Length;
	// 	int max = 0;
	// 	int[,] dp = new int[n + 1, m + 1];
	//
	// 	for (int i = 1; i <= n; i++)
	// 	{
	// 		for (int j = 1; j <= m; j++)
	// 		{
	// 			if (a[i - 1] == b[j - 1])
	// 			{
	// 				dp[i, j] = dp[i - 1, j - 1] + 1;
	// 				max = Math.Max(dp[i, j], max);
	// 			}
	// 		}
	// 	}
	// 	return max;
	// }

	//최장 공통 부분수열(Longest Common Substring)
	private void LCS(string a, string b)
	{
		int n = a.Length;
		int m = b.Length;

		int[,] dp = new int[n + 1, m + 1];

		for (int i = 1; i <= n; i++)
		{
			for (int j = 1; j <= m; j++)
			{
				if (a[i - 1] == b[j - 1])
				{
					dp[i, j] = dp[i - 1, j - 1] + 1;
				}
				else
				{
					dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
				}
			}
		}

		int num = dp[n, m];
		WriteLine(num);

		if (num != 0)
		{
			Stack<char> st = new Stack<char>();
			int x = m;
			int y = n;
			while (num > 0)
			{
				bool check = false;

				if (dp[y - 1, x] == num)
				{
					y--;
					check = true;
				}
				else if (dp[y, x - 1] == num)
				{
					x--;
					check = true;
				}

				if (!check)
				{

					st.Push(y - 1 > x - 1 ? a[y - 1] : b[x - 1]);
					y--;
					x--;
					num = dp[y, x];
				}
			}

			StringBuilder sb = new StringBuilder();
			while (st.Count > 0)
			{
				sb.Append(st.Pop());
			}

			WriteLine(sb.ToString());
		}
	}

}