using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Console;

internal class Algorithm
{
	private static StreamReader sr = new StreamReader(new BufferedStream(OpenStandardInput()));

	private static int N, K;
	private static int[] map = new int[100001];
	
	public static void Main(string[] args)
	{
		var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

		N = input[0];
		K = input[1];

		if(N==K)
			Write("0");
		else 
			Find();
		
	}

	private static void Find()
	{
		Queue<int> q = new Queue<int>();
		q.Enqueue(N);
	
		while (q.Count > 0)
		{
			int pos = q.Dequeue();
			for (int i = 0; i < 3; i++)
			{
				int next = i switch
				{
					0 => pos * 2,
					1 => pos - 1,
					2 => pos + 1
				};

				if (next > 100000 || next < 0) continue;
				if (map[next] != 0) continue;
				
				if (next == K)
				{
					Write(i == 0 ? map[pos] : map[pos] + 1);
					q.Clear();
					break;
				}

				map[next] = i == 0 ? map[pos] : map[pos] + 1;
				q.Enqueue(next);
			}
		}
	}
}