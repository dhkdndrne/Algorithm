using System;
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution 
{
		private int[] dist;
	private List<(int,int)>[] list;
	private Dictionary<int, int> dic = new Dictionary<int, int>();
	public int solution(int n, int[,] edge)
	{
		list = new List<(int,int)>[n + 1];
		dist = new int[n + 1]; 
		
		for (int i = 1; i <= n; i++)
		{
			list[i]= new List<(int, int)>();
			dist[i] = int.MaxValue;
		}

		for (int i = 0; i < edge.GetLength(0); i++)
		{
			int node1 = edge[i, 0];
			int node2 = edge[i, 1];

			list[node1].Add((node2,1));
			list[node2].Add((node1,1));

		}
		return Find(1, n);
	}

	private int Find(int start, int n)
	{
		bool[] isVisited = new bool[n + 1];
		var pq = new SortedSet<(int, int)>(Comparer<(int, int)>.Create((a, b) =>
		{
			int result = a.Item2.CompareTo(b.Item2);
			if (result == 0) return a.Item1.CompareTo(b.Item1);
			return result;
		}));
		pq.Add((start, 0));
		dist[start] = 0;

		while (pq.Count > 0)
		{
			var current = pq.Min;
			pq.Remove(current);

			int node = current.Item1;
			int currentDist = current.Item2;

			if (!isVisited[node])
			{
				isVisited[node] = true;

				foreach (var next in list[node])
				{
					int nextNode = next.Item1;
					int weight = next.Item2;
					int newDist = currentDist + weight;

					if (newDist < dist[nextNode])
					{
						dist[nextNode] = newDist;
						pq.Add((nextNode, newDist));
					}
				}
			}
		}

		int max = 0;
		foreach (var length in dist)
		{
			if (length == int.MaxValue) continue; // Skip unvisited nodes
			max = Math.Max(length, max);
			if (dic.ContainsKey(length))
				dic[length]++;
			else dic.Add(length, 1);
		}

		return dic[max];
	}
}