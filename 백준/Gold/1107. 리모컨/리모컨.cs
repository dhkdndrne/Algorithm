using static System.Console;
using System.Collections.Generic;

class Solutuin
{
	private static bool[] unUseableNumbers;
	
	public static void Main(string[] args)
	{
		var sr = new StreamReader(new BufferedStream(OpenStandardInput()));
		var sw = new StreamWriter(new BufferedStream(OpenStandardOutput()));

		int n = int.Parse(sr.ReadLine());
		int m = int.Parse(sr.ReadLine());
        unUseableNumbers = Enumerable.Repeat(true,10).ToArray();
        
		if (m != 0)
		{
			int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        
			for (int i = 0; i < input.Length; i++)
			{
				unUseableNumbers[input[i]] = false;
			}
		}
        
		int channel = 100;
		int answer= Math.Abs(n - channel);
		
       
		for (int i = 0; i < 1000000; i++)
		{
			if (Check(i))
			{
				int cnt = Math.Abs(n - i) + i.ToString().Length;
				answer = Math.Min(answer, cnt);
			}
		}
		
		Write(answer);
		
		sr.Close();
		sw.Close();
	}

	private static bool Check(int n)
	{
		string str = n.ToString();
		for (int i = 0; i < str.Length; i++)
		{
			if (!unUseableNumbers[str[i] - '0'])
				return false;
		}
		
		return true;
	}
}