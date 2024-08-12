using static System.Console;
using System.Collections.Generic;
using System.Text;

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
		var crains = Array.ConvertAll(ReadLine().Split(), int.Parse);

		int m = int.Parse(ReadLine());
		var boxes = Array.ConvertAll(ReadLine().Split(), int.Parse).ToList();

		Array.Sort(crains);
		boxes.Sort();

		int cnt = 0;

		while (boxes.Count > 0)
		{
			bool check = false;
			for (int i = 0; i < crains.Length; i++)
			{
				for (int j = boxes.Count - 1; j >= 0; j--)
				{
					if (boxes[j] <= crains[i])
					{
						boxes.RemoveAt(j);
						check = true;
						break;
					}
				}
			}

			if (!check)
			{
				WriteLine(-1);
				return;
			}
			
			cnt++;
		}
		WriteLine(cnt);	
	}

}