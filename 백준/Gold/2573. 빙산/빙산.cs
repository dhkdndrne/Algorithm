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
	private int[] dirX = { -1, 1, 0, 0 };
	private int[] dirY = { 0, 0, -1, 1 };
	private Dictionary<(int x, int y), int> dic = new Dictionary<(int x, int y), int>();
	public void Sol()
	{
		var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

		n = input[0];
		m = input[1];
		board = new int[n, m];

		for (int y = 0; y < n; y++)
		{
			input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
			for (int x = 0; x < m; x++)
			{
				board[y, x] = input[x];

				if (input[x] != 0)
					dic.Add((x, y), 0);
			}
		}
		
		n--;
		m--;

		Find();
		
		sw.Close();
		sr.Close();
	}

	private void Find()
	{
		int answer = 0;
		
		while (true)
		{
			int cnt = 0;
			bool[,] visit = new bool[n + 1, m + 1];
			
			CalSurround();
			RemoveIce();

			if (dic.Count == 0)
			{
				answer = 0;
				break;
			}
			
			foreach (var v in dic)
			{
				int x = v.Key.x;
				int y = v.Key.y;
				
				if(visit[y,x]) 
					continue;
				
				CalIce(x,y,visit);
				cnt++;
			}
			
			answer++;
			
			if (cnt >= 2)
				break;
		}
		
		WriteLine(answer);
	}

	private void CalIce(int x,int y,bool[,] visit)
	{
		Queue<(int x, int y)> q = new Queue<(int, int)>();
		q.Enqueue((x,y));
		visit[y, x] = true;

		while (q.Count > 0)
		{
			var cur = q.Dequeue();

			for (int i = 0; i < 4; i++)
			{
				int nx = cur.x + dirX[i];
				int ny = cur.y + dirY[i];
				
				if(visit[ny,nx]) continue;
				if(board[ny,nx] == 0) continue;

				visit[ny, nx] = true;
				q.Enqueue((nx,ny));
			}
		}
	}
	
	private void CalSurround()
	{
		foreach (var v in dic)
		{
			int cnt = 0;
			
			int x = v.Key.x;
			int y = v.Key.y;
			
			for (int i = 0; i < 4; i++)
			{
				int curX = x + dirX[i];
				int curY = y + dirY[i];

				if (board[curY, curX] == 0)
				{
					cnt++;
				}
			}

			dic[v.Key] = cnt;
		}
	}
	private void RemoveIce()
	{
		foreach (var v in dic)
		{
			int x = v.Key.x;
			int y = v.Key.y;
			board[y, x] -= v.Value;

			if (board[y, x] <= 0)
			{
				dic.Remove(v.Key);
				board[y, x] = 0;
			}
		}
	}
}