using System;
using System.IO;
using System.Text;
using static System.Console;

internal class Algorithm
{
	static StreamReader sr = new StreamReader(new BufferedStream(OpenStandardInput()));
	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();

		var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

		int n = input[0];
		int m = input[1];

		int[] arr = new int[n + 1];
		int[] temp = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

		arr[0] = 0;
		for (int i = 1; i <= n; i++)
		{
			arr[i] += arr[i - 1] + temp[i - 1];
		}

		for (int i = 0; i < m; i++)
		{
			var value = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
			int index_1 = value[0];
			int index_2 = value[1];

			sb.Append($"{arr[index_2] - arr[index_1 - 1]}\n");
		}

		Write(sb.ToString());
	}
}