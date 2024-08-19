using System;
using System.Collections.Generic;

public class Solution {
		public int solution(int n, int[,] wires)
		{
			int answer = int.MaxValue;

			for (int i = 0; i < wires.GetLength(0); i++)
			{
				int a = wires[i, 0];
				int b = wires[i, 1];

				HashSet<int> hashSetA = new HashSet<int>() { a };
				HashSet<int> hashSetB = new HashSet<int>() { b };

				DFS(wires, hashSetA, i);
				DFS(wires, hashSetB, i);

				int count = Math.Abs(hashSetB.Count - hashSetA.Count);

				if (answer >count)
					answer = count;
			}
			return answer;
		}

		void DFS(int[,] wires, HashSet<int> hashSet, int deleteIndex)
		{
			for (int i = 0; i < wires.GetLength(0); i++)
			{
				if(deleteIndex == i)
					continue;

				if (hashSet.Contains(wires[i, 0]) && !hashSet.Contains(wires[i, 1]))
				{
					hashSet.Add(wires[i, 1]);
					DFS(wires,hashSet,deleteIndex);
				}
				if (hashSet.Contains(wires[i, 1]) && !hashSet.Contains(wires[i, 0]))
				{
					hashSet.Add(wires[i, 0]);
					DFS(wires,hashSet,deleteIndex);
				}
			}
		}
}