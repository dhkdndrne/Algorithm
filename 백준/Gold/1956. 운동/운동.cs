using static System.Console;
using System.Collections.Generic;
using System.Text;

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
	private readonly int MAX = 9999999;
	public void solution()
	{
		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);

		int v = input[0];
		int e = input[1];

		int[,] arr = new int[v + 1, v + 1];

		for (int y = 1; y <= v; y++)
		{
			for (int x = 1; x <= v; x++)
			{
				arr[y, x] = MAX;
			}
		}

		for (int i = 0; i < e; i++)
		{
			input = Array.ConvertAll(ReadLine().Split(), int.Parse);
			arr[input[0], input[1]] = input[2];
		}

		for (int k = 1; k <= v; k++)
		{
			for (int y = 1; y <= v; y++)
			{
				for (int x = 1; x <= v; x++)
				{
					arr[y, x] = Math.Min(arr[y, x], arr[k, x] + arr[y, k]);
				}
			}
		}

		int answer = MAX;
		for (int y = 1; y <= v; y++)
		{
			for (int x = y + 1; x <= v; x++)
			{
				if(arr[y,x] == MAX || arr[x,y] == MAX)
					continue;

				answer = Math.Min(answer, arr[y, x] + arr[x, y]);
			}
		}
		
		WriteLine(answer == MAX ? -1 : answer);
	}
	
}