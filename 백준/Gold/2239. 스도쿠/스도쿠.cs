using static System.Console;

class Solutuin
{
	private static int[,] map = new int[10, 10];
	private static List<(int x, int y)> list = new List<(int x, int y)>();
	private static bool isFinish = false;

	public static void Main(string[] args)
	{
		for (int i = 0; i < 9; i++)
		{
			var input = ReadLine();

			for (int j = 0; j < 9; j++)
			{
				map[i, j] = int.Parse(input[j].ToString());

				if (map[i, j] == 0)
				{
					list.Add((i, j));
				}
			}
		}
		Find(0);
	}

	private static void Find(int index)
	{
		if (isFinish)
			return;

		if (index == list.Count)
		{
			for (int i = 0; i < 9; i++)
			{
				for (int j = 0; j < 9; j++)
					Write(map[i, j]);

				Write("\n");
			}
			isFinish = true;
			return;
		}

		var num = list[index];

		for (int i = 1; i < 10; i++)
		{
			if (CheckPossible(num.x, num.y, i))
			{
				map[num.x, num.y] = i;
				Find(index + 1);
				map[num.x, num.y] = 0;
			}
		}
	}

	private static bool CheckPossible(int i, int j, int num)
	{
		for (int k = 0; k < 9; k++)
		{
			if (map[i, k] == num && j != k) return false; // 가로 라인
			if (map[k, j] == num && i != k) return false; // 세로 라인

			// 구역별 사각형
			int x = (i / 3) * 3 + (k / 3);
			int y = (j / 3) * 3 + (k  % 3);

			if (map[x, y] == num && !(x == i && y == j)) return false;
		}

		return true;
	}
}