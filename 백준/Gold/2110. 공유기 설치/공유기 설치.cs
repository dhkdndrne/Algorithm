using static System.Console;
using System.Collections.Generic;
using System.Text;

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
		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);

		int n = input[0];
		int c = input[1];

		int[] arr = new int[n];

		for (int i = 0; i < n; i++)
			arr[i] = int.Parse(ReadLine());

		Array.Sort(arr);

		int left = 1;
		int right = arr[n - 1] - arr[0] + 1;

		while (left < right)
		{
			int mid = (left + right) / 2;

			int cnt = 1;
			int houseIndex = 0;

			for (int i = 1; i < n; i++)
			{
				if (arr[i] - arr[houseIndex] >= mid)
				{
					houseIndex = i;
					cnt++;
				}
			}

			if (cnt >= c)
				left = mid + 1;
			else right = mid;
		}

		WriteLine(right-1);
	}
}