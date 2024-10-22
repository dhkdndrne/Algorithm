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
	public void solution()
	{
		int G = int.Parse(ReadLine());
		bool found = false;
		
		int before = 1;
		int current = 1;
		double max = Math.Sqrt(Math.Pow((double)G,2));
		
		while (current <= (int)max)
		{
			int diff = (current * current) - (before * before);
			
			if (diff == G)
			{
				WriteLine(current);
				found = true;
			}
			
			if (diff < G)
				current++;
			else
				before++;
		}
        
		if (!found)
		{
			WriteLine(-1);
		}
	}
}