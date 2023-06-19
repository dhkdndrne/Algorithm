using static System.Console;
public class Class1
{
	public static void Main(string[] args)
	{
		int T = int.Parse(ReadLine());

		for (int i = 0; i < T; i++)
		{
			var v = Array.ConvertAll(ReadLine().Split(), int.Parse);
		
			int col = v[0];
			int row = v[1];
			int k = v[2];

			int[,] map = new int[col, row];

			for (int j = 0; j < k; j++)
			{
				int[] num = Array.ConvertAll(ReadLine().Split(), int.Parse);
				map[num[0], num[1]] = 1;
			}
			
			bool[,] visited = new bool[col, row];
			int count = 0;
			
			for (int x = 0; x < col; x++)
			{
				for (int y = 0; y < row; y++)
				{
					if(visited[x,y])
						continue;
					
					if (BFS(x, y, visited, map) != 0)
						count++;
				}
			}
			
			Write($"{count}\n");
		}
	}

	private static int BFS(int nx,int ny,bool[,] visited,int[,] map)
	{
		int[] dx = new[] { -1, 1, 0, 0 };
		int[] dy = new[] { 0, 0, -1, 1 };

		visited[nx, ny] = true;
		if (map[nx, ny] == 0)
			return 0;

		int cnt = 1;

		Queue<(int, int)> q = new Queue<(int, int)>();
		q.Enqueue((nx,ny));

		while (q.Count > 0)
		{
			var cur = q.Dequeue();
			int x = cur.Item1;
			int y = cur.Item2;

			for (int i = 0; i < 4; i++)
			{
				int newX = x + dx[i];
				int newY = y + dy[i];

				if (newX >= 0 && newY >= 0 && newX < map.GetLength(0) && newY < map.GetLength(1))
				{
					if (!visited[newX, newY] && map[newX, newY] == 1)
					{
						q.Enqueue((newX,newY));
						visited[newX, newY] = true;
						cnt++;
					}
				}
			}
		}
		return cnt;
	}
}
