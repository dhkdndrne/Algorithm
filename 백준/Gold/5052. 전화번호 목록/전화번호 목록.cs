using static System.Console;
using System.Collections.Generic;

class Program
{
	public static void Main(string[] args)
	{
		Solution solution = new Solution();
		solution.Solve();
	}
}

public class Solution
{

	public void Solve()
	{
		int t = int.Parse(ReadLine());
		List<string> list = new List<string>();
		while (t-- > 0)
		{
			list.Clear();
			int n = int.Parse(Console.ReadLine());

			for (int i = 0; i < n; i++)
			{
				list.Add(Console.ReadLine());
			}
			list.Sort();

			bool isConsistent = true;
			for (int i = 0; i < n - 1; i++) 
			{
				if (list[i + 1].StartsWith(list[i])) 
				{
					isConsistent = false;
					break;
				}
			}
			WriteLine(isConsistent ? "YES" : "NO");
		}
	}
}