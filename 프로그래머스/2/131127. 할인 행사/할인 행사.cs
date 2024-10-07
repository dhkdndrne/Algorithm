using System;
using System.Collections.Generic;


public class Solution 
{
	public int solution(string[] want, int[] number, string[] discount)
	{
				int answer = 0;
		Dictionary<string, int> dic = new Dictionary<string, int>();
		
		for (int i = 0; i < 10; i++)
		{
			if (!dic.ContainsKey(discount[i]))
				dic.Add(discount[i], 1);
			else dic[discount[i]]++;
		}

		int n = discount.Length - 10;
		
		//14 - 10 = 4
		for (int i = 0; i <= n; i++)
		{
			bool check = true;

			if (i != 0)
			{
				dic[discount[i - 1]]--;
				
				if (!dic.ContainsKey(discount[i + 9]))
					dic.Add(discount[i + 9], 1);
				else dic[discount[i + 9]]++;
			}
			
			for (int j = 0; j < want.Length; j++)
			{
				if (!dic.ContainsKey(want[j]) || number[j] > dic[want[j]])
				{
					check = false;
					break;
				}
			}

			if (check)
				answer++;
		}
		
		return answer;
	}
}