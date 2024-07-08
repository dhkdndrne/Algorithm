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
	private int[] arr = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
	private List<long> list = new List<long>();
	public void solution()
	{
		n = int.Parse(ReadLine());

		DFS(0, 0);
		list.Sort();

		if (list.Count < n)
		{
			WriteLine(-1);
			return;
		}
		
		WriteLine(list[n-1]);
	}

	private void DFS(long num, int index)
	{
		if(!list.Contains(num))
			list.Add(num);
		
		for (int i = index; i < 10; i++)
		{
			DFS(num * 10 + arr[i], i + 1);
		}
	}
}