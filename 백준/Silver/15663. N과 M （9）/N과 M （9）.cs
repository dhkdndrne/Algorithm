using System;
using System.IO;
using static System.Console;
using System.Collections.Generic;
using System.Text;

internal class Algorithm
{
	static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));

	private static int N, M;
	private static int[] arr = new int[9];
	private static bool[] isVisted = new bool[9];
	private static int[] numArray;

	private static Dictionary<int, List<string>> dic = new Dictionary<int, List<string>>(9);
	public static void Main(string[] args)
	{
		var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

		N = input[0];
		M = input[1];

		numArray = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
		Array.Sort(numArray);
		
		StringBuilder sb = new StringBuilder();
		

		Find(0,sb);
	}

	private static void Find(int cnt, StringBuilder sb)
	{
		if (cnt == M)
		{
			sb.Clear();
			for (int i = 0; i < M; i++)
			{
				sb.Append($"{arr[i]} ");
			}

			if (dic.TryGetValue(arr[0], out var list))
			{
				if (list.Contains(sb.ToString()))
					return;
			}
			else dic.Add(arr[0], new List<string>());
			
			
			dic[arr[0]].Add(sb.ToString());
			
			sb.Append("\n");
			Write(sb.ToString());
		}
		else
		{
			for (int i = 0; i < N; i++)
			{
				if(isVisted[i]) continue;

				isVisted[i] = true;
				arr[cnt] = numArray[i];
				Find(cnt + 1, sb);
				isVisted[i] = false;
			}
		}
	}
}