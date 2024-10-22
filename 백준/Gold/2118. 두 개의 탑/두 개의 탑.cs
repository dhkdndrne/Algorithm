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
		int totalDistance = 0;
		
		for (int i = 0; i < n; i++)
		{
			arr[i] = int.Parse(ReadLine());
			totalDistance += arr[i];
		}

		int max = 0;
		int start = 0;
		int sum = 0;
		
		for (int end = 0; end < n; end++)
		{
			sum += arr[end];
			totalDistance -= arr[end];

			while (sum > totalDistance)
			{
				sum -= arr[start];
				totalDistance += arr[start];
				start++;

				max = Math.Max(max, Math.Min(sum, totalDistance));
			}
			max = Math.Max(max, sum);
		}
		
		WriteLine(max);
	}
}