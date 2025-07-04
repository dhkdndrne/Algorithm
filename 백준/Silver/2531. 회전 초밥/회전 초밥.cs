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
		var input = Array.ConvertAll(ReadLine().Split(' '), int.Parse);
		
		int answer = 0;
		int n = input[0]; // 접시수
		int d = input[1]; // 초밥 가짓수
		int k = input[2]; // 연속해서 먹는 접시 수
		int c = input[3]; // 쿠폰 번호

		int[] arr = new int[n];
		
		for (int i = 0; i < n; i++)
			arr[i] = int.Parse(ReadLine());

		HashSet<int> diff = new HashSet<int>();
		// 초밥을 다르게먹는 최대 가짓수
		for (int i = 0; i < n; i++)
		{
			diff.Clear();
			for (int j = i, cnt = 0; cnt < k; j++)
			{
				if (j >= n)
					j = 0;

				diff.Add(arr[j]);
				cnt++;
			}

			diff.Add(c);
			answer = Math.Max(answer, diff.Count);
		}
		
		WriteLine(answer);
	}
}