using System;
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution 
{
		public int solution(int n, int[,] edge)
		{
			int answer = 0;
			int length = edge.GetLength(0);

			List<int> distance = Enumerable.Repeat(0, n).ToList();
			Queue<int> q = new Queue<int>();

			q.Enqueue(1);
			distance[0] = 1;

			while (q.Count > 0)
			{
				// 현재 방문노드
				int node = q.Dequeue();

				for (int i = 0; i < length; i++)
				{
					//현재 노드와 연결된 노드 나올떄까지
					if (node != edge[i, 0] && node != edge[i, 1])
						continue;

					//현재 노드와 연결된 나머지 노드
					var otherNode = node == edge[i, 0] ? edge[i, 1] : edge[i, 0];

					//node - 1 => 실제 숫자와 인덱스 맞추기위해 -1
					if (distance[node - 1] == 0 || distance[otherNode - 1] != 0)
						continue;

					//거리 더해줌
					distance[otherNode - 1] = distance[node - 1] + 1;
					q.Enqueue(otherNode);
				}
			}

			distance = distance.OrderByDescending(i=>i).ToList();
			int max = distance[0];

			foreach (var dist in distance)
			{
				if (dist == max)
					answer++;
			}
			
			return answer;
		}
}