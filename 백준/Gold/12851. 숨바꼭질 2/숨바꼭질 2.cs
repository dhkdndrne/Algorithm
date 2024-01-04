using System.Text;
using static System.Console;

class Solutuin
{
	public static void Main(string[] args)
	{
		var sr = new StreamReader(new BufferedStream(OpenStandardInput()));
		var sw = new StreamWriter(new BufferedStream(OpenStandardOutput()));


		var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

		int n = input[0];
		int k = input[1];

		int count = 0;
		int min = int.MaxValue;

		bool[] visit = new bool[100001];

		Queue<(int, int)> q = new Queue<(int, int)>();
		q.Enqueue((n, 0));

		while (q.Count > 0)
		{
			var output = q.Dequeue();
			int pos = output.Item1;
			int step = output.Item2;

			if (min < step) break;
			
			if (pos == k)
			{
				min = step;
				count++;
				continue;
			}

			visit[pos] = true;

			for (int i = 0; i < 3; i++)
			{
				int next = i switch
				{
					0 => pos + 1,
					1 => pos - 1,
					2 => pos * 2
				};

				if (next > 100000 || next < 0) continue;
				if (visit[next]) continue;

				q.Enqueue((next, step + 1));
			}
		}
		sw.WriteLine(min);
		sw.WriteLine(count);

		sr.Close();
		sw.Close();
	}

}