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
		var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
		int n = input[0];
		int m = input[1];

		int[] arr = new int[n];

		for (int i = 0; i < n; i++)
		{
			arr[i] = int.Parse(sr.ReadLine());
		}
		
		Array.Sort(arr);
		
		int answer = int.MaxValue;
		int left = 0;
		int right = 0;
		
		while (left < n && right < n)
		{
			int num = arr[right] - arr[left];
			
			if (num < m)
			{
				right++;
			}
			else
			{
				answer = Math.Min(answer, num);
				left++;
			}

			if (num == m)
			{
				answer = m;
				break;
			}
		}
		
		Write(answer);
		sw.Close();
		sr.Close();
	}
}