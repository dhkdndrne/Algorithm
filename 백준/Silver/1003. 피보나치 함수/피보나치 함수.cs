using static System.Console;
public class Class1
{
	private static int[] Arr = new int[41];
	public static void Main(string[] args)
	{
		Arr[0] = 0;
		Arr[1] = 1;

		for (int i = 2; i < 41; i++)
		{
			Arr[i] = Arr[i - 1] + Arr[i - 2];
		}
		
		int count = int.Parse(ReadLine());

		for (int i = 0; i < count; i++)
		{
			int n = int.Parse(ReadLine());
			
			if(n ==0)
				Write("1 0\n");
			else
				Write($"{Arr[n-1]} {Arr[n]}\n");
		}
	}
}