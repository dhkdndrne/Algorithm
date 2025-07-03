using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int[] players, int m, int k)
	{
		int answer = 0;

		int serverAmount = 0;
		Queue<int> server = new Queue<int>();

		for (int i = 0; i < 24; i++)
		{
			if (i >= k) serverAmount -= server.Dequeue();

			int need = Math.Max(players[i] / m - serverAmount, 0);
			server.Enqueue(need);
			serverAmount += need;
			answer += need;
			
		}

		return answer;
	}
}