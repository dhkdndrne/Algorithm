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
			for (int j = 0; j <= i ; j++)
			{
				if (j == 0) triangle[i][j] += triangle[i - 1][j];
				else if (i == j) triangle[i][j] += triangle[i - 1][j - 1];
				else
				{
					triangle[i][j] = Math.Max(triangle[i][j] + triangle[i-1][j-1],triangle[i][j] + triangle[i-1][j]);
				}
			}
		}

		int max = int.MinValue;
		for (int i = 0; i < size; i++)
		{
			max = Math.Max(triangle[size - 1][i],max);
		}
		
		Write(max);
	}
}