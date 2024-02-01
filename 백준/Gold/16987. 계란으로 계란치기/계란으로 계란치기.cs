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
	private class Egg
	{
		public int w;
		public int s;
	}

	static StreamReader sr = new StreamReader(new BufferedStream(OpenStandardInput()));
	static StreamWriter sw = new StreamWriter(new BufferedStream(OpenStandardOutput()));

	private int n, answer;
	private Egg[] eggs;

	public void Sol()
	{
		n = int.Parse(sr.ReadLine());
		eggs = new Egg[n];

		// 내구도 무게 순
		for (int i = 0; i < n; i++)
		{
			var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
			eggs[i] = new Egg { s = input[0], w = input[1] };
		}

		Find(0,0);
		sw.Write(answer);

		sr.Close();
		sw.Close();
	}

	private void Find(int index,int cnt)
	{
		if (index == n)
		{
			answer = Math.Max(answer, cnt);
			return;
		}
        
		var egg1 = eggs[index];

		if (egg1.s <= 0 || cnt == n - 1)
		{
			Find(index + 1, cnt);
			return;
		}
		
		int temp = cnt;
		
		for (int i = 0; i < n; i++)
		{
			if (index == i || eggs[i].s <= 0)
			{
				continue;
			}

			var egg2 = eggs[i];

			egg1.s -= egg2.w;
			egg2.s -= egg1.w;

			if (egg1.s <= 0)
				cnt++;

			if (egg2.s <= 0)
				cnt++;
			
			Find(index + 1,cnt);

			egg1.s += egg2.w;
			egg2.s += egg1.w;
			cnt = temp;
		}
	}
}