using System;
using System.Collections.Generic;
using static System.Console;

internal class Algorithm
{
	public static void Main(string[] args)
	{
		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);
		Dictionary<string, int> dic = new Dictionary<string, int>();
		List<string> list = new List<string>();
		
		int n = input[0];
		int m = input[1];
		
		for (int i = 0; i < n + m; i++)
		{
			string name = ReadLine();

			if (dic.ContainsKey(name))
			{
				list.Add(name);
			}
			else dic.Add(name,1);
		}

        list.Sort();
		Write($"{list.Count}\n");
		foreach (var name in list)
		{
			Write($"{name}\n");
		}
	}
}