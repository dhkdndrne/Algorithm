using static System.Console;

public class Algorithm
{
	public static void Main(string[] args)
	{
		var input = Array.ConvertAll(ReadLine().Split(), int.Parse);

		int n = input[0]; //보석 개수
		int k = input[1]; //가방 개수

		//가방 최대 무게 C (가방에는 한개만 넣을 수 있음)

		List<(int weight, int price)> jewels = new List<(int, int)>();
		List<int> bags = new List<int>();


		long answer = 0;

		for (int i = 0; i < n; i++)
		{
			var jValue = Array.ConvertAll(ReadLine().Split(), int.Parse);
			jewels.Add((jValue[0], jValue[1])); //무게, 가격
		}

		for (int i = 0; i < k; i++)
		{
			bags.Add(int.Parse(ReadLine()));
		}

		jewels.Sort();
		bags.Sort();

		PriorityQueue<int, int> valueQ = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
		int index = 0;

		for (int i = 0; i < k; i++)
		{
			while (index < n && bags[i] >= jewels[index].weight)
			{
				valueQ.Enqueue(jewels[index].price,jewels[index].price);
				index++;
			}
            
			if (valueQ.Count > 0)
			{
				answer += valueQ.Peek();
				valueQ.Dequeue();
			}
		}

		Write(answer);
	}
}