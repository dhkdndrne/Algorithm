using System.Text;
using System;
using static System.Console;
using System.Collections.Generic;

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
	private string N;
	private int K, len, answer = -1;
	private HashSet<string>[] hashSet;
	public void solution()
	{
		string[] input = ReadLine().Split();

		N = input[0];
		K = int.Parse(input[1]);
		len = N.Length;
		hashSet = new HashSet<string>[K+1];
		for (int i = 0; i <= K; i++)
		{
			hashSet[i] = new HashSet<string>();
		}
		
		DFS(0, N);
		
		WriteLine(answer);
	}

	private void DFS(int cnt, string num)
	{
		if (cnt == K)
		{
			answer = Math.Max(answer, int.Parse(num));
			return;
		}

		for (int i = 0; i < len - 1; i++)
		{
			for (int j = i + 1; j < len; j++)
			{
				if (i == 0 && num[j] == '0')
					continue;

				char[] newNum = num.ToCharArray();
				(newNum[i], newNum[j]) = (newNum[j], newNum[i]);
				string swapped = new string(newNum);
				
				if (hashSet[cnt + 1].Add(swapped))
				{
					DFS(cnt + 1, swapped);
				}
			}
		}
	}
}