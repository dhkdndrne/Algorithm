internal class Algorithm
{
	public static void Main(string[] args)
	{
		Queue<long> queue = new Queue<long>();
		int n = int.Parse(Console.ReadLine());
		long answer = 0;

		if (n < 10)
		{
			Console.Write(n);
		}
		else if (n > 1022)
		{
			Console.Write("-1");
		}
		else
		{
			long cnt = 9;
			
			for (int i = 1; i < 10; i++)
				queue.Enqueue(i);

			while (cnt != n)
			{
				long x = queue.Dequeue();
				long temp = x % 10;

				x *= 10;

				for (int i = 0; i < temp; i++)
				{
					cnt++;

					if (cnt == n)
					{
						answer = x + i;
						break;
					}
					
					queue.Enqueue(x +i);
				}
			}
			Console.Write(answer);
		}
	}
}