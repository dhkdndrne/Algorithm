using System;
using System.IO;
using static System.Console;
using System.Collections.Generic;

internal class Algorithm
{
	static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));

	public static void Main(string[] args)
	{
		int size = int.Parse(sr.ReadLine());

		int[][] triangle = new int[size][];

		for (int i = 0; i < size; i++)
		{
			triangle[i] = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
		}

		for (int i = 1; i < size; i++)
		{
			triangle[i][0] += triangle[i - 1][0];		// index = 0
			triangle[i][triangle[i].Length - 1] += triangle[i - 1][triangle[i - 1].Length - 1]; // index = length - 1

			int bIndex = 0;
			for (int j = 1; j < triangle[i].Length -1 ; j++)
			{
				int maxNum = int.MinValue;
				for (int k = bIndex; k <= j; k++)
				{
					int addNum = triangle[i][j] + triangle[i - 1][k];
					
					if (addNum > maxNum)
						maxNum = addNum;
				}

				triangle[i][j] = maxNum;
				bIndex++;
			}
		}

		int max = int.MinValue;

		for (int i = 0; i < triangle[size - 1].Length; i++)
		{
			if (triangle[size - 1][i] > max)
				max = triangle[size - 1][i];
		}
		
		Write(max);
	}
}