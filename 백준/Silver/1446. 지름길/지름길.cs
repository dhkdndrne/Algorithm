using static System.Console;
using System.Collections.Generic;

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
	public void solution()
	{
		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);

		int n = input[0];
		int d = input[1];

		List<(int, int, int)> shortcuts = new List<(int, int, int)>();

		for (int i = 0; i < n; i++)
		{
			input= Array.ConvertAll(ReadLine().Split(), int.Parse);
			int s = input[0];
			int e = input[1];
			int v = input[2];

			if (e <= d)
			{
				shortcuts.Add((s,e,v));
			}
		}

		int[] dist = new int[d + 1];
		for (int i = 0; i <= d; i++)
		{
			dist[i] = i;
		}

		for (int i = 0; i <= d; i++)
		{
			if (i > 0)
			{
				dist[i] = Math.Min(dist[i], dist[i - 1] + 1);
			}
			
			foreach (var shortcut in shortcuts)
			{
				int start = shortcut.Item1;
				int end = shortcut.Item2;
				int length = shortcut.Item3;
				if (i == start && end <= d)
				{
					dist[end] = Math.Min(dist[end], dist[i] + length);
				}
			}
		}
		
		WriteLine(dist[d]);
	}
}