using System;
using System.IO;
using static System.Console;
using System.Text;

internal class Algorithm
{
	private static StreamReader sr = new StreamReader(new BufferedStream(OpenStandardInput()));

	public static void Main(string[] args)
	{
		string s = sr.ReadLine();
		string bomb = sr.ReadLine();
		StringBuilder sb = new StringBuilder();
		
		for (int i = 0; i < s.Length; i++)
		{
			sb.Append(s[i]);

			if (sb.Length >= bomb.Length)
			{
				bool check = true;
				for (int j = 0; j < bomb.Length; j++)
				{
					char c1 = sb[sb.Length - bomb.Length + j];
					char c2 = bomb[j];

					if (c1 != c2)
					{
						check = false;
						break;
					}
				}

				if (check)
				{
					sb.Remove(sb.Length - bomb.Length, bomb.Length);
				}
			}
		}
		
		Write(sb.Length == 0 ? "FRULA" : sb.ToString());
	}
	
}

