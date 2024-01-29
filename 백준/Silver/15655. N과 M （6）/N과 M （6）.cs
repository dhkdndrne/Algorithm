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

	private int n, m;
	private int[] answer = new int[9];
	private int[] arr;
	private bool[] visit = new bool[9];
	private StringBuilder sb = new StringBuilder();
	public void Sol()
	{
		var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
		n = input[0];
		m = input[1];

		arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
		Array.Sort(arr);
		Find(0,0);
		Write(sb.ToString());

		sr.Close();
		sw.Close();
	}

	private void Find(int cnt, int index)
	{
		if (cnt == m)
		{
			for (int i = 0; i < m; i++)
			{
				sb.Append(answer[i] + " ");
			}
			sb.AppendLine();
			return;
		}

		for (int i = index; i < n; i++)
		{
			if (visit[i])
				continue;

			visit[i] = true;
			answer[cnt] = arr[i];
			Find(cnt + 1, i + 1);
			visit[i] = false;
		}
	}
}