using System.IO;
using static System.Console;

internal class Algorithm
{
	static StreamReader sr = new StreamReader(new BufferedStream(OpenStandardInput()));

	private static long[] arr = new long[10001];
	public static void Main(string[] args)
	{
		int n = int.Parse(sr.ReadLine());
		arr[0] = 1;
		arr[1] = 1;
		
		Write(Find(n));
	}

	private static long Find(int n)
	{
		for (int i = 1; i <= n; i++)
		{
			arr[i + 1] = (arr[i] + arr[i - 1]) % 10007;
		}

		return arr[n];
	}
}