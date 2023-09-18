using System.Text;
using static System.Console;

public class Algorithm
{
	private static int N;
	private static int[,] distanceMap;

	private static (int x, int y) sharkPos;

	public static void Main(string[] args)
	{
		N = int.Parse(ReadLine());

		int[,] map = new int[N, N];
		distanceMap = new int[N, N];

		for (int y = 0; y < N; y++)
		{
			var input = Array.ConvertAll(ReadLine().Split(), int.Parse);

			for (int x = 0; x < N; x++)
			{
				map[y, x] = input[x];

				if (input[x] == 9)
				{
					sharkPos = (x, y);
				}
			}
		}

		Find(map);
	}

	private static void Find(int[,] map)
	{
		int time = 0;
		int sharkSize = 2;
		int eatenFish = 0;

		int[] dirX = new[] { -1, 1, 0, 0 };
		int[] dirY = new[] { 0, 0, -1, 1 };

		List<(int x, int y)> canEatFishPosList = new List<(int x, int y)>(); //먹을 수 있는 생선 위치 리스트
		Queue<(int x, int y)> q = new Queue<(int x, int y)>();

		// 자기보다 큰 물고기는 못지나감
		// 크기가 같으면 지나갈 수 있음
		// 크기가 작으면 먹을 수 있음

		while (true)
		{
			ResetCheckMap();
			map[sharkPos.y, sharkPos.x] = 0;
			canEatFishPosList.Clear();

			if (eatenFish >= sharkSize)
			{
				eatenFish -= sharkSize;
				sharkSize++;
			}

			q.Enqueue(sharkPos);

			while (q.Count > 0) //타겟 물고기 먹으러 가는 반복문
			{
				var cur = q.Dequeue();

				for (int i = 0; i < 4; i++)
				{
					int newX = cur.x + dirX[i];
					int newY = cur.y + dirY[i];

					if (newX < 0 || newX >= N || newY < 0 || newY >= N) continue;
					if (distanceMap[newY, newX] != -1) continue;
					if (map[newY, newX] > sharkSize) continue;

					distanceMap[newY, newX] = distanceMap[cur.y, cur.x] + 1;
					q.Enqueue((newX, newY));

					// 물고기가 있고 물고기 사이즈가 상어보다 작을때
					if (map[newY, newX] < sharkSize && map[newY, newX] >= 1)
					{
						canEatFishPosList.Add((newX, newY));
					}
				}
			}

			if (canEatFishPosList.Count == 0)
			{
				Write(time);
				return;
			}

			if (canEatFishPosList.Count == 1)
			{
				sharkPos = canEatFishPosList[0];
				eatenFish++;
				time += distanceMap[sharkPos.y, sharkPos.x];
			}
			else
			{
				int minDist = Int32.MaxValue;

				//최단거리 찾아냄
				foreach (var fish in canEatFishPosList)
					minDist = Math.Min(minDist, distanceMap[fish.y, fish.x]);

				//최단거리에 있는 생선 빼고 나머지 다 삭제
				for (int i = canEatFishPosList.Count - 1; i >= 0; i--)
				{
					if (distanceMap[canEatFishPosList[i].y, canEatFishPosList[i].x] != minDist)
						canEatFishPosList.Remove((canEatFishPosList[i].x, canEatFishPosList[i].y));
				}

				if (canEatFishPosList.Count > 1)
				{
					canEatFishPosList.Sort(Compare);
				}

				sharkPos = canEatFishPosList[0];
				time += distanceMap[sharkPos.y, sharkPos.x];
				eatenFish++;
			}
		}
	}

	private static int Compare((int x, int y) a, (int x, int y) b)
	{
		int v = a.y.CompareTo(b.y);

		if (v == 0)
		{
			v = a.x.CompareTo(b.x);
		}

		return v;
	}

	private static void ResetCheckMap()
	{
		for (int y = 0; y < N; y++)
		{
			for (int x = 0; x < N; x++)
			{
				distanceMap[y, x] = -1;

				if (sharkPos.x == x && sharkPos.y == y)
				{
					distanceMap[y, x] = 0;
				}
			}
		}
	}
}