using static System.Console;
using System.Collections.Generic;

class Solutuin
{
	public static void Main(string[] args)
	{
		Solution solution = new Solution();
		solution.Sol();
	}
}

public class Solution
{
	static StreamReader sr = new StreamReader(new BufferedStream(OpenStandardInput()));
	static StreamWriter sw = new StreamWriter(new BufferedStream(OpenStandardOutput()));

	private int n, m;
	private int[,] board;
	private int curX, curY, dir;

	public void Sol()
	{
		var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
		n = input[0];
		m = input[1];
		board = new int[n, m];

		input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
		curX = input[1];
		curY = input[0];
		dir = input[2];

		for (int i = 0; i < n; i++)
		{
			input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
			for (int j = 0; j < input.Length; j++)
			{
				board[i, j] = input[j];
			}
		}
		WriteLine(Find());
	}

	private int Find()
	{
		int answer = 0;
		(int x, int y)[] dirArr = { (0, -1), (1, 0), (0, 1), (-1, 0) };
		// 북 -> 서 -> 남 -> 동
		bool check = true;

		while (check)
		{
			if (board[curY, curX] == 0)
			{
				board[curY, curX] = -1;
				answer++;
			}
			else if (board[curY, curX] == -1)
			{
				int nx = 0;
				int ny = 0;

				//빈칸이 없는경우
				if (FindDirty(dir, dirArr) == -1)
				{
					//후진
					var nDir = dirArr[BackStep(dir)];

					nx = curX + nDir.x;
					ny = curY + nDir.y;

					if (board[ny, nx] == 1)
					{
						check = false;
						continue;
					}

					curX = nx;
					curY = ny;
				}
				else
				{
					while (true)
					{
						//반시계 방향 회전
						dir = (dir + 3) % 4;

						//백스탭 2번 실행하면 전진 인덱스 얻음
						// int step = BackStep(dir);
						// step = BackStep(step);

						nx = curX + dirArr[dir].x;
						ny = curY + dirArr[dir].y;

						if (board[ny, nx] == 0)
						{
							curX = nx;
							curY = ny;
							break;
						}
					}
				}
			}
		}

		return answer;
	}

	private int BackStep(int dir)
	{
		return dir switch
		{
			0 => 2,
			1 => 3,
			2 => 0,
			3 => 1
		};
	}

	private int FindDirty(int dir, (int, int)[] dirArr)
	{
		int temp = dir;
		for (int i = 0; i < 4; i++)
		{
			(int x, int y) nDir = dirArr[temp];
			int nx = curX + nDir.x;
			int ny = curY + nDir.y;

			if (board[ny, nx] == 0)
			{
				return temp;
			}
			temp = (temp + 3) % 4;
		}
		return -1;
	}
}