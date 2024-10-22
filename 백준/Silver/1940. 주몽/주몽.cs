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
		int m = int.Parse(ReadLine());

		int[] arr = Array.ConvertAll(ReadLine().Split(), int.Parse);
		Array.Sort(arr);

		int answer = 0;
		int left = 0;
		int right = n-1;

		while (left < right)
		{
			int sum = arr[left] + arr[right];
			if (sum == m)
			{
				answer++;
				right--;
				left++;
			}
			else if (sum < m)
			{
				left++;
			}
			else
			{
				right--;
			}
			
		}
		
		WriteLine(answer);
	}
}