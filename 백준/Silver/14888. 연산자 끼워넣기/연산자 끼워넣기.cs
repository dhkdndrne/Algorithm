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
	private int n;
	private int[] numbers;
	private int[] mathOp;

	private int min = int.MaxValue;
	private int max = int.MinValue;

	public void Solve()
	{
		n = int.Parse(ReadLine());
		numbers = Array.ConvertAll(ReadLine().Split(' '), int.Parse);
		mathOp = Array.ConvertAll(ReadLine().Split(' '), int.Parse);

		DFS(1, numbers[0], mathOp[0], mathOp[1], mathOp[2], mathOp[3]);

		WriteLine(max);
		WriteLine(min);
	}

	private void DFS(int index, int current, int add, int sub, int mul, int div)
	{
		if (index == n || (add == 0 && sub == 0 && mul == 0 && div == 0))
		{
			max = Math.Max(max, current);
			min = Math.Min(min, current);
			return;
		}
		
		if (add > 0)
		{
			DFS(index + 1, current + numbers[index], add - 1, sub, mul, div);
		}
		if (sub > 0)
			DFS(index + 1, current - numbers[index], add, sub - 1, mul, div);
		if (mul > 0)
			DFS(index + 1, current * numbers[index], add, sub, mul - 1, div);
		if (div > 0)
		{
			int next;
			if (current < 0)
				next = -(-current / numbers[index]);
			else
				next = current / numbers[index];
			DFS(index + 1, next, add, sub, mul, div - 1);
		}
	}
}