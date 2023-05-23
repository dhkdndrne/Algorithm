using System;

internal class Algorithm
{
	public static void Main(string[] args)
	{
		var numbers = Console.ReadLine().Split();

		Console.Write(int.Parse(numbers[0]) * int.Parse(numbers[1]));
	}
}