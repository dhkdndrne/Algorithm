using System;
using System.IO;
using static System.Console;
using System.Collections.Generic;
using System.Text;

internal class Algorithm
{
	static StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));

	public static void Main(string[] args)
	{
		int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

		Write(Find(input[0], input[1]));
	}

	private static int Find(long startNum, long target)
	{
		int cnt = 0;
		
		Queue<(long num,int count)> q = new Queue<(long,int)>();
		q.Enqueue((startNum,cnt));

		while (q.Count > 0)
		{
			var temp = q.Dequeue();
			long num = temp.num;
			
			if (num == target)
			{
				return temp.count + 1;
			}

			if (num * 2 <= target)
			{
				q.Enqueue((num * 2,temp.count +1));
			}

			if ((num * 10) + 1 <= target)
			{
				q.Enqueue(((num * 10) + 1,temp.count +1));
			}
		}
		return -1;
	}
}