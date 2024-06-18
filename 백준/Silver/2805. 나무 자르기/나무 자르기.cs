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
	private int n,m;
	private int[] arr = new int[1000000];
	public void solution()
	{
		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);
		n = input[0];
		m = input[1];

		arr = Array.ConvertAll(ReadLine().Split(), int.Parse);
		Array.Sort(arr);


		int left = 0;
		int right = int.MaxValue;

		while (left + 1 < right)
		{
			int mid = (right - left) / 2 + left;
			if (Check(mid)) left = mid;
			else right = mid;
		}
		
		WriteLine(left);
	}

	private bool Check(int mid)
	{
		long sum = 0;
		for (int i = 0; i < n; i++)
			if (arr[i] > mid) sum += arr[i] - mid;
		
		return sum >= m;
	}
}