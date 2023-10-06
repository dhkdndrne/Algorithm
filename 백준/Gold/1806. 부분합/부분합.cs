using static System.Console;

public class Algorithm
{
	public static void Main(string[] args)
	{
		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);

		int n = input[0];
		int s = input[1];

		int[] arr = Array.ConvertAll(ReadLine().Split(), int.Parse);

		int start = 0;
		int end = 0;

		int sum = 0;
		int min = int.MaxValue;
        
		while (end < n)
		{
			sum += arr[end];
			end++;

			while (sum >= s)
			{
				min = Math.Min(min, end - start);
				sum -= arr[start];
				start++;
			}
		}

		Write(min == int.MaxValue ? 0 : min);
	}
}