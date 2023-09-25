using System.Text;
using static System.Console;

public class Algorithm
{
	public static void Main(string[] args)
	{
		Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

		int t = int.Parse(ReadLine());
		Queue<int> q = new Queue<int>();
		StringBuilder sb = new StringBuilder();
		
		for (int i = 0; i < t; i++)
		{
			var input = Array.ConvertAll(ReadLine().Split(), int.Parse);

			int n = input[0];
			int k = input[1];

			int[] times = Array.ConvertAll(ReadLine().Split(), int.Parse);
			int[] result = new int[n + 1];
			int[] indegree = new int[n + 1];
            graph.Clear();
            
			for (int j = 0; j < k; j++)
			{
				var val = Array.ConvertAll(ReadLine().Split(), int.Parse);

				if (!graph.ContainsKey(val[0]))
					graph.Add(val[0], new List<int>() { val[1] });
				else
					graph[val[0]].Add(val[1]);

				indegree[val[1]]++;
			}

			for (int j = 1; j < indegree.Length; j++)
			{
				if (indegree[j] == 0)
				{
					result[j] = times[j - 1];
					q.Enqueue(j);
				}
			}

			while (q.Count > 0)
			{
				int vertex = q.Dequeue();

				if (graph.TryGetValue(vertex, out var list))
				{
					foreach (var v in list)
					{
						result[v] = Math.Max(result[v], result[vertex] + times[v-1]);

						indegree[v]--;

						if (indegree[v] == 0)
							q.Enqueue(v);

					}
				}
			}

			int target = int.Parse(ReadLine());
			sb.Append(result[target]).Append("\n");
		}
		
		Write(sb.ToString());
	}
}