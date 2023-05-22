using System;

internal class Algorithm
{
	public static void Main(string[] args)
	{
		int n = int.Parse(Console.ReadLine());

		int[,] result = new int[n+1, 3];
		int[,] arr = new int[n, 3];

		for (int i = 0; i < n; i++)
		{
			string[] colorValue = Console.ReadLine().Split();

			arr[i, 0] = int.Parse(colorValue[0]);
			arr[i, 1] = int.Parse(colorValue[1]);
			arr[i, 2] = int.Parse(colorValue[2]);
		}

		for (int i = 1; i <= arr.GetLength(0); i++)
		{
			result[i,0] = Math.Min(result[i - 1, 1], result[i - 1, 2]) + arr[i - 1, 0]; //R
			result[i,1] = Math.Min(result[i - 1, 0], result[i - 1, 2]) + arr[i - 1, 1]; //G
			result[i,2] = Math.Min(result[i - 1, 0], result[i - 1, 1]) + arr[i - 1, 2]; //B
		}

		int min = Math.Min(result[n, 0], result[n, 1]);
		Console.WriteLine(Math.Min(min, result[n, 2]));
	}
}