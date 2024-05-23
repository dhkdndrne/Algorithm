using System;
using System.Collections.Generic;

public class Solution {
		public int[] solution(int[] sequence, int k)
	{
		int[] answer = new int[] { -1, -1 };

		int start = 0;
		int end = 0;
		int sum = 0;
		int min = int.MaxValue;

		int length = sequence.Length;
		while (start < length)
		{
			if (sum < k)
			{
				if (end < length)
					sum += sequence[end++];
                else sum -= sequence[start++];
			}
			else
			{
				sum -= sequence[start++];
			}

			if (sum == k)
			{
				if (end - start < min)
				{
					answer[0] = start;
					answer[1] = end - 1;

					min = end - start;
				}
			}
		}

		return answer;
	}
}