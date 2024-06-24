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
		int n = int.Parse(ReadLine());
		bool[,] friends = new bool[n, n];
		int[,] dist = new int[n, n];
		int answer = 0;

		for (int i = 0; i < n; i++)
		{
			string input = ReadLine();
			for (int j = 0; j < n; j++)
			{
				bool y = input[j] == 'Y';

				dist[i, j] = y ? 1 : 99999;
				friends[i, j] = y ? true : false;
			}
		}

		for (int k = 0; k < n; k++)
		{
			for (int a = 0; a < n; a++)
			{
				for (int b = 0; b < n; b++)
				{
					if (a == b)
						continue;
					dist[a, b] = Math.Min(dist[a, b], dist[a, k] + dist[k, b]);
				}
			}
		}


		for (int i = 0; i < n; i++)
		{
			int cnt = 0;
			for (int j = 0; j < n; j++)
			{
				if (dist[i, j] <= 2) cnt++;
			}

			answer = Math.Max(cnt, answer);
		}

		WriteLine(answer);
	}
}