using static System.Console;

class Solutuin
{

	public static void Main(string[] args)
	{
		int size = int.Parse(ReadLine());
		var arr = Array.ConvertAll(ReadLine().Split(), int.Parse);
		int[] dp = new int[size];
		int max = 0;
		
		for (int i = 0; i < size; i++)
		{
			dp[i] = arr[i];
			for (int j = 0; j < i; j++) 
			{
				if (arr[i] > arr[j] && dp[i] < dp[j] + arr[i])
					dp[i] = dp[j] + arr[i];
			}
			max = Math.Max(max,dp[i]);
		}
        
		Write(max);
	}
}