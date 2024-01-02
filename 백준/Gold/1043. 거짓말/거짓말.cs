using static System.Console;

class Solutuin
{
	private static int[] parent;
	public static void Main(string[] args)
	{
		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);

		int N = input[0]; //사람 수
		int M = input[1]; //파티 수
		int answer = M;

		// index 0 = 아는 사람 수
		// ~ 그 사람들의 번호
		List<int> knowPnumbers = Array.ConvertAll(ReadLine().Split(), int.Parse).ToList();
		knowPnumbers.RemoveRange(0, 1);
		
		List<int>[] partys = new List<int>[M];
		parent = new int[N + 1];

		if (knowPnumbers.Count == 0)
		{
			Write(answer);
			return;
		}

		//파티 참가 수, 그 사람들 번호
		for (int i = 0; i < M; i++)
		{
			partys[i] = Array.ConvertAll(ReadLine().Split(), int.Parse).ToList();
			partys[i].RemoveRange(0, 1);
		}

		for (int i = 1; i <= N; i++) parent[i] = i;
		for (int i = 0; i < M; i++)
		{
			for (int j = 1; j < partys[i].Count; j++)
			{
				Union(partys[i][0], partys[i][j]);
			}
		}

		for (int i = 0; i < M; i++)
		{
			bool check = true;
			for (int j = 0; j < partys[i].Count; j++)
			{
				if (!check) break;

				for (int k = 0; k < knowPnumbers.Count; k++)
				{
					if (CheckSameParent(partys[i][j], knowPnumbers[k]))
					{
						check = false;
						break;
					}
				}
			}

			if (!check) answer--;
		}

		Write(answer);
	}

	private static void Union(int a, int b)
	{
		a = FindParent(a);
		b = FindParent(b);
		parent[b] = a;
	}

	private static bool CheckSameParent(int a, int b)
	{
		a = FindParent(a);
		b = FindParent(b);
		return a == b;
	}
	private static int FindParent(int a)
	{
		if (a == parent[a]) return a;
		return parent[a] = FindParent(parent[a]);
	}
}