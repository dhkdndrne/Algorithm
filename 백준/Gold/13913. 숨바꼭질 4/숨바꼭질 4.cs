using System.Text;
using static System.Console;

class Solutuin
{
	public static void Main(string[] args)
	{
		var sr = new StreamReader(new BufferedStream(OpenStandardInput()));
		var sw = new StreamWriter(new BufferedStream(OpenStandardOutput()));

		StringBuilder sb = new StringBuilder();
		var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

		int n = input[0];
		int k = input[1];
        
		int[] visit = new int[100001];
		int[] path = new int[100001];
		Queue<int> q = new Queue<int>();
		q.Enqueue(n);

		while (q.Count > 0)
		{
			int pos = q.Dequeue();
			
			if (pos == k)
			{
				Stack<int> st = new Stack<int>();
				
				st.Push(pos);
				for(int i = pos; i != n; i = path[i])
					st.Push(path[i]);

				while (st.Count > 0)
				{
					sb.Append(st.Pop()).Append(" ");
				}
				
				break;
			}

			for (int i = 0; i < 3; i++)
			{
				int next = i switch
				{
					0 => pos + 1,
					1 => pos - 1,
					2 => pos * 2
				};

				if (next > 100000 || next < 0) continue;
                if (visit[next] != 0) continue;

                path[next] = pos;
                visit[next] = visit[pos] + 1;
				q.Enqueue(next);
			}
		}

		sw.WriteLine(visit[k]);
		sw.WriteLine(sb.ToString());

		sr.Close();
		sw.Close();
	}

}