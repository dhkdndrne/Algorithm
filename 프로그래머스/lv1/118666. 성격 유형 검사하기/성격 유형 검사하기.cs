using System;
using System.Text;
using System.Collections.Generic;

public class Solution {
    public string solution(string[] survey, int[] choices) 
    {
		string[] type = { "RT", "CF", "JM", "AN" };
		StringBuilder sb = new StringBuilder();
		
		Dictionary<char, int> dic = new Dictionary<char, int>()
		{
			{ 'R', 0 }, { 'T', 0 }, { 'C', 0 }, { 'F', 0 }, { 'J', 0 }, { 'M', 0 }, { 'A', 0 }, { 'N', 0 }
		};

		for (int i = 0; i < choices.Length; i++)
		{
			int num = choices[i];

			if (num >= 1 && num < 4)
			{
				dic[survey[i][0]] += 4 - choices[i];
			}
			else if (num > 4 && num <= 7)
			{
				dic[survey[i][1]] += choices[i] - 4;
			}
		}

		for (int i = 0; i < 4; i++)
		{
			if (dic[type[i][0]] != dic[type[i][1]])
			{
				sb.Append(dic[type[i][0]] > dic[type[i][1]] ? type[i][0] : type[i][1]);
			}
			else
				sb.Append(type[i][0] < type[i][1] ? type[i][0] : type[i][1]);
		}
		
		return sb.ToString();
    }
}