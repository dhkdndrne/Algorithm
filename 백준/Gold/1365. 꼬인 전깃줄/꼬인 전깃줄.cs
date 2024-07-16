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
		int n = int.Parse(ReadLine());
		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);
		List<int> list = new List<int>() { input[0] };

		for (int i = 1; i < n; i++)
		{
			if (input[i] < list[list.Count - 1])
			{
				list[LowerBound(list, input[i])] = input[i];
			}
			else
			{
				list.Add(input[i]);
			}
		}
		
		WriteLine(n - list.Count);
	}

	private int LowerBound(List<int> list, int num)
	{
		int left = 0;
		int right = list.Count - 1;

		while (left < right)
		{
			int mid = (left + right) / 2;
			if (list[mid] >= num)
			{
				right = mid;
			}
			else left = mid + 1;
		}

		return right;
	}
}