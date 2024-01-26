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

	private int n,answer;
	private int[] arr;
	public void Sol()
	{
		n = int.Parse(sr.ReadLine());
		arr = new int[n];
		Find(0);
		
		Write(answer);
		sr.Close();
		sw.Close();
	}

	private void Find(int index)
	{
		if (index == n)
		{
			answer++;
			return;
		}

		for (int i = 0; i < n; i++)
		{
			arr[index] = i;

			if (Check(index))
			{
				Find(index + 1);
			}
		}
	}

	private bool Check(int index)
	{
		for (int i = 0; i < index; i++)
		{
			if (arr[i] == arr[index] || index - i == Math.Abs(arr[index] - arr[i]))
				return false;
		}
		return true;
	}
}