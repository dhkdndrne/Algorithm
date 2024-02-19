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
		int[] arr = new int[10001];
		
		int n = input[0];
		int m = input[1];
		int answer = 0;

		int left = 0;
		int right = 0;
		int sum = 0;

		var t = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

		for (int i = 0; i < t.Length; i++)
		{
			arr[i] = t[i];
		}
		
		while (right <= n)
		{
			if (sum < m)
			{
				sum += arr[right++];
			}
			if (sum >= m)
			{
				if (sum == m)
					answer++;
				
				sum -= arr[left++];
			}
		}
		
		Write(answer);
		sw.Close();
		sr.Close();
	}
}