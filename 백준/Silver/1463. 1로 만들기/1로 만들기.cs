using System;
using static System.Console;

internal class Algorithm
{
	public static void Main(string[] args)
	{
		int num = int.Parse(ReadLine());
		int[] arr = new int[num + 1];

		for (int i = 2; i <= num; i++)
		{
			arr[i] = arr[i - 1] + 1;

			if (i % 2 == 0)
				arr[i] = Math.Min(arr[i], arr[i / 2] + 1);
			if (i % 3 == 0)
				arr[i] = Math.Min(arr[i], arr[i / 3] + 1);
		}
		
		Write(arr[num]);
	}
	
}