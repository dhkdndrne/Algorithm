using System.Collections.Generic;
using System.Linq;
using static System.Console;

internal class Algorithm
{
	public static void Main(string[] args)
	{
		List<string> s = ReadLine().Split().ToList();
		s = s.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
		
		Write(s.Count);
	}
}