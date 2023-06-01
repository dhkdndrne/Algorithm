using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

internal class Algorithm
{
	public static void Main(string[] args)
	{
		string word = ReadLine();

		Dictionary<string, int> alphabetCountDic = new Dictionary<string, int>();

		for (int i = 0; i < word.Length; i++)
		{
			string chagedChar = char.ToUpper(word[i]).ToString();

			if (alphabetCountDic.TryGetValue(chagedChar, out int count))
			{
				alphabetCountDic[chagedChar] = count + 1;
			}
			else
			{
				alphabetCountDic.Add(chagedChar, 1);
			}
		}

		List<string> maxKeys = new List<string>();
		int max = int.MinValue;

		foreach (var p in alphabetCountDic)
		{
			if (p.Value > max)
			{
				max = p.Value;
				maxKeys.Clear();
				maxKeys.Add(p.Key);
			}
			else if (p.Value == max)
			{
				maxKeys.Add(p.Key);
			}
		}

		Write(maxKeys.Count > 1 ? "?" : maxKeys[0]);
	}
}