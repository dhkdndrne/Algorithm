using static System.Console;

public class Algorithm
{
	private static int n, m;
	private static List<(int, int)>[] graph = new List<(int, int)>[1001];
	private static int[] dist = new int[1001];
	
	public static void Main(string[] args)
	{
		n = int.Parse(ReadLine());
		m = int.Parse(ReadLine());
		
		for (int i = 1; i <= n; i++)
		{
			graph[i] = new List<(int, int)>();
			dist[i] = int.MaxValue;
		}
        
		for (int i = 0; i < m; i++)
		{
			var input = Array.ConvertAll(ReadLine().Split(), int.Parse);
			graph[input[0]].Add((input[1],input[2]));
		}
		
		int[] target = Array.ConvertAll(ReadLine().Split(), int.Parse);
		
		Dijkstra(target[0]);
		Write(dist[target[1]]);
	}

	private static void Dijkstra(int start)
	{
		bool[] isVisited = new bool[n + 1];
		dist[start] = 0;
		
		PriorityQueue<int,int> priorityQueue = new PriorityQueue<int,int>();
		priorityQueue.Enqueue(start,0);
        
		while(priorityQueue.Count > 0)
		{
			int node = priorityQueue.Dequeue();
			if (!isVisited[node])
			{
				isVisited[node] = true;

				foreach((int, int) next in graph[node])
				{
					dist[next.Item1] = Math.Min(dist[next.Item1], next.Item2 + dist[node]);
					priorityQueue.Enqueue(next.Item1, dist[next.Item1]);
				}
			}
		}
	}
}