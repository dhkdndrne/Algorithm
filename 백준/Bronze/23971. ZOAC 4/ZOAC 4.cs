using System;
using System.Collections.Generic;
using static System.Console;

internal class Algorithm
{
	public static void Main(string[] args)
	{
		int[] temp = Array.ConvertAll(ReadLine().Split(), int.Parse);

		// 행 h 열 w
		//세로 n 가로 m

		int h = temp[0];
		int w = temp[1];

		int n = temp[2];
		int m = temp[3];
		
		int cnt = 0;

		//세로로 n칸 또는 가로로 M칸
		for (int y = 0; y < h; y += (n+1))
		{
			for (int x = 0; x < w; x += (m+1))
			{
				cnt++;
			}
		}

		Write(cnt);
	}
}