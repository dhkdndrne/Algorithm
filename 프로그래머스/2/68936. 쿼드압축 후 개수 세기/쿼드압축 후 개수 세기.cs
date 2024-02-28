using System;
using System.Collections.Generic;

public class Solution 
{
 		private int[] answer;
	public int[] solution(int[,] arr)
	{
		answer = new int[2];
	
		int size = arr.GetLength(1);
		Find(0, 0, size, arr);
		return answer;
	}
	
	private void Find(int x, int y, int size, int[,] arr)
	{
		int num = arr[y, x];
		
		int half = size / 2;
		bool isSame = true;

		for (int i = y; i < y + size; i++)
		{
			for (int j = x; j < x + size; j++)
			{
				if (arr[i, j] != num)
				{
					isSame = false;
					break;
				}
			}

			if (!isSame) break;
		}
		
		if (isSame)
		{
			answer[num]++;
			return;
		}
		
		Find(x, y, half, arr);               // 2사분면
		Find(x + half, y, half, arr);        // 1사분면
		Find(x, y + half, half, arr);        // 3사분면
		Find(x + half, y + half, half, arr); // 4사분면
	}
}