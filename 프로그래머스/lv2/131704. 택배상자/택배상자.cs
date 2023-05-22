using System;
using System.Collections.Generic;

public class Solution {
	public int solution(int[] order)
	{
		int boxIndex = 0;

		Stack<int> subContainer = new Stack<int>();

		for (int i = 0; i < order.Length; i++)
		{
			if ((i + 1) == order[boxIndex])
			{
				boxIndex++;
			}
			else
			{
				subContainer.Push(i + 1);
			}

			while (subContainer.Count > 0 && subContainer.Peek() == order[boxIndex])
			{
				subContainer.Pop();
				boxIndex++;
			}
		}
		return boxIndex;
	}
}