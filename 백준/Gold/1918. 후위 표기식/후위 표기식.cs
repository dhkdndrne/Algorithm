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
		string s = sr.ReadLine();
		StringBuilder sb = new StringBuilder();
		Stack<char> stack = new Stack<char>();
	
		for (int i = 0; i < s.Length; i++)
		{
			switch (s[i])
			{
				case '+':
				case '-':
					while (stack.Count > 0 && stack.Peek() != '(')
					{
						sb.Append(stack.Pop());
					}
					stack.Push(s[i]);
					break;
				
				case '*':
				case '/':
					while (stack.Count > 0 && (stack.Peek() == '*' || stack.Peek() == '/'))
					{
						sb.Append(stack.Pop());
					}
					stack.Push(s[i]);
					break;
				
				case '(':
					stack.Push(s[i]);
					break;
				
				case ')':
					while (stack.Count > 0 && stack.Peek() != '(')
					{
						sb.Append(stack.Pop());
					}
					stack.Pop();
					break;
				
				default:
					sb.Append(s[i]);
					break;
			}
		}

		if (stack.Count > 0)
		{
			while (stack.Count > 0)
				sb.Append(stack.Pop());
		}
		
		Write(sb.ToString());
	}
}