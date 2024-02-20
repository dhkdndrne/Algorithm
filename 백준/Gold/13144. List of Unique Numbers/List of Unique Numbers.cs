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
	
	public void Sol()
	{
		int n = int.Parse(sr.ReadLine());
		int[] arr = Array.ConvertAll(sr.ReadLine().Split(),int.Parse);

		long left = 0;
		long right = 0;
		long answer = 0;
		bool[] visit = new bool[100001];
		
		while (right < n)
		{
			if (visit[arr[right]])
			{
				answer += right - left;
				visit[arr[left++]] = false;
			}
			else
			{
				visit[arr[right++]] = true;
			}
		}

		answer += (right - left) * (right - left + 1) / 2;
		sw.Write(answer);
		
		sw.Close();
		sr.Close();
	}
}