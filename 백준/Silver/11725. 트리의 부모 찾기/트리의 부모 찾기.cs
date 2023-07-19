using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Console;

internal class Algorithm
{
	private static StreamReader sr = new StreamReader(new BufferedStream(OpenStandardInput()));


	public static void Main(string[] args)
	{
		int N = int.Parse(sr.ReadLine());
		bool findOne = false;

		StringBuilder sb = new StringBuilder();
		int[] parentArr = new int[N + 1];
		parentArr[1] = -1;
		
		Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();

		for (int i = 0; i < N - 1; i++)
		{
			var node = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

			if (!dic.ContainsKey(node[0]))
				dic.Add(node[0], new List<int>());

			if (!dic.ContainsKey(node[1]))
				dic.Add(node[1], new List<int>());

			dic[node[0]].Add(node[1]);
			dic[node[1]].Add(node[0]);

		}

		Queue<int> q = new Queue<int>();
		q.Enqueue(1);

		while (q.Count > 0)
		{
			int num = q.Dequeue();

			for (int i = 0; i < dic[num].Count; i++)
			{
				if (parentArr[dic[num][i]] == 0)
				{
					parentArr[dic[num][i]] = num;
					q.Enqueue(dic[num][i]);
				}
			}
		}

		for (int i = 2; i < parentArr.Length; i++)
		{
			sb.Append($"{parentArr[i]}\n");
		}
		
		Write(sb.ToString());
	}
}