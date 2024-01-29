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

	private List<int> list;
	private int k, skipIndex;
	private int[] answer;
	private StringBuilder sb = new StringBuilder();

	public void Sol()
	{
		while (true)
		{
			list = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();

			if (list.Count == 1)
				break;
			
			sb.Clear();
			k = list[0];
		
			answer = new int[k];
	        
			list.RemoveAt(0);
			list.Sort();

			Find(0, 0);

			sb.AppendLine();
			sw.Write(sb.ToString());
		}
        
		sr.Close();
		sw.Close();
	}

	private void Find(int count, int index)
	{
		if (count == 6)
		{
			for (int i = 0; i < 6; i++)
			{
				sb.Append(answer[i] + " ");
			}
			sb.AppendLine();
			return;
		}

		for (int i = index; i < k; i++)
		{
			answer[count] = list[i];
			Find(count + 1,i + 1);
		}
	}
}