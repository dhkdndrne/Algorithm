using System.Text;
using System;
using static System.Console;
using System.Collections.Generic;

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
		int[] arr = new int[n];
		int[] sumArr = new int[n + 1];
		int totalDistance = 0;
		
		for (int i = 0; i < n; i++)
		{
			arr[i] = int.Parse(ReadLine());
			totalDistance += arr[i];
		}
		
		//누적합
		for (int i = 1; i <= n; i++)
		{
			sumArr[i] = sumArr[i - 1] + arr[i - 1];
		}

		int answer = 0;
		int start = 0;
		int end = 1;

		while (start < n)
		{
			int clockWiseDist = sumArr[end] - sumArr[start];
			int countClockwiseDist = totalDistance - clockWiseDist;

			int min = Math.Min(countClockwiseDist, clockWiseDist);

			answer = Math.Max(answer, min);

			end++;

			if (end == n)
			{
				start++;
				end = start + 1;

				if (end >= n) end = 0;
			}
		}
		
		WriteLine(answer);
	}
}