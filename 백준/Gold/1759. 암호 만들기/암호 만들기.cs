using System.Text;
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


	private int l, c;
	private List<char> list;
	private char[] answer;
	private StringBuilder sb = new StringBuilder();
	public void Sol()
	{
		var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
		l = input[0];
		c = input[1];

		list = Array.ConvertAll(sr.ReadLine().Split(), char.Parse).ToList();
		list.Sort();

		answer = new char[l];
		Find(0, 0);

		sw.Write(sb.ToString());
		sr.Close();
		sw.Close();
	}

	private void Find(int count, int index)
	{
		if (count == l)
		{
			int vow = 0;
			int con = 0;

			for (int i = 0; i < l; i++)
			{
				if (answer[i] is 'a' or 'e' or 'i' or 'o' or 'u')
					vow++;
				else
					con++;
			}

			if (vow >= 1 && con >= 2)
			{
				for (int i = 0; i < l; i++)
				{
					sb.Append(answer[i]);
				}
				sb.AppendLine();
			}

			return;
		}

		for (int i = index; i < c; i++)
		{
			answer[count] = list[i];
			Find(count + 1, i + 1);
		}
	}
}