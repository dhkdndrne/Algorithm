using System;
using System.Collections.Generic;
using static System.Console;

internal class Algorithm
{
	public static void Main(string[] args)
	{
		int[] temp = Array.ConvertAll(ReadLine().Split(), Int32.Parse);
		int[,] nodes = new int[temp[0], temp[1]];

		for (int i = 0; i < temp[0]; i++)
		{
			string n = ReadLine();
			for (int j = 0; j < n.Length; j++)
			{
				nodes[i, j] = int.Parse(n[j].ToString());
			}
		}

		Console.Write(BFS(nodes));
	}

	public static int BFS(int[,] maps)
	{
		int answer = 0;

		Queue<(int, int)> queue = new Queue<(int, int)>();
		queue.Enqueue((0, 0));

		while (queue.Count > 0)
		{
			var pos = queue.Dequeue();
			int x = pos.Item1;
			int y = pos.Item2;

			if (CheckRange(x + 1, y, maps))
			{
				queue.Enqueue((x + 1, y));
				maps[y, x + 1] = maps[y, x] + 1;
			}
			if (CheckRange(x - 1, y, maps))
			{
				queue.Enqueue((x - 1, y));
				maps[y, x - 1] = maps[y, x] + 1;
			}
			if (CheckRange(x, y + 1, maps))
			{
				queue.Enqueue((x, y + 1));
				maps[y + 1, x] = maps[y, x] + 1;
			}

			if (CheckRange(x, y - 1, maps))
			{
				queue.Enqueue((x, y - 1));
				maps[y - 1, x] = maps[y, x] + 1;
			}
		}

		int targetX = maps.GetLength(1);
		int targetY = maps.GetLength(0);
		return maps[targetY - 1, targetX - 1];
	}

	private static bool CheckRange(int x, int y, int[,] map)
	{

		if (x < 0) return false;
		if (x >= map.GetLength(1)) return false;
		if (y < 0) return false;
		if (y >= map.GetLength(0)) return false;
		if (map[y, x] != 1) return false;

		return true;
	}

}