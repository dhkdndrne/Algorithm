using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;

public class Solution {
	public string solution(string number, int k)
	{
		StringBuilder sb = new StringBuilder();
		Stack<char> st = new Stack<char>();
		
		for (int i = 0; i < number.Length; i++)
		{
			char c = number[i];
			while (st.Count > 0 && k > 0 && st.Peek() < c)
			{
				st.Pop();
				k--;
			}
			st.Push(c);
		}
		while (k > 0)
		{
			st.Pop();
			k--;
		}
		
		while (st.Count > 0)
		{
			sb.Append(st.Pop());
		}

		string s = sb.ToString();
		sb.Clear();

		for (int i = s.Length -1; i >= 0; i--)
		{
			sb.Append(s[i]);
		}

		return sb.ToString();
	}
}