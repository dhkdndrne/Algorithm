using System;
using System.IO;
using static System.Console;

internal class Algorithm
{
	static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));

	public static void Main(string[] args)
	{
		var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

		int N = input[0]; //물건 수
		int K = input[1]; //무게

		int[,] arr = new int[N + 1, K + 1];
		int[] w = new int[N + 1];
		int[] v = new int[N + 1];
		
		for (int i = 1; i <= N; i++)
		{
			var temp = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
			w[i] = temp[0];
			v[i] = temp[1];
		}

		for (int i = 1; i <= N; i++)
		{
			for (int j = 1; j <= K; j++)
			{
				if (w[i] > j)
					arr[i, j] = arr[i - 1, j];	//이전 결과 복사
				else
				{
					arr[i, j] = Math.Max(arr[i - 1, j], arr[i - 1, j - w[i]] + v[i]);
				}
			}
		}
		
		Write(arr[N,K]);
	}
}