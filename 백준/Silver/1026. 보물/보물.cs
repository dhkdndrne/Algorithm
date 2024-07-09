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
		int n = int.Parse(ReadLine());
		
		var a = Array.ConvertAll(ReadLine().Split(), int.Parse);
		var b = Array.ConvertAll(ReadLine().Split(), int.Parse);
		
		Array.Sort(a,(a,b)=> b.CompareTo(a));
		Array.Sort(b);
		
		int answer = 0;
		for (int i = 0; i < n; i++)
			answer += a[i] * b[i];
		
		WriteLine(answer);
	}
}