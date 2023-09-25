using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Console;

internal class Algorithm
{
	private static StreamReader sr = new StreamReader(new BufferedStream(OpenStandardInput()));

	public static void Main(string[] args)
	{
		long answer = 0;
		int t = int.Parse(ReadLine());
		
		int n = int.Parse(ReadLine());
		int[] a = Array.ConvertAll(ReadLine().Split(), int.Parse);
		
		int m = int.Parse(ReadLine());
		int[] b = Array.ConvertAll(ReadLine().Split(), int.Parse);

		List<int> v = new List<int>();
		List<int> w = new List<int>();
		
		for (int i = 0; i < n; i++)
		{
			int sum = a[i];
			v.Add(sum);
			for (int j = i + 1; j < n; j++)
			{
				sum += a[j];
				v.Add(sum);
			}
		}
		for (int i = 0; i < m; i++)
		{
			int sum = b[i];
			w.Add(sum);
			for (int j = i + 1; j < m; j++)
			{
				sum += b[j];
				w.Add(sum);
			}
		}
		
		w.Sort();

		long ans = 0;
		foreach (var item in v)
		{
			int diff = t - item;
			int ub = UpperBound(w, diff);
			int lb = LowerBound(w, diff);
			ans += ub - lb;
		}

		Console.WriteLine(ans);
	}
	
	static int LowerBound(List<int> list, int value)
	{
		int left = 0;
		int right = list.Count;

		while (left < right)
		{
			int mid = left + (right - left) / 2;
			if (list[mid] < value)
				left = mid + 1;
			else
				right = mid;
		}

		return left;
	}
	static int UpperBound(List<int> list, int value)
	{
		int left = 0;
		int right = list.Count;

		while (left < right)
		{
			int mid = left + (right - left) / 2;
			if (list[mid] <= value)
				left = mid + 1;
			else
				right = mid;
		}

		return left;
	}
}