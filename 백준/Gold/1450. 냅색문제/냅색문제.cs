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
	private int[] items;
	public void solution()
	{
		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);

		int n = input[0]; // 물건 수
		int c = input[1]; // 가방 무게

		items = Array.ConvertAll(ReadLine().Split(), int.Parse);

		List<long> list1 = new List<long>();
		List<long> list2 = new List<long>();

		Combine(0, n / 2, 0, list1);
		Combine(n / 2, n, 0, list2);
	
		list1.Sort();
		
		long answer = 0;
		foreach (long e in list2)
		{
			if(e > c)
				continue;

			int left = 0;
			int right = list1.Count;

			while (left < right)
			{
				int mid = (left + right) / 2;

				if (e + list1[mid] > c)
					right = mid;
				else 
					left = mid + 1;
			}
			answer += right;
		}
		WriteLine(answer);
	}

	private void Combine(int start, int end, long sum, List<long> list)
	{
		if (start >= end)
		{
			list.Add(sum);
			return;
		}
		Combine(start + 1, end, sum + items[start], list); //넣기
		Combine(start + 1, end, sum, list);                //안넣기
	}
}