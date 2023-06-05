using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

internal class Algorithm
{
	public static void Main(string[] args)
	{
		int p = int.Parse(ReadLine());

		for (int i = 0; i < p; i++)
		{
			var list = Array.ConvertAll(ReadLine().Split(), int.Parse).ToList();
			list.RemoveAt(0);
			WriteLine($"{i+1} {Solution(list)}");
		}
	}

	static int Solution(List<int> list)
	{
		int answer = 0;
		for (int i = 1; i < 20; i++)
		{
			for (int j = i - 1; j >= 0; j--)
			{
				if (list[j] > list[i])
					answer++;
			}
		}
		return answer;
	}
}