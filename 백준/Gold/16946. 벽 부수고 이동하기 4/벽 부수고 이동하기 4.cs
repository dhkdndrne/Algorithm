using System.Text;
using static System.Console;

internal class Algorithm
{
	private static int n, m;
	private static bool[,] visit;
	private static int areaNum = 1;
	private static int[] dirX = new[] { -1, 1, 0, 0 };
	private static int[] dirY = new[] { 0, 0, -1, 1 };
	
	static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();

		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);

		n = input[0];
		m = input[1];

		int[,] map = new int[n, m];
		int[,] areaMap = new int[n, m];
		visit = new bool[n, m];
		List<int> areaSizeList = new List<int>();
		HashSet<int> hashSet = new HashSet<int>();
		
		for (int y = 0; y < n; y++)
		{
			string nums = ReadLine();

			for (int x = 0; x < m; x++)
			{
				map[y, x] = int.Parse(nums[x].ToString());
			}
		}

		for (int y = 0; y < n; y++)
		{
			for (int x = 0; x < m; x++)
			{
				if (map[y, x] == 0 && !visit[y, x])
				{
					Find(x, y,map,ref areaMap, areaSizeList);
					areaNum++;
				}
			}
		}
		
		for (int y = 0; y < n; y++)
		{
			for (int x = 0; x < m; x++)
			{
				if (map[y, x] == 1)
				{
					hashSet.Clear();
					int num = 1;
					for (int i = 0; i < 4; i++)
					{
						int nx = x + dirX[i];
						int ny = y + dirY[i];

						if (nx < 0 || ny < 0 || nx >= m || ny >= n) continue;
						if(hashSet.Contains(areaMap[ny, nx])) continue;
						
						if (map[ny, nx] == 0)
						{
							hashSet.Add(areaMap[ny, nx]);
							num += areaSizeList[areaMap[ny, nx]-1];
						}
					}

					sb.Append(num % 10);
				}
				else sb.Append(0);
			}
			sb.Append("\n");
		}
		Write(sb.ToString());
	}

	private static void Find(int x, int y,int[,] map,ref int[,] areaMap, List<int> areaSizeList)
	{
		Queue<(int x, int y)> queue = new Queue<(int x, int y)>();
		queue.Enqueue((x, y));

		visit[y, x] = true;

		int count = 1;
		areaMap[y, x] = areaNum;

		while (queue.Count > 0)
		{
			var cur = queue.Dequeue();

			for (int i = 0; i < 4; i++)
			{
				int nx = cur.x + dirX[i];
				int ny = cur.y + dirY[i];

				if (nx < 0 || ny < 0 || nx >= m || ny >= n) continue;
				if (visit[ny, nx] ||map[ny,nx] !=0) continue;
	
				areaMap[ny, nx] = areaNum;
				visit[ny, nx] = true;
				count++;

				queue.Enqueue((nx, ny));
			}
		}

		areaSizeList.Add(count);
	}
}