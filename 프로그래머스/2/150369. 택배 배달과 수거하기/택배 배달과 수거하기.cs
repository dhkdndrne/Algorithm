using System;

public class Solution 
{
    public long solution(int cap, int n, int[] deliveries, int[] pickups)
		{
			long answer = 0;

			int get = 0;
			int deliver = 0;

			for (int i = n - 1; i >= 0; i--)
			{
				if (deliveries[i] != 0 || pickups[i] != 0)
				{
					int count = 0;
					while (deliver < deliveries[i] || get < pickups[i])
					{
						deliver += cap;
						get += cap;
						count++;
					}

					deliver -= deliveries[i];
					get -= pickups[i];

					answer += ((i + 1) * count * 2);
				}
			}

			return answer;
		}
}