using System.Text;
using static System.Console;

class Solutuin
{
	private static int[] parent;
	public static void Main(string[] args)
	{
		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);
		StringBuilder sb = new StringBuilder();
		int n = input[0];
		int m = input[1];
		
		parent = new int[n + 1];

		for (int i = 0; i <= n; i++)
		{
			parent[i] = i;
		}
        
		for (int i = 0; i < m; i++)
		{
			var vals = Array.ConvertAll(ReadLine().Split(), int.Parse);

			if (vals[0] == 0)
			{
				Union(vals[1],vals[2]);
			}
			else
			{
				sb.Append(CheckSameParent(vals[1], vals[2]) ? "yes" : "no").Append("\n");
			}
		}
		
		Write(sb.ToString());
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