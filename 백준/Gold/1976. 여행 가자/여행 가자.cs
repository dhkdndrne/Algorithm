using System.Text;
using static System.Console;

class Solutuin
{
	private static int[] parent;
	public static void Main(string[] args)
	{
		int n = int.Parse(ReadLine());
		int m = int.Parse(ReadLine());

		parent = new int[n + 1];
		for (int i = 0; i <= n; i++)
		{
			parent[i] = i;
		}

		for (int i = 1; i <= n; i++)
		{
			var input = Array.ConvertAll(ReadLine().Split(), int.Parse);

			for (int j = 0; j < input.Length; j++)
			{
				if (input[j] == 1)
				{
					Union(i, j + 1);
				}
			}
		}

		var aInput = Array.ConvertAll(ReadLine().Split(), int.Parse);

		for (int i = 1; i < aInput.Length; i++)
		{
			if (!CheckSameParent(aInput[i], aInput[i - 1]))
			{
				Write("NO");
                return;
			}
		}
		
		Write("YES");
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