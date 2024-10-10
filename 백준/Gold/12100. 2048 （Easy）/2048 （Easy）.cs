using System.Text;
using System;
using static System.Console;
using System.Collections.Generic;
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
	private int n;
	private int answer = int.MinValue;
	private int[,] board;
	public void solution()
	{
		n = int.Parse(ReadLine());
		board = new int[n, n];

		for (int i = 0; i < n; i++)
		{
			var input = Array.ConvertAll(ReadLine().Split(), int.Parse);
			for (int j = 0; j < n; j++)
			{
				board[i, j] = input[j];
			}
		}

		for (int i = 0; i < 4; i++)
			Find(0, 0, i);

		WriteLine(answer);
	}

	private void Find(int cnt, int max, int dir)
	{
		if (cnt == 5)
		{
			answer = Math.Max(max, answer);
			return;
		}

		int[,] backup = (int[,])board.Clone(); // 현재 보드를 백업하여 상태를 저장
		max = Math.Max(max, Move(dir));

		// 재귀 호출로 다른 방향으로 이동하는 경우들을 탐색
		for (int i = 0; i < 4; i++)
		{
			Find(cnt + 1, max, i);
		}
		Array.Copy(backup, board, board.Length); // 재귀 이후 원래 상태로 보드를 복원
	}

	private int Move(int direction)
	{
		int max = 0;
		for (int i = 0; i < n; i++)
		{
			List<int> line = new List<int>();
			for (int j = 0; j < n; j++)
			{
				int val = GetValueByDirection(i, j, direction);
				if (val != 0) line.Add(val); // 0이 아닌 값만 리스트에 추가
			}

			// 병합
			for (int j = 0; j < line.Count - 1; j++)
			{
				if (line[j] == line[j + 1])
				{
					line[j] *= 2;
					line.RemoveAt(j + 1); // 병합 후, 다음 값을 제거
				}
			}

			// 결과를 다시 보드에 반영
			for (int j = 0; j < n; j++)
			{
				int newVal = (j < line.Count) ? line[j] : 0;
				SetValueByDirection(i, j, direction, newVal);
				max = Math.Max(max, newVal);
			}
		}
		return max;
	}

	private int GetValueByDirection(int i, int j, int direction)
	{
		switch (direction)
		{
			case 0: return board[i, j];         // 왼쪽
			case 1: return board[i, n - 1 - j]; // 오른쪽
			case 2: return board[j, i];         // 위
			case 3: return board[n - 1 - j, i]; // 아래
			default: throw new ArgumentException("Invalid direction");
		}
	}

	private void SetValueByDirection(int i, int j, int direction, int value)
	{
		switch (direction)
		{
			case 0:
				board[i, j] = value;
				break; // 왼
			case 1:
				board[i, n - 1 - j] = value;
				break; // 오
			case 2:
				board[j, i] = value;
				break; // 위
			case 3:
				board[n - 1 - j, i] = value;
				break; // 아래
			default: throw new ArgumentException("Invalid direction");
		}
	}


}