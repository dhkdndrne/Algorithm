using System;
using System.Collections.Generic;

public class Solution 
{
    	public int solution(int[,] targets)
	{
		int answer = 0;
		List <(int s, int e)> list = new List<(int s, int e)>();

		for (int i = 0; i < targets.GetLength(0); i++)
		{
			list.Add((targets[i, 0], targets[i, 1]));
		}

		list.Sort((a, b) => Compare(a, b));

		int end = int.MaxValue;
		answer++;

		foreach (var missile in list)
		{
			if (missile.e < end)
				end = missile.e;

			if (missile.s >= end)
			{
				answer++;
				end = missile.e;
			}
		}

		return answer;
	}

	private int Compare((int s,int e) a,(int s,int e) b)
	{
		int val = a.s.CompareTo(b.s);

		if (val == 0)
			return a.e.CompareTo(b.e);

		return val;
	}
}