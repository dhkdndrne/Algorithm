using static System.Console;
using System.Collections.Generic;
using System.Text;

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
	private int n, m, k, x;
	private List<int>[] graph; // 인접 리스트
	private int[] dist;

	public void solution()
	{
		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);
        
		n = input[0];
		m = input[1];
		k = input[2];
		x = input[3];

		graph = new List<int>[n + 1];
		dist = new int[n + 1];

		for (int i = 1; i <= n; i++)
		{
			graph[i] = new List<int>();
			dist[i] = int.MaxValue;
		}

		for (int i = 0; i < m; i++)
		{
			input = Array.ConvertAll(ReadLine().Split(), int.Parse);
			graph[input[0]].Add(input[1]);
		}

		Find(x);
        
		bool check = false;
		StringBuilder sb = new StringBuilder();
		for (int i = 1; i <= n; i++)
		{
			if (dist[i] == k)
			{
				sb.AppendLine(i.ToString());
				check = true;
			}
		}

		if (!check)
		{
			sb.AppendLine("-1");
		}

		Write(sb.ToString());
	}

	private void Find(int start)
	{
		var pq = new PriorityQueue<int, int>(); // 거리 우선순위 큐
		pq.Enqueue(start, 0);
		dist[start] = 0;

		while (pq.Count > 0)
		{
			var cur = pq.Dequeue();
			int node = cur;
			int distance = dist[node];

			if (dist[node] < distance) continue;

			foreach (var next in graph[node])
			{
				int nextDist = distance + 1;

				if (nextDist < dist[next])
				{
					dist[next] = nextDist;
					pq.Enqueue(next, nextDist);
				}
			}
		}
	}
}