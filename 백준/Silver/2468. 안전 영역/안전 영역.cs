using static System.Console;

class Algorithm
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

	private int n;
	private int[,] board;
	private bool[,] visit;
	private List<(int x, int y)> list;
	private int[] dirX = { -1, 1, 0, 0 };
	private int[] dirY = { 0, 0, -1, 1 };
	public void Sol()
	{
		n = int.Parse(sr.ReadLine());
		board = new int[n, n];
		visit = new bool[n, n];
		list = new List<(int, int)>();
	
		int max = 0;
		for (int y = 0; y < n; y++)
		{
			var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
			for (int x = 0; x < n; x++)
			{
				board[y, x] = input[x];

				max = Math.Max(max, input[x]);
			}
		}

		int answer = 0;
		
		for (int i = 0; i < max; i++)
		{
			answer = Math.Max(answer, Find(i));
		}

		WriteLine(answer);
	}

	private int Find(int height)
	{
		int area = 0;
		list.Clear();
		
		for (int y = 0; y < n; y++)
		{
			for (int x = 0; x < n; x++)
			{
				visit[y, x] = false;

				if (board[y, x] <= height)
				{
					board[y, x] = -1;
					visit[y, x] = true;
				}
				else list.Add((x,y));	//안잠긴 구역 리스트에 추가
			}
		}

		foreach (var v in list)
		{
			if(visit[v.y,v.x]) continue;
			
			BFS(v);
			area++;
		}

		return area;
	}

	private void BFS((int x,int y) val)
	{
		Queue<(int x, int y)> q = new Queue<(int x, int y)>();
		q.Enqueue(val);
		visit[val.y, val.x] = true;
		
		while (q.Count >0)
		{
			var cur = q.Dequeue();
			for (int i = 0; i < 4; i++)
			{
				int nx = cur.x + dirX[i];
				int ny = cur.y + dirY[i];

				if (nx < 0 || nx > n - 1 || ny < 0 || ny > n - 1) continue;
				if(visit[ny,nx]) continue;
				
				visit[ny, nx] = true;
				q.Enqueue((nx,ny));
			}
		}
	}
}