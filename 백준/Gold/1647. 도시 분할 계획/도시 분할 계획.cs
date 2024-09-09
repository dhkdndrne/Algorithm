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
	private int[] parent;

	public void solution()
	{
		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);
		n = input[0];
		m = input[1];

		var costList = new int[m][];
		parent = new int[n + 1];

		for (int i = 1; i <= n; i++)
		{
			parent[i] = i;
		}

		for (int i = 0; i < m; i++)
		{
			input = Array.ConvertAll(ReadLine().Split(), int.Parse);
			costList[i] = new[] { input[0], input[1], input[2] };
		}

		Array.Sort(costList, (a, b) => a[2].CompareTo(b[2]));

		int count = 0;
		int dist = 0;
		int index = 0;
		while (count < n - 2)
		{
			var list = costList[index++];
			int a = Find(list[0]);
			int b = Find(list[1]);

			if (a != b)
			{
				Union(a,b);
				dist += list[2];
				count++;
			}
		}
		WriteLine(dist);
	}

	private void Union(int a, int b)
	{
		a = Find(a);
		b = Find(b);

		parent[b] = a;
	}

	private int Find(int a)
	{
		if (parent[a] == a) return a;
		return parent[a] = Find(parent[a]);
	}
}