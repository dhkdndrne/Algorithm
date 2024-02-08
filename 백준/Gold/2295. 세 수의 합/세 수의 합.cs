using static System.Console;
using System.Collections.Generic;

class Solutuin
{
	public static void Main(string[] args)
	{
		Solution solution = new Solution();
		solution.Sol();
	}
}

public class Solution
{
	static StreamReader sr = new StreamReader(new BufferedStream(OpenStandardInput()));
	static StreamWriter sw = new StreamWriter(new BufferedStream(OpenStandardOutput()));

	public void Sol()
	{
		int n = int.Parse(sr.ReadLine());
		int answer = 0;
		int[] arr = new int[n];

		for (int i = 0; i < n; i++)
		{
			arr[i] = int.Parse(sr.ReadLine());
		}

		int[] xySum = new int[n * n];

		for (int i = 0, cnt = 0; i < n; i++)
		{
			for (int j = 0; j < n; j++)
			{
				xySum[cnt++] = arr[i] + arr[j];
			}
		}

		 Array.Sort(xySum);
		
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < n; j++)
			{
				if (Find(xySum, arr[i] - arr[j]))
				{
					answer = Math.Max(answer, arr[i]);
				}
			}
		}
		Write(answer);
	}
	private bool Find(int[] sumArr, int target)
	{
		int left = 0;
		int right = sumArr.Length - 1;

		while (left <= right)
		{
			int mid = (left + right) / 2;

			if (sumArr[mid] > target) right = mid - 1;
			else if (sumArr[mid] < target) left = mid + 1;
			else return true;
		}
		return false;
	}
}