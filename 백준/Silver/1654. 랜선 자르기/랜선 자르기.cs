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

	private int n;
	public void Sol()
	{
		var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

		int k = input[0];
		n = input[1];

		int[] arr = new int[k];
		for (int i = 0; i < k; i++)
		{
			arr[i] = int.Parse(sr.ReadLine());
		}
		
		Find(arr);
	}

	private void Find(int[] arr)
	{
		long left = 1;
		long right = int.MaxValue;
		long answer = 0;
		while (left <= right)
		{
			long val = 0;
			long mid = (left + right) / 2;

			for (int i = 0; i < arr.Length; i++)
			{
				val += arr[i] / mid;
			}

			if (val >= n)
			{
				answer = mid;
				left = mid + 1;
			}
			else right = mid - 1;
		}

		Write(answer);
	}
}