using System.Text;
using static System.Console;

class Algorithm
{
	public static void Main(string[] args)
	{
		Solution solution = new Solution();
		solution.solution();
	}
}


public class Solution
{
	private int n; //세로
	private int m; //가로
	private string[,] board;
	public void solution()
	{
		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);
		n = input[0];
		m = input[1];

		board = new string[n, m];

		(int, int) R = (0, 0);
		(int, int) B = (0, 0);
		(int, int) O = (0, 0);

		for (int y = 0; y < n; y++)
		{
			string s = ReadLine();
			for (int x = 0; x < s.Length; x++)
			{
				board[y, x] = s[x].ToString();

				switch (board[y, x])
				{
					case "R":
						R = (x, y);
						break;
					case "B":
						B = (x, y);
						break;
					case "O":
						O = (x, y);
						break;
				}

			}
		}

		WriteLine(Find(R, B, O));
	}

	private int Find((int x, int y) R, (int x, int y) B, (int x, int y) O)
	{
		int[] dirX = { -1, 1, 0, 0 };
		int[] dirY = { 0, 0, -1, 1 };

		Queue<(int rx, int ry, int bx, int by, int cnt)> queue = new Queue<(int rx, int ry, int bx, int by, int cnt)>();
		queue.Enqueue((R.x, R.y, B.x, B.y, 0));

		var isVisit = new HashSet<(int, int, int, int)>();
		while (queue.Count > 0)
		{
			var cur = queue.Dequeue();
			int cnt = cur.cnt;

			if (cnt >= 10) return -1;

			for (int i = 0; i < 4; i++)
			{
				var (nrx, nry, rCount) = Move(cur.rx, cur.ry, dirX[i], dirY[i]);
				var (nbx, nby, bCount) = Move(cur.bx, cur.by, dirX[i], dirY[i]);

				if (board[nby,nbx] == "O") continue;

				// 빨간 구슬만 구멍에 빠지면 성공
				if (board[nry,nrx] == "O") return cnt + 1;

				// 두 구슬이 같은 위치에 있을 경우
				if (nrx == nbx && nry == nby)
				{
					if (rCount > bCount)
					{
						nrx -= dirX[i];
						nry -= dirY[i];
					}
					else
					{
						nbx -= dirX[i];
						nby -= dirY[i];
					}
				}

				if (!isVisit.Contains((nrx, nry, nbx, nby)))
				{
					isVisit.Add((nrx, nry, nbx, nby));
					queue.Enqueue((nrx, nry, nbx, nby, cnt + 1));
				}
			}
		}
		return -1;
	}

	private (int, int, int) Move(int x, int y, int dx, int dy)
	{
		int moveCount = 0;
		while (board[y + dy, x + dx] != "#" && board[y, x] != "O")
		{
			x += dx;
			y += dy;
			moveCount++;
		}
		return (x, y, moveCount);
	}
}