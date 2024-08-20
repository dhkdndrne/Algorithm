using static System.Console;
using System.Collections;
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
	private int[] parent;
	public void solution()
	{
		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);

		int n = input[0];	//점의 개수
		int m = input[1];	// 진행된 차례 수
		parent = new int[n];

		for (int i = 0; i < n; i++)
			parent[i] = i;

		int answer = 0;
		
		for (int i = 0; i < m; i++)
		{
			input = Array.ConvertAll(ReadLine().Split(), int.Parse);

			if (Find(input[0]) != Find(input[1]))
			{
				Union(input[0],input[1]);
			}
			else
			{
				answer = i + 1;
				break;
			}
		}
		
		WriteLine(answer);
	}

	private void Union(int a, int b)
	{
		a = Find(a);
		b = Find(b);

		parent[b] = a;
	}
	private int Find(int a)
	{
		if (parent[a] == a) return a;
		return parent[a] = Find(parent[a]);
	}
}