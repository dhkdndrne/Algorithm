using static System.Console;
using System.Collections.Generic;
using System.Text;

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

	private int n,m;
	private int[] arr1;
	private int[] arr2;
	
	public void Sol()
	{
		StringBuilder sb = new StringBuilder();
		n = int.Parse(sr.ReadLine());
		arr1 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

		m = int.Parse(sr.ReadLine());
		arr2 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

		Array.Sort(arr1);

		for (int i = 0; i < m; i++)
		{
			sb.Append(Find(arr2[i])).AppendLine();
		}
		Write(sb.ToString());
	}

	private int Find(int target)
	{
		int left = 0;
		int right = n - 1;
		
		while (left <= right)
		{
			int mid = (left + right) / 2;
			
			if (arr1[mid] == target) return 1;
			if (target < arr1[mid]) right = mid - 1;
			else left = mid + 1;
		}

		return 0;
	}
}