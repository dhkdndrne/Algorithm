using static System.Console;

internal class Algorithm
{
	public static void Main(string[] args)
	{
		int n = int.Parse(ReadLine());
		int[] arr = Array.ConvertAll(ReadLine().Split(), int.Parse);
        
		int left = 0;
		int right = arr.Length - 1;

		int min = Math.Abs(arr[left] + arr[right]);
		(int left, int right) nums = (arr[left], arr[right]);
		
		while (left < right)
		{
			int temp =  arr[left] + arr[right];

			if (Math.Abs(temp) < min)
			{
				min = Math.Abs(temp);
				nums = (arr[left], arr[right]);
			}

			if (temp < 0)
				left++;

			else right--;
		}
		
		Write($"{nums.left} {nums.right}");
	}
}