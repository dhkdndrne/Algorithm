using static System.Console;
using System.Collections;
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
	private int[] weight;
	private List<(int v, int weight)>[] list;
	private bool[] isVisited;
	public void solution()
	{
		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);

		int n = input[0];
		int m = input[1];

		weight = new int[n + 1];
		isVisited = new bool[n + 1];
		list = new List<(int, int)>[n + 1];

		for (int i = 0; i <= n; i++)
		{
			weight[i] = int.MinValue;
			list[i] = new List<(int, int)>();
		}

		for (int i = 0; i < m; i++)
		{
			input = Array.ConvertAll(ReadLine().Split(), int.Parse);
			list[input[0]].Add((input[1], input[2]));
			list[input[1]].Add((input[0], input[2]));
		}
		input = Array.ConvertAll(ReadLine().Split(), int.Parse);

		Dijkstra(input[0],input[1]);
		WriteLine(weight[input[1]]);
	}

	private void Dijkstra(int start, int end)
	{
		PriorityQueue<(int node, int weight), int> pq = new PriorityQueue<(int node, int weight), int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
		pq.Enqueue((start, int.MaxValue), int.MaxValue);
		weight[start] = 0;

		while (pq.Count > 0)
		{
			var (currentNode, currentWeight) = pq.Dequeue();
            
			if (currentNode == end)
				break;

			if (isVisited[currentNode]) continue;
			isVisited[currentNode] = true;

			foreach (var (nextNode, nextWeight) in list[currentNode])
			{
				int newWeight = Math.Min(currentWeight, nextWeight);
				if (weight[nextNode] < newWeight)
				{
					weight[nextNode] = newWeight;
					pq.Enqueue((nextNode, weight[nextNode]), weight[nextNode]);
				}
			}
		}
	}
}