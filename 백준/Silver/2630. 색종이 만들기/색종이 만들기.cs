using System;
using System.IO;
using static System.Console;

internal class Algorithm
{
	static StreamReader sr = new StreamReader(new BufferedStream(OpenStandardInput()));
	private static int wCnt, bCnt;
	public static void Main(string[] args)
	{
		int n = int.Parse(sr.ReadLine());
		int[,] map = new int[n, n];

		for (int y = 0; y < n; y++)
		{
			var line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
			for (int x = 0; x < n; x++)
			{
				map[y, x] = line[x];
			}
		}

		Find(n, 0, 0, map);
		
		Write($"{wCnt}\n{bCnt}");
	}

	private static void Find(int n, int x, int y, int[,] map)
	{
		int count = 0;
		for (int i = y; i < y + n; i++)
		{
			for (int j = x; j < x + n; j++)
			{
				if (map[i, j] == 1)
				{
					count++;
				}
			}
		}

		if (count == 0) wCnt++;
		else if(count == n*n) bCnt++;
		else
		{
			Find(n / 2, x, y + n / 2, map);         //1사분면
			Find(n / 2, x, y, map);                 //2사분면
			Find(n / 2, x + n / 2, y, map);         //3사분면
			Find(n / 2, x + n / 2, y + n / 2, map); // 4사분면
		}
	}
}