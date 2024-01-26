using static System.Console;
using System.Collections.Generic;

class Solutuin
{
	public static void Main(string[] args)
	{
		Solution solution = new Solution();
		solution.Sol();
	}
}

public class Solution
{
	static StreamReader sr = new StreamReader(new BufferedStream(OpenStandardInput()));
	static StreamWriter sw = new StreamWriter(new BufferedStream(OpenStandardOutput()));

	private int n, s, answer;
	private int[] arr;
	private bool[] visit;
	public void Sol()
	{
		var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
		arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

		n = input[0];
		s = input[1];
		visit = new bool[n];

		Find(0,0);

		if (s == 0)
			answer--;
		
		Write(answer);
	}

	private void Find(int num, int index)
	{
		if (index == n)
		{
			if (num == s)
			{
				answer++;
			}
			return;
		}

		Find(num + arr[index], index + 1);
		Find(num, index + 1);
	}
}