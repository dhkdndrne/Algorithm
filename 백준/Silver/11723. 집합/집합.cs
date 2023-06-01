using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

internal class Algorithm
{
	public static void Main(string[] args)
	{
		int n = int.Parse(ReadLine());
		int[] S = new int[20];
		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < n; i++)
		{
			string[] order = ReadLine().Split();
			int x = order.Length > 1 ? int.Parse(order[1]) - 1 : int.MinValue;

			switch (order[0])
			{
				case "add":

					if (S[x] == 0)
						S[x] = int.MaxValue;
					break;

				case "remove":

					if (S[x] != 0)
						S[x] = 0;
					break;

				case "check":

					if (S[x] != 0)
						sb.Append("1\n");
					else sb.Append("0\n");
				
					break;

				case "toggle":
					S[x] = S[x] == 0 ? int.MaxValue : 0;
					break;
				
				case "all":
					S = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
					break;
				
				case "empty":

					S = new int[20];
					break;
			}
		}
		
		Write(sb.ToString());
	}
}