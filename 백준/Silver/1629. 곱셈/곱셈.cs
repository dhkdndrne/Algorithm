using System;
using System.IO;
using static System.Console;

internal class Algorithm
{
	static StreamReader sr = new StreamReader(new BufferedStream(OpenStandardInput()));
	private static int A,B,C;
	
	public static void Main(string[] args)
	{
		int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
		A = input[0];
		B = input[1];
		C = input[2];
		
		Write(Pow(B));
	}

	private static long Pow(int n)
	{
		if (n == 0)
			return 1;

		long temp = Pow(n / 2);
		temp = temp * temp % C;

		if (n % 2 == 0)
			return temp;

		return A * temp % C;
	}

}