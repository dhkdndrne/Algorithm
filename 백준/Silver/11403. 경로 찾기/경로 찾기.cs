using System;
using System.Text;
using static System.Console;

internal class Algorithm
{
	public static void Main(string[] args)
	{
		int n = int.Parse(ReadLine());
		StringBuilder sb = new StringBuilder();
		
		int[,] map = new int[n, n];
		
		for (int y = 0; y < n; y++)
		{
			var lineNum = Array.ConvertAll(ReadLine().Split(), int.Parse);

			for (int x = 0; x < n; x++)
			{
				map[y, x] = lineNum[x] == 0 ? 9999 : lineNum[x];
			}
		}


		for (int k = 0; k < n; k++)
		{
			for (int y = 0; y < n; y++)
			{
				for (int x = 0; x < n; x++)
				{
					map[y, x] = Math.Min(map[y, x], map[y, k] + map[k, x]);
				}
			}
		}

		for (int y = 0; y < n; y++)
		{
			for (int x = 0; x < n; x++)
			{ 
				sb.Append(map[y, x] == 9999 ? "0 " : "1 ");
			}
			sb.Append("\n");
		}
		Write(sb.ToString());
	}
}