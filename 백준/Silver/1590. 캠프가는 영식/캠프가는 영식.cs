using static System.Console;
using System.Collections.Generic;

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
		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);
		int n = input[0];
		int t = input[1];

		int answer = -1;
		int temp = int.MaxValue;

		while (n > 0)
		{
			input = Array.ConvertAll(ReadLine().Split(), int.Parse);
			int s = input[0]; // 버스 출발시간
			int i = input[1]; // 버스 간격
			int c = input[2]; // 버스 대수

			int left = 1;
			int right = c;

			if (t == s)
			{
				WriteLine(0);
				return;
			}

			while (left  <= right)
			{
				int mid = (left + right) / 2;

				if (s + i * (mid - 1) >= t)
				{
					var val = (s + i * (mid - 1)) - t;
					
					answer = Math.Min(temp, val);
					temp = answer;
					right = mid -1;
				}
				else left = mid + 1;
			}
			
			n--;
		}

		WriteLine(answer);
	}
}