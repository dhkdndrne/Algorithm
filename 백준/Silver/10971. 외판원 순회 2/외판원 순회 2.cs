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
	private int min = int.MaxValue;
	private int[,] map;
	private int n;
	public void Solve()
	{
		n = int.Parse(ReadLine());
		map = new int[n, n];

		for (int i = 0; i < n; i++)
		{
			var input = Array.ConvertAll(ReadLine().Split(' '), int.Parse);
			for (int j = 0; j < n; j++)
			{
				map[i, j] = input[j];
			}
		}

		for (int i = 0; i < n; i++)
		{
			bool[] visit = new bool[n];
			visit[i] = true;
			Find(i, i, 0, 0,visit);
		}

		WriteLine(min);
	}

	private void Find(int start, int now, int sum, int cnt, bool[] visit)
	{
		if (sum > min)
			return;

		if (cnt == n - 1)
		{
			if (map[now,start] != 0)
				min = Math.Min(min, sum + map[now, start]);
			
			return;
		}

		for (int i = 0; i < n; i++)
		{
			if (visit[i]) continue;
			if (map[now, i] == 0) continue;

			visit[i] = true;
			Find(start,i, sum + map[now, i], cnt + 1, visit);
			visit[i] = false;
		}
	}
}