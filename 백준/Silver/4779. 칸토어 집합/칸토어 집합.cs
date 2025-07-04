using static System.Console;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class Program
{
	public static void Main(string[] args)
	{
		Solution solution = new Solution();
		solution.Solve();
	}
}

public class Solution
{
	public void Solve()
	{
		string s;
		while ((s = ReadLine()) != null)
		{
			int n = int.Parse(s);
			char[] arr = new char[(int)Math.Pow(3, n)];

			for (int i = 0; i < arr.Length; i++)
				arr[i] = '-';

			Divide(0, arr.Length, arr);
			WriteLine(new string(arr));
		}
	}

	private void Divide(int start, int length, char[] arr)
	{
		if (length == 0)
			return;

		int middle = length / 3;
		for (int i = start + middle; i < start + 2 * middle; i++)
		{
			arr[i] = ' ';
		}

		Divide(start, middle, arr);
		Divide(start + 2 * middle, middle, arr);
	}
}