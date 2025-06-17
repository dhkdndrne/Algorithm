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
	private int n;
	private int max = 0;
	private List<(int length, int value)> list;
	public void Solve()
	{
		n = int.Parse(ReadLine());
		list = new List<(int, int)>();
		
		for (int i = 0; i < n; i++)
		{
			var input = Array.ConvertAll(ReadLine().Split(' '), int.Parse);
			list.Add((input[0], input[1]));
		}
		DFS(0,0);
		WriteLine(max);
	}

	private void DFS(int day, int sum)
	{
		if (day >= n)
		{
			max = Math.Max(max, sum);
			return;
		}
		
		if (day + list[day].length <= n)
			DFS(day + list[day].length, sum + list[day].value);
		
		DFS(day+1,sum);
	}
}