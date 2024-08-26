using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
private List<(int node, int dist)>[] graph;
    private int[] answer = new int[2] { 0, int.MaxValue };
    private bool[] isVisited;
    private bool[] isTop;

    public int[] solution(int n, int[,] paths, int[] gates, int[] summits)
    {
        graph = new List<(int, int)>[n + 1];
        isVisited = new bool[n + 1];
        isTop = new bool[n + 1];

        for (int i = 1; i <= n; i++)
            graph[i] = new List<(int, int)>();

        for (int i = 0; i < paths.GetLength(0); i++)
        {
            graph[paths[i, 0]].Add((paths[i, 1], paths[i, 2]));
            graph[paths[i, 1]].Add((paths[i, 0], paths[i, 2]));
        }

        foreach (var summit in summits)
            isTop[summit] = true;

        Dijkstra(gates);

        return answer;
    }

    private void Dijkstra(int[] gates)
    {
        var pq = new SortedSet<(int cost, int node)>(Comparer<(int cost, int node)>.Create((a, b) =>
        {
            if (a.cost == b.cost) return a.node.CompareTo(b.node);
            return a.cost.CompareTo(b.cost);
        }));

        foreach (int gate in gates)
            pq.Add((0, gate));

        while (pq.Count > 0)
        {
            var cur = pq.Min;
            pq.Remove(cur);

            int node = cur.node;
            int cost = cur.cost;

            isVisited[node] = true;

            if (cost > answer[1])
                continue;

            if (isTop[node])
            {
                if (cost < answer[1])
                {
                    answer[0] = node;
                    answer[1] = cost;
                }
                else if (node < answer[0])
                {
                    answer[0] = node;
                }
                continue;
            }

            foreach (var next in graph[node])
            {
                int nextNode = next.node;
                int nextCost = Math.Max(cost, next.dist);

                if (isVisited[nextNode])
                    continue;

                pq.Add((nextCost, nextNode));
            }
        }
    }
}