using System;

public class Solution 
{
   	public long solution(int[] sequence)
	{
		long answer = 0;
		int length = sequence.Length;
		long[,] dp = new long[length, 2];

		dp[0, 0] = sequence[0];
		dp[0, 1] = -sequence[0];

		answer = Math.Max(dp[0, 0], dp[0, 1]);

		for (int i = 1; i < length; i++)
		{
			dp[i, 0] = Math.Max(sequence[i], dp[i - 1, 1] + sequence[i]);
			dp[i, 1] = Math.Max(-sequence[i], dp[i - 1, 0] - sequence[i]);

			answer = Math.Max(answer, dp[i,0]);
			answer = Math.Max(answer, dp[i,1]);
		}

		return answer;
	}
}