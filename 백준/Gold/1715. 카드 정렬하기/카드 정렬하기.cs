using static System.Console;
using System.Collections.Generic;
using System.Text;

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
		int answer = 0;
		int n = int.Parse(ReadLine());
		PriorityQueue<int, int> pq = new();
		
		for (int i = 0; i < n; i++)
		{
			int num = int.Parse(ReadLine());
			pq.Enqueue(num,num);
		}

		while (pq.Count != 1)
		{
			int x = pq.Dequeue();
			int y = pq.Dequeue();

			int sum = x + y;
			answer += sum;
			
			pq.Enqueue(sum,sum);
		}
		
		WriteLine(answer);
	}
}