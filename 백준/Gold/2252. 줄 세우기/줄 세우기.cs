using System.Text;
using static System.Console;

internal class Algorithm
{

	static void Main(string[] args)
	{
		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);
		StringBuilder sb = new StringBuilder();

		Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
		
		int n = input[0];
		int m = input[1];

		int[] indegree = new int[n + 1];

		for (int i = 1; i <= n; i++)
		{
			dic.Add(i,new List<int>());
		}
		
		for (int i = 0; i < m; i++)
		{
			var value = Array.ConvertAll(ReadLine().Split(), int.Parse);
            dic[value[0]].Add(value[1]);
			indegree[value[1]]++;
		}

		Queue<int> q = new Queue<int>();

		for (int i = 1; i < indegree.Length; i++)
		{
			if(indegree[i] == 0)
				q.Enqueue(i);
		}

		while (q.Count > 0)
		{
			int curNum = q.Dequeue();
			sb.Append(curNum).Append(" ");

			foreach (var num in dic[curNum])
			{
				indegree[num]--;
				
				if(indegree[num] ==0)
					q.Enqueue(num);
			}
		}
		
		Write(sb.ToString());
	}
}