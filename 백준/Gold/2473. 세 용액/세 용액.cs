using static System.Console;

internal class Algorithm
{
	public static void Main(string[] args)
	{
		int n = int.Parse(ReadLine());
		long[] arr = Array.ConvertAll(ReadLine().Split(), long.Parse);

		Array.Sort(arr);

		long min = long.MaxValue;
		(long num1, long num2, long num3) nums = (0, 0, 0);

		for (int left = 0; left < n - 2; left++)
		{
			int middle = left + 1;
			int right = n-1;

			while (middle < right)
			{
				long temp = arr[left] + arr[middle] + arr[right];

				if (Math.Abs(temp) < min)
				{
					min = Math.Abs(temp);
					nums = (arr[left], arr[middle], arr[right]);
				}

				if (temp < 0)
					middle++;

				else
					right--;

			}
		}
		Write($"{nums.num1} {nums.num2} {nums.num3}");
	}
}