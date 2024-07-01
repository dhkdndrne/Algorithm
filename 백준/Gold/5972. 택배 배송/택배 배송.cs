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
	private int n;
	private List<(int, int)>[] map;

	public void solution()
	{
		var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
		n = input[0];
		int m = input[1];
		map = new List<(int, int)>[n + 1];

		for (int i = 0; i <= n; i++)
		{
			map[i] = new List<(int, int)>();
		}

		for (int i = 0; i < m; i++)
		{
			input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
			int a = input[0];
			int b = input[1];
			int c = input[2];
			map[a].Add((b, c));
			map[b].Add((a, c));
		}

		Dijkstra();
	}

	private void Dijkstra()
	{
		int[] distance = new int[n + 1];
		var pq = new PriorityQueue<(int dist, int v), int>();

		for (int i = 0; i <= n; i++)
		{
			distance[i] = int.MaxValue;
		}

		distance[1] = 0;
		pq.Enqueue((0, 1), 0);

		while (pq.Count > 0)
		{
			var (currentDist, currentNode) = pq.Dequeue();

			if (currentDist > distance[currentNode])
			{
				continue;
			}

			foreach ((int neighbor, int weight) in map[currentNode])
			{
				int newDist = distance[currentNode] + weight;
				if (newDist < distance[neighbor])
				{
					distance[neighbor] = newDist;
					pq.Enqueue((newDist, neighbor), newDist);
				}
			}
		}
		WriteLine(distance[n]);
	}
}