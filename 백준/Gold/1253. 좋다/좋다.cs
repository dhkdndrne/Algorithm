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
		int n = int.Parse(ReadLine());
		var arr = Array.ConvertAll(ReadLine().Split(), int.Parse);

		int answer = 0;
		Array.Sort(arr);
		for (int i = 0; i < n; i++)
		{
			int left = 0;
			int right = n - 1;

			while (left < right)
			{
				int sum = arr[left] + arr[right];

				if (arr[i] > sum)
				{
					left++;
				}
				else if (arr[i] < sum)
				{
					right--;
				}
				else
				{
					if (left != i && right != i)
					{
						answer++;
						break;
					}
					else if (left == i) left++;
					else if (right == i) right--;
				}
			}
		}

		WriteLine(answer);
	}
}