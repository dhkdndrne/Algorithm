using static System.Console;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class Program
{
	public static void Main(string[] args)
	{
		Solution solution = new Solution();
		solution.Solve();
	}
}

public class Solution
{
	private int[] parents;
	private HashSet<int> visited = new HashSet<int>();
	
	public void Solve()
	{
		int t = int.Parse(ReadLine());

		while (t-- > 0)
		{
            visited.Clear();
			int n = int.Parse(ReadLine());
			parents = new int[n + 1];

			for (int i = 1; i < n; i++)
			{
				var input = Array.ConvertAll(ReadLine().Split(' '), int.Parse);
				parents[input[1]] = input[0];
			}

			var target = Array.ConvertAll(ReadLine().Split(' '), int.Parse);
			int a = target[0];
			int b = target[1];

			while (a != 0)
			{
				visited.Add(a);
				a = parents[a];
			}
			
			while (b != 0)
			{
				if (visited.Contains(b))
				{
					WriteLine(b);
					break;
				}
				b = parents[b];
			}
		}
	}
}