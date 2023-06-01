using System;
using System.Collections.Generic;
using static System.Console;

internal class Algorithm
{
	public static void Main(string[] args)
	{
		while (true)
		{
			int[] temp = Array.ConvertAll(ReadLine().Split(), int.Parse);

			Array.Sort(temp);
			
			int a = temp[0];
			int b = temp[1];
			int c = temp[2];

			if (a == 0 && b == 0 && c == 0)
				break;
			
			if(c >= a + b) Write("Invalid \n");
			else if (a == b && a == c) Write("Equilateral \n");
			else if (a != b && a != c && b != c) Write("Scalene \n");
			else Write("Isosceles \n");
		}
	}
}