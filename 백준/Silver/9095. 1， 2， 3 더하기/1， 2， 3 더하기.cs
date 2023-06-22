using static System.Console;

internal class Algorithm
{
	public static void Main(string[] args)
	{
		int t = int.Parse(ReadLine());

		for (int i = 0; i < t; i++)
		{
			int num = int.Parse(ReadLine());
			int answer = DFS(0, num, 0);

			Write(answer + "\n");
		}
	}
	private static int DFS(int num, int target, int answer)
	{
		if (num == target)
			answer++;

		if (num + 1 <= target) answer = DFS(num + 1, target, answer);
		if (num + 2 <= target) answer = DFS(num + 2, target, answer);
		if (num + 3 <= target) answer = DFS(num + 3, target, answer);

		return answer;
	}
}