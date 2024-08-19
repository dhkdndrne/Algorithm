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
	private int n, m;
	private int min = int.MaxValue;
	private List<(int x, int y)> chickenList;
	private int[,] city;
	public void solution()
	{
		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);
		n = input[0];
		m = input[1];

		city = new int[n, n];
		chickenList = new List<(int, int)>();

		for (int y = 0; y < n; y++)
		{
			input = Array.ConvertAll(ReadLine().Split(), int.Parse);
			for (int x = 0; x < n; x++)
			{
				city[y, x] = input[x];

				if (input[x] == 2)
					chickenList.Add((x, y));
			}
		}

		(int, int)[] list = new (int, int)[m];
		DFS(0, -1, chickenList.Count, list);
		
		WriteLine(min);
	}

	private void DFS(int cnt, int prev, int length, (int, int)[] list)
	{
		if (cnt == m)
		{
			min = Math.Min(min, BFS(list));
			return;
		}

		for (int i = 0; i < length; i++)
		{
			if (i > prev)
			{
				list[cnt] = chickenList[i];
				DFS(cnt + 1, i, length, list);
			}
		}
	}

	private int BFS((int x, int y)[] list)
	{
		int[] dirX = { -1, 1, 0, 0 };
		int[] dirY = { 0, 0, -1, 1 };

		Queue<(int x, int y, int dist)> q = new Queue<(int, int, int)>();
		bool[,] visit = new bool[n, n];

		for (int i = 0; i < m; i++)
		{
			q.Enqueue((list[i].x, list[i].y, 0));
			visit[list[i].y, list[i].x] = true;
		}

		int totalDist = 0;

		while (q.Count > 0)
		{
			(int x, int y, int dist) = q.Dequeue();

			if (city[y, x] == 1)
			{
				totalDist += dist;
			}

			for (int i = 0; i < 4; i++)
			{
				int nx = x + dirX[i];
				int ny = y + dirY[i];

				if (nx < 0 || nx > n - 1 || ny < 0 || ny > n - 1) continue;
				if (visit[ny, nx]) continue;

				visit[ny, nx] = true;
				q.Enqueue((nx, ny, dist + 1));
			}
		}
		return totalDist;
	}

}