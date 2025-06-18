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
		int n = int.Parse(ReadLine());
		PriorityQueue<int, int> left = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a))); //중앙값 이하
		PriorityQueue<int, int> right = new PriorityQueue<int, int>();                                              //중앙값 이상
		
		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < n; i++)
		{
			int num = int.Parse(ReadLine());

			if (left.Count > 0 && right.Count == 0)
				right.Enqueue(num, num);
			else
				left.Enqueue(num, num);

			if (right.Count > 0 && MathF.Abs(right.Count - left.Count) > 1)
			{
				int move = left.Dequeue();
				right.Enqueue(move,move);
			}
			
			if (right.Count > 0 && left.Peek() > right.Peek())
			{
				int move1 = left.Dequeue();
				int move2 = right.Dequeue();

				left.Enqueue(move2, move2);
				right.Enqueue(move1, move1);
			}
			sb.Append(left.Peek()).AppendLine();
		}
		
		WriteLine(sb.ToString());
	}
}