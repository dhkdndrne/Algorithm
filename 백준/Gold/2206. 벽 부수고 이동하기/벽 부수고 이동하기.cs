using System.Text;
using static System.Console;

public class Algorithm
{
	private static int N, M;

	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();

		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);

		N = input[0];
		M = input[1];

		int[,] map = new int[N, M];
		int[][,] mapCheck = new int[2][,];

		for (int i = 0; i < 2; i++)
		{
			mapCheck[i] = new int[N, M];

			for (int y = 0; y < N; y++)
			{
				for (int x = 0; x < M; x++)
				{
					mapCheck[i][y, x] = 0;
				}
			}
		}
		for (int y = 0; y < N; y++)
		{
			var value = ReadLine();
			for (int x = 0; x < M; x++)
			{
				map[y, x] = int.Parse(value[x].ToString());
			}
		}

		if (N == 1 && M == 1)
		{
			Write(1);
			return;
		}
		
		BFS(mapCheck, map);
	}

	private static void BFS(int[][,] mapCheck, int[,] map)
	{
		int[] dirX = { -1, 1, 0, 0 };
		int[] dirY = { 0, 0, -1, 1 };

		int distance = 0;
		Queue<(int broken, int x, int y)> queue = new Queue<(int, int, int)>();
		queue.Enqueue((0, 0, 0));

		while (queue.Count > 0)
		{
			var node = queue.Dequeue();

			for (int i = 0; i < 4; i++)
			{
				int newX = dirX[i] + node.x;
				int newY = dirY[i] + node.y;
				int broken = node.broken;

				distance = mapCheck[broken][node.y, node.x] + 1;

				if (newX == M - 1 && newY == N - 1)
				{
					Write(distance + 1);
					return;
				}

				if (newX < 0 || newX >= M || newY < 0 || newY >= N)
					continue;

				if (map[newY, newX] == 1 && broken == 0 && mapCheck[1][newY, newX] == 0)
				{
					queue.Enqueue((1, newX, newY));
					mapCheck[1][newY, newX] = distance;
				}
				else if (map[newY, newX] == 0 && mapCheck[broken][newY, newX] == 0)
				{
					queue.Enqueue((broken, newX, newY));
					mapCheck[broken][newY, newX] = distance;
				}
			}
		}

		Write(-1);
	}
}