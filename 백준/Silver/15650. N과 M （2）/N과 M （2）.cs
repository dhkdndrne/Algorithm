using System;
using System.IO;
using static System.Console;

internal class Algorithm
{
	static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));

	private static int N,M;
	private static bool[] isVisted = new bool[9];
	private static int[] arr = new int[9];

	public static void Main(string[] args)
	{
		var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
		
		N = input[0];
		M = input[1];
		
		Find(1, 0);
	}

	private static void Find(int num, int cnt)
	{
		if (cnt == M)
		{
			for (int i = 0; i < M; i++)
			{
				Write($"{arr[i]} ");
			}
			Write("\n");
		}
		else
		{
			for (int i = num; i <= N; i++)
			{
				if (!isVisted[i])
				{
					isVisted[i] = true;
					arr[cnt] = i;
					Find(i+1,cnt+1);
					isVisted[i] = false;
				}	
			}
		}
	}
}