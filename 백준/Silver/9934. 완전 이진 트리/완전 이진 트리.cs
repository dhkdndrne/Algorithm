using static System.Console;
using System.Collections.Generic;

class Program
{
	public static void Main(string[] args)
	{
		Solution solution = new Solution();
		solution.Solve();
		//WriteLine(solution.Main());
	}
}

public class Solution
{
	private List<List<int>> graph = new List<List<int>>();

	public void Solve()
	{
		int k = int.Parse(ReadLine());
		int[] numbers = Array.ConvertAll(ReadLine().Split(' '), int.Parse);

		for (int i = 0; i < numbers.Length; i++)
			graph.Add(new List<int>());

		Find(0,numbers);
		foreach (var level in graph)
			WriteLine(string.Join(" ", level));
	}

	private void Find(int depth,int[] arr)
	{
		if (arr.Length == 0) return;
		
		int mid = arr.Length / 2;
		
		if(graph.Count <= depth)
			graph.Add(new List<int>());
		
		graph[depth].Add(arr[mid]);
		
		int[] left = arr.Take(mid).ToArray();
		int[] right = arr.Skip(mid + 1).ToArray();

		Find(depth + 1, left);
		Find(depth + 1, right);
	}
}