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
	private bool[] visit = new bool[9];
	private int[] arr = new int[9];
	private StringBuilder sb = new StringBuilder();
	public void Sol()
	{
		var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

		n = input[0];
		m = input[1];

		Find(0);
		sw.WriteLine(sb.ToString());
		sr.Close();
		sw.Close();
	}

	private void Find(int cnt)
	{
		if (cnt == m)
		{
			for (int i = 0; i < m; i++)
			{
				sb.Append(arr[i]+" ");
			}
			sb.AppendLine();
			return;
		}

		for (int i = 1; i <= n; i++)
		{
			if(visit[i])
				continue;
            
			visit[i] = true;
			arr[cnt] = i;
			Find(cnt + 1);
			visit[i] = false;
		}
	}
}