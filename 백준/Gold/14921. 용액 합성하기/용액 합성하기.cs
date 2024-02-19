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
		var arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
		
		int answer = -1;
		int min = int.MaxValue;
		int left = 0;
		int right = n-1;

		while (left < right)
		{
			int num = arr[left]+arr[right];
			if (Math.Abs(num) < min)
			{
				min = Math.Abs(num);
				answer = num;
			}

			if (num > 0) right--;
			else left++;
		}
		
		Write(answer);
		sw.Close();
		sr.Close();
	}
	
}