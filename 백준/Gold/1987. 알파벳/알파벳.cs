using System;
using System.IO;
using static System.Console;

internal class Algorithm
{
	static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));

	private static bool[] isVisited = new bool[27];

	private static int R, C;
	private static int answer = 1;
	private static int[] dx = new[] { -1, 1, 0, 0 };
	private static int[] dy = new[] { 0, 0, -1, 1 };

	public static void Main(string[] args)
	{
		int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

		R = input[0];
		C = input[1];

		char[,] map = new Char[R, C];

		for (int i = 0; i < R; i++)
		{
			string s = sr.ReadLine();

			for (int j = 0; j < s.Length; j++)
			{
				map[i, j] = s[j];
			}
		}

		isVisited[map[0, 0] - 'A'] = true;
		Find(0, 0,answer, map);
		
		Write(answer);
	}

	private static void Find(int x, int y, int cnt, char[,] map)
	{
		answer = Math.Max(answer, cnt);
		
		for (int i = 0; i < 4; i++)
		{
			int curX = x + dx[i];
			int curY = y + dy[i];

			if (curX < 0 || curY < 0 || curX > C - 1 || curY > R - 1) continue;
			if (IsAlreadyVisitedAlphabet(map[curY, curX])) continue;

			isVisited[map[curY, curX] - 'A'] = true;
			Find(curX, curY,cnt +1,map);
			isVisited[map[curY, curX] - 'A'] = false;
		}
	}

	private static bool IsAlreadyVisitedAlphabet(char alphabet)
	{
		int index = alphabet - 'A';
		return isVisited[index];
	}
}