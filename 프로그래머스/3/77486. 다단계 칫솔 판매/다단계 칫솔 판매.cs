using System;
using System.Collections.Generic;

public class Solution 
{
				private static Dictionary<string, (string root, int index)> dic = new Dictionary<string, (string root, int index)>();
		public int[] solution(string[] enroll, string[] referral, string[] seller, int[] amount)
		{
			int[] answer = new int[enroll.Length];

			for (int i = 0; i < enroll.Length; i++)
			{
				dic.Add(enroll[i], (referral[i], i));
			}

			for (int i = 0; i < seller.Length; i++)
			{
				DFS(seller[i], amount[i] * 100, answer);
			}

			return answer;
		}

		private void DFS(string seller, int money, int[] answer)
		{
			if (seller.Equals("-")) 
				return;

			int bonus = (int)(money * 0.1f);
			answer[dic[seller].index] += money - bonus;
			
			if(bonus > 0)
				DFS(dic[seller].root,bonus,answer);
		}
}