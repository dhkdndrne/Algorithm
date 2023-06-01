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
		int S = 0;

		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < n; i++)
		{
			string[] order = ReadLine().Split();
			int x = order.Length > 1 ? int.Parse(order[1]) : int.MinValue;

			switch (order[0])
			{
				case "add":

					S |= (1 << x);
					break;

				case "remove":

					S &= ~(1 << x);
					break;

				case "check":

					if (S == (S | (1 << x)))
					{
						sb.Append("1\n");
					}
					else sb.Append("0\n");
					break;

				case "toggle":
					
					S ^= (1 << x);
					break;

				case "all":
					
					S = (1 << 21) - 1;
					break;

				case "empty":
					
					S = 0;
					break;
			}
		}
		Write(sb.ToString());
	}
}