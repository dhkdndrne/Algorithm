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
	private int n, m;
	private int[] arr1;
	private int[] arr2;

	public void solution()
	{
		int t = int.Parse(ReadLine());
		StringBuilder sb = new StringBuilder();
		
		while (t > 0)
		{
			sb.Clear();
			n = int.Parse(ReadLine());
			arr1 = Array.ConvertAll(ReadLine().Split(), int.Parse);

			m = int.Parse(ReadLine());
			arr2 = Array.ConvertAll(ReadLine().Split(), int.Parse);

			Array.Sort(arr1);

			for (int i = 0; i < m; i++)
			{
				sb.AppendLine(Find(arr2[i]).ToString());
			}
			Write(sb.ToString());
			t--;
		}
	}

	private int Find(int num)
	{
		int left = 0;
		int right = n - 1;

		while (left <= right)
		{
			int mid = (left + right) / 2;

			if (arr1[mid] == num) return 1;
			if (num > arr1[mid]) left = mid + 1;
			else right = mid - 1;
		}

		return 0;
	}
}