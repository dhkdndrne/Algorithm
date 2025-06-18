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
	public void Solve()
	{
		int n = int.Parse(ReadLine());

		PriorityQueue<int,int> pq = new PriorityQueue<int,int>();
		for (int i = 0; i < n; i++)
		{
			var input = Array.ConvertAll(ReadLine().Split(' '), int.Parse);

			foreach (var num in input)
			{
				pq.Enqueue(num, num);
				
				if(pq.Count > n)
					pq.Dequeue();
			}
		}
		
		WriteLine(pq.Dequeue());
	}
}