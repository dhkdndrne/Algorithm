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
	private int[] answer = new int[8];
	private int[] arr;
	private StringBuilder sb = new StringBuilder();
	public void Sol()
	{
		var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
		n = input[0];
		m = input[1];

		arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
		Array.Sort(arr);
		Find(0);
		sw.Write(sb.ToString());

		sr.Close();
		sw.Close();
	}

	private void Find(int cnt)
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
		int prevNum = -1;
		
		for (int i = 0; i < n; i++)
		{
			if(prevNum == arr[i])
				continue;
            
			answer[cnt] = arr[i];
			prevNum = arr[i];
			Find(cnt + 1);
		}
	}
}