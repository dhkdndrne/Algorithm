using static System.Console;

internal class Algorithm
{
	private static int n;
	private static int[] answer = new int[2];

	private static bool[] l;
	private static bool[] r;
	private static int[,] board;

	static void Main(string[] args)
	{
		n = int.Parse(ReadLine());
		l = new bool[n * 2];
		r = new bool[n * 2];

		board = new int[n, n];

		for (int i = 0; i < n; i++)
		{
			var input = Array.ConvertAll(ReadLine().Split(), int.Parse);

			for (int j = 0; j < n; j++)
			{
				board[i, j] = input[j];
			}
		}

		Check(0, 0, 0, 0);
		Check(1, 0, 1, 0);

		WriteLine(answer[0] + answer[1]);
	}

	private static void Check(int x, int y, int color, int cnt)
	{
		if (x >= n)
		{
			y++;
			x = x % 2 == 0 ? 1 : 0; // 짝수 행에서는 0부터 시작, 홀수 행에서는 1부터 시작
		}

		if (y >= n)
		{
			answer[color] = Math.Max(answer[color], cnt);
			return;
		}

		if (board[y, x] == 1 && !l[x - y + n] && !r[x + y])
		{
			l[x - y + n] = r[x + y] = true;
			Check(x + 2, y, color, cnt + 1);
			l[x - y + n] = r[x + y] = false;
		}
		Check(x + 2, y, color, cnt);
	}
}