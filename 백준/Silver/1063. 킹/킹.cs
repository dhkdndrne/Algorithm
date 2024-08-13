using static System.Console;
using System.Collections.Generic;
using System.Text;

class Algorithm
{
	public static void Main(string[] args)
	{
		Solution solution = new Solution();
		solution.solution();
	}
}

public class Solution
{
	public void solution()
	{
		var input = ReadLine().Split();
		(int x, int y) king = (ConvertAlphabet(input[0][0]), int.Parse(input[0][1].ToString()) - 1);
		(int x, int y) stone = (ConvertAlphabet(input[1][0]), int.Parse(input[1][1].ToString()) - 1);
		int n = int.Parse(input[2]);

		for (int i = 0; i < n; i++)
		{
			string s = ReadLine();

			(int x, int y) dir = (0, 0);
			for (int j = 0; j < s.Length; j++)
			{
				var t = GetDir(s[j]);
				dir.x += t.x;
				dir.y += t.y;
			}

			(int x, int y) nKing = (king.x + dir.x, king.y + dir.y);
			if (IsOutOfRange(nKing))
				continue;

			if (nKing == stone)
			{
				(int x, int y) nStone = (stone.x + dir.x, stone.y + dir.y);

				if (IsOutOfRange(nStone))
					continue;
				stone = nStone;
			}

			king = nKing;
		}
		WriteLine(ConvertPosToString(king));
		WriteLine(ConvertPosToString(stone));
	}

	private string ConvertPosToString((int x, int y) pos)
	{
		string s = string.Empty;
		s += (char)(pos.x + 'A');
		s += pos.y + 1;
		return s;
	}
	private bool IsOutOfRange((int x, int y) pos)
	{
		return pos.x < 0 || pos.x > 7 || pos.y < 0 || pos.y > 7;
	}
	private int ConvertAlphabet(char c)
	{
		return c - 'A';
	}
	(int x, int y) GetDir(char s)
	{
		return s switch
		{
			'R' => (1, 0),
			'L' => (-1, 0),
			'B' => (0, -1),
			'T' => (0, 1)
		};
	}

}