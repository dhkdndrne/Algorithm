using System;
using static System.Console;

internal class Algorithm
{
	public static void Main(string[] args)
	{
		int n = int.Parse(ReadLine());

		int[] arr = Array.ConvertAll(ReadLine().Split(), int.Parse);

		Array.Sort(arr, (x, y) => x.CompareTo(y));

		int num = 0;
		for (int i = 0; i < n; i++)
		{
			int num2 = 0;
			for (int j = 0; j < i; j++)
			{
				num2 += arr[j];
			}
			num += arr[i] + num2;
		}

		Write(num);
	}
}