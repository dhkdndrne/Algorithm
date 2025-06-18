using static System.Console;
using System.Collections.Generic;
using System.Text;

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
	public void Solve()
	{
		var input = Array.ConvertAll(ReadLine().Split(' '), int.Parse);
		
		List<int> list = new List<int>();
		
		list.AddRange(Array.ConvertAll(ReadLine().Split(' '), int.Parse));
		list.AddRange(Array.ConvertAll(ReadLine().Split(' '), int.Parse));

		list.Sort();

		StringBuilder sb = new StringBuilder();
		foreach (var num in list)
		{
			sb.Append(num).Append(' ');
		}
		
		WriteLine(sb.ToString());
	}
}