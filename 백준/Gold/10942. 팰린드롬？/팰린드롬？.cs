using static System.Console;
using System.Collections;
using System.Text;

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
		int[] arr = new int[n + 1];
		bool[,] dp = new bool[n + 1,n + 1];

		var numbers = Array.ConvertAll(ReadLine().Split(), int.Parse);
		for (int i = 0; i < n; i++)
		{
			arr[i + 1] = numbers[i];
		}
		
		//자기자신
		for (int i = 1; i <= n; i++)
			dp[i, i] = true;
		
		// 2개 짜리 ex) aa ,bb
		for (int i = 1; i <= n - 1; i++)
		{
			if (arr[i] == arr[i + 1])
				dp[i, i + 1] = true;
		}

		for (int i = 2; i <= n - 1; i++)
		{
			for(int j = 1; j <= n - i; j++)
			{
				int k = i + j;
				if (arr[j] == arr[k] && dp[j + 1, k - 1])
					dp[j, k] = true;
				
			}
		}

		int cnt = int.Parse(ReadLine());
		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < cnt; i++)
		{
			var input = Array.ConvertAll(ReadLine().Split(), int.Parse);
		    sb.Append(dp[input[0], input[1]] ? 1 : 0).AppendLine();
		}
		
		Write(sb.ToString());
	}
}