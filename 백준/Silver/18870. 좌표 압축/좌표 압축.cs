using System;
using System.IO;
using System.Text;
using static System.Console;

internal class Algorithm
{
	static StreamReader sr = new(new BufferedStream(OpenStandardInput()));
	
	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();
		int n = int.Parse(sr.ReadLine());
		int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

		(int num, int index)[] arr = new (int, int)[n];

		for (int i = 0; i < n; i++)
		{
			arr[i] = (input[i], i);
		}

		Array.Sort(arr);

		int[] answer = new int[n];
		int index = 0;
		answer[arr[0].index] = index;

		for (int i = 1; i < n; i++)
		{
			if (arr[i - 1].num != arr[i].num)
				index++;

			answer[arr[i].index] = index;
		}
		
		for (int i = 0; i < answer.Length; i++)
		{
			sb.Append(answer[i]);

			if (i < answer.Length - 1)
				sb.Append(" ");
		}
		
		Write(sb.ToString());
	}
}