using static System.Console;
using System.Collections.Generic;

class Solutuin
{
	public static void Main(string[] args)
	{
		Solution solution = new Solution();
		solution.Sol();

	}
}

public class Solution
{
	static StreamReader sr = new StreamReader(new BufferedStream(OpenStandardInput()));
	static StreamWriter sw = new StreamWriter(new BufferedStream(OpenStandardOutput()));

	public void Sol()
	{
		var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

		int n = input[0]; // 가수
		int m = input[1]; // pd

		Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
		int[] indegree = new int[n + 1];
		List<int> answer = new List<int>();

		Queue<int> q = new Queue<int>();

		for (int i = 0; i < m; i++)
		{
			input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

			for (int j = 2; j < input.Length; j++)
			{
				graph.TryAdd(input[j-1], new List<int>());
				graph[input[j - 1]].Add(input[j]);
				indegree[input[j]]++;
			}
		}

		for (int i = 1; i < indegree.Length; i++)
		{
			if (indegree[i] == 0)
				q.Enqueue(i);
		}

		while (q.Count > 0)
		{
			int num = q.Dequeue();
			
			if (graph.ContainsKey(num))
			{
				foreach (var v in graph[num])
				{
					indegree[v]--;
				
					if(indegree[v] == 0)
						q.Enqueue(v);
				}
			}
		
			answer.Add(num);
		}
		
		if(answer.Count != n)
			sw.WriteLine(0);
		else
		{
			foreach (var a in answer)
			{
				sw.WriteLine(a);
			}
		}
		
		sw.Close();
		sr.Close();
	}
}