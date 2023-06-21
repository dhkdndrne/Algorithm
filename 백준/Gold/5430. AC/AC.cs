using System;
using System.Text;
using System.Text.RegularExpressions;
using static System.Console;

internal class Algorithm
{
	public static void Main(string[] args)
	{
		var t = int.Parse(ReadLine());
		StringBuilder sb = new StringBuilder();


		while (t > 0)
		{
			string method = ReadLine();
			int arrLength = int.Parse(ReadLine());

			bool isReverse = false;
			bool isError = false;

			int head = 0;
			int tail = arrLength;

			sb.Clear();

			string arrNumbers = ReadLine();
			arrNumbers = Regex.Replace(arrNumbers, @"\[|\]", "");

			int[] arr = arrLength == 0 ? new int[0] : Array.ConvertAll(arrNumbers.Split(','), int.Parse);

			for (int i = 0; i < method.Length; i++)
			{
				if (method[i] == 'D')
				{
					if (arrLength == 0 || head == tail)
					{
						isError = true;
						break;
					}

					if (isReverse) head--;
					else head++;
				}
				else if (method[i] == 'R')
				{
					isReverse = !isReverse;

					int temp = head;
					head = tail;
					tail = temp;
				}
			}

			if (isError)
			{
				Write("error\n");
			}
			else
			{
				sb.Append("[");

				if (!isReverse)
				{
					for (int i = head; i < tail; i++)
					{
						sb.Append(arr[i]);

						if (i < tail - 1)
							sb.Append(",");
					}
				}
				else
				{
					for (int i = head -1; i >= tail; i--)
					{
						sb.Append(arr[i]);

						if (i > tail)
							sb.Append(",");
					}
				}
				sb.Append("]").Append('\n');

				Write(sb.ToString());
			}
			t--;
		}
	}

}