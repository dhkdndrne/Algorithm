using System;

class Solution
{
		public int solution(int[] sticker)
	{
		int n = sticker.Length;

		if (n == 1) return sticker[0];
		else if (n == 2) return Math.Max(sticker[0], sticker[1]);
		
		int[] dp = new int[n];
		int[] dp2 = new int[n];

		dp[0] = sticker[0];
		dp[1] = sticker[0];
		dp2[0] = 0;
		dp2[1] = sticker[1];
		
		for (int i = 2; i <n; i++)
		{
			dp[i] = Math.Max(dp[i - 1], dp[i - 2] + sticker[i]);
			dp2[i] = Math.Max(dp2[i - 1], dp2[i - 2]+ sticker[i]);
		}
		
		return Math.Max(dp[dp.Length-2],dp2[dp2.Length -1]);
	}
}