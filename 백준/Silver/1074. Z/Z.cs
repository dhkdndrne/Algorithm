using System;
using static System.Console;

internal class Algorithm
{
	private static int answer, r, c;

	public static void Main(string[] args)
	{
		var n = Array.ConvertAll(ReadLine().Split(), int.Parse);

		c = n[1];
		r = n[2];

		int size = (int)Math.Pow(2, n[0]);
		Find(size, 0, 0);

		Write(answer);
	}

	private static void Find(int size, int x, int y)
	{
		if (size < 1)
			return;

		size /= 2;

		if (c < x + size && r >= y + size) // 2사분면
		{
			answer += size * size;
			Find(size, x, y + size);
		}
		else if (c < x + size && r < y + size) // 1사분면
		{
			Find(size, x, y);
		}
		else if (c >= x + size && r < y + size) // 3사분면
		{
			answer += (2 * size * size);
			Find(size, x + size, y);
		}
		else // 4사분면
		{
			answer += (3 * size * size);
			Find(size, x + size, y + size);
		}
	}
}