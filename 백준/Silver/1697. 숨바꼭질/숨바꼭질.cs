using System;
using System.Collections.Generic;
using static System.Console;

internal class Algorithm
{
	private static int n, k;
	private static int[] map = new int[100001];
	public static void Main(string[] args)
	{
		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);

		n = input[0];
		k = input[1];

		if(n == k)
		    Write("0");
		else 
			Find();
	}

	static void Find()
	{
		Queue<int> q = new Queue<int>();
		q.Enqueue(n);

		while (q.Count > 0)
		{
			int pos = q.Dequeue();

			for (int i = 0; i < 3; i++)
			{
				int next = i switch
				{
					0 => pos + 1,
					1 => pos - 1,
					2 => pos * 2
				};

				if (next > 100000 || next < 0) continue;
				if (map[next] != 0) continue;
				
				if (next == k)
				{
					Write(map[pos] + 1);
					q.Clear();
					break;
				}

				map[next] = map[pos] + 1;
				q.Enqueue(next);
			}
		}
	}
}