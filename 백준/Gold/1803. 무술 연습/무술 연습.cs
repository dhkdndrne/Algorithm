using System.Text;
using static System.Console;

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
		int m = input[0];
		int n = input[1];

		int[] answer = new int[m + n];
		int[] target = new int[m + n];
		int[] indegree = new int[m + n];

		Array.Fill(answer, 1);

		input = Array.ConvertAll(ReadLine().Split(), int.Parse);
		for (int i = 0; i < m; i++)
		{
			target[i] = m + input[i] - 1;
			indegree[target[i]]++;
		}

		input = Array.ConvertAll(ReadLine().Split(), int.Parse);
		for (int i = 0; i < n; i++)
		{
			target[i + m] = input[i] - 1;
			indegree[target[i + m]]++;
		}

		Queue<int> q = new Queue<int>();

		for (int i = 0; i < n + m; i++)
		{
			if (indegree[i] == 0)
				q.Enqueue(i);
		}

		while (q.Count > 0)
		{
			var cur = q.Dequeue();
			int tIndex = target[cur];
			
			if(tIndex == -1)
				continue;
			
			if (answer[cur] == 1)
			{
				answer[tIndex] = 0;
				var ttIndex = target[tIndex];

				if (ttIndex == -1)
					continue;
				
				//타겟이 조준하고 있는 상대 조준 취소
				indegree[ttIndex]--;
				if (indegree[ttIndex] == 0)
					q.Enqueue(ttIndex);

				target[tIndex] = -1;
			}
			
			indegree[tIndex]--;
			if(indegree[tIndex] == 0)
				q.Enqueue(tIndex);

		}
		
		for (int i = 0; i < n + m; i++)
		{
			if (indegree[i] != 0)
			{
				indegree[i] = 0;
				if(target[i] == -1)
					continue;
				
				indegree[target[i]] = 0;
				answer[target[i]] = 0;
			}
		}
		
		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < m; i++)
		{
			sb.Append(answer[i]);
		}
		WriteLine(sb.ToString());

		sb.Clear();
		for (int i = m; i < m + n; i++)
		{
			sb.Append(answer[i]);
		}
		WriteLine(sb.ToString());
	}
}