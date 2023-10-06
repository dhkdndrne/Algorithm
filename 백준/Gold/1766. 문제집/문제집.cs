using System.Text;
using static System.Console;

public class Algorithm
{
	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();

		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);

		int n = input[0]; // 문제 수
		int m = input[1]; // 먼저 푸는게 좋은 정보 개수

		List<int>[] questions = new List<int>[n+1];
		int[] arr = new int[n + 1];
		
		for (int i = 1; i <= n; i++)
		{
			questions[i] = new List<int>();
		}
        
		for (int i = 0; i < m; i++)
		{
			var value = Array.ConvertAll(ReadLine().Split(), int.Parse);
			questions[value[0]].Add(value[1]);
			arr[value[1]]++;
		}

		PriorityQueue<int,int> pq = new PriorityQueue<int,int>();

		for (int i = 1; i <= n; i++)
		{
			if(arr[i] ==0)
				pq.Enqueue(i,i);
		}

		while (pq.Count > 0)
		{
			var cur = pq.Dequeue();
			sb.Append(cur).Append(" ");

			foreach (var q in questions[cur])
			{
				arr[q]--;
				
				if(arr[q] == 0)
					pq.Enqueue(q,q);
			}
		}
		sb.Append("\n");
		Write(sb.ToString());
	}
}