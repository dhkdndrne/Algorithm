using static System.Console;

internal class Algorithm
{
	private static int[] arr = new int[10];
	private static int[] num = new int[10];
	private static int m, n;

	public static void Main(string[] args)
	{
		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);

		n = input[0];
		m = input[1];

		num = Array.ConvertAll(ReadLine().Split(), int.Parse);
		Array.Sort(num);

		DFS(0,0);
	}

	private static void DFS(int x, int length)
	{
		if (length == m)
		{
			for (int i = 0; i < m; i++)
				Write($"{arr[i]} ");

			Write("\n");
			return;
		}

		int last = 0;

		for (int i = x; i < n; i++)
		{
			if (num[i] != last)
			{
				arr[length] = num[i];
				last = arr[length];
				DFS(i, length + 1);
			}
		}
	}
}