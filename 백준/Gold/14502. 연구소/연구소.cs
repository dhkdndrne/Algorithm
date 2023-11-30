using static System.Console;

internal class Algorithm
{
	public static void Main(string[] args)
	{
		Solution solution = new Solution();
		solution.Play();
	}

	public class Solution
	{
		private static int n, m;
		private static int[,] map;
		private static int answer;
		public void Play()
		{
			Init();
			DFS(0);
			
			Write(answer);
		}

		private void Init()
		{
			var input = Array.ConvertAll(ReadLine().Split(), int.Parse);

			n = input[0];
			m = input[1];
			map = new int[n, m];

			for (int i = 0; i < n; i++)
			{
				var line = Array.ConvertAll(ReadLine().Split(), int.Parse);

				for (int j = 0; j < line.Length; j++)
				{
					map[i, j] = line[j];
				}
			}
		}

		private void DFS(int wallCount)
		{
			if (wallCount == 3)
			{
				BFS();
				return;
			}

			for (int y = 0; y < n; y++)
			{
				for (int x = 0; x < m; x++)
				{
					if (map[y, x] == 0)
					{
						map[y, x] = 1;
						DFS(wallCount +1);
						map[y, x] = 0;
					}
				}
			}
		}
		
		private void BFS()
		{
			Queue<(int x, int y)> queue = new Queue<(int x, int y)>();
			
			for (int y = 0; y < n; y++)
			{
				for (int x = 0; x < m; x++)
				{
					if (map[y, x] == 2)
					{
						queue.Enqueue((x,y));
					}
				}
			}

			int[,] copyMap = (int[,])map.Clone();

			int[] dirX = { -1, 1, 0, 0 };
			int[] dirY = { 0, 0, -1, 1 };
			
			while (queue.Count > 0)
			{
				var t = queue.Dequeue();
				
				for (int i = 0; i < 4; i++)
				{
					int nx = t.x + dirX[i];
					int ny = t.y + dirY[i];

					if (nx >= 0 && nx < m && ny >= 0 && ny < n)
					{
						if (copyMap[ny, nx] == 0)
						{
							queue.Enqueue((nx,ny));
							copyMap[ny, nx] = 2;
						}
					}
				}
			}

			int cnt = 0;
			for (int y = 0; y < n; y++)
			{
				for (int x = 0; x < m; x++)
				{
					if (copyMap[y, x] == 0)
					{
						cnt++;
					}
				}
			}
			answer = Math.Max(answer, cnt);
		}
	}
}