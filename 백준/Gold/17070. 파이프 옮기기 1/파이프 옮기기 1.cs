using static System.Console;

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
	private int n, answer;
	private bool[,] isVisit;
	private int[,] map;

	private enum Direction
	{
		Horizontal,
		Vertical,
		Diagonal
	}
	public void solution()
	{
		n = int.Parse(ReadLine());
		map = new int[n, n];
		isVisit = new bool[n, n];

		isVisit[0, 0] = true;
		isVisit[0, 1] = true;

		for (int y = 0; y < n; y++)
		{
			var val = Array.ConvertAll(ReadLine().Split(), int.Parse);
			for (int x = 0; x < n; x++)
			{
				map[y, x] = val[x];
				if (val[x] == 1)
					isVisit[y, x] = true;
			}
		}
		Find(1, 0, Direction.Horizontal);
		WriteLine(answer);
	}

	private void Find(int x, int y, Direction dir)
	{
		if (x == (n - 1) && y == (n - 1))
		{
			answer++;
			return;
		}
		//가로
		if (dir == Direction.Horizontal)
		{
			FindHorizontal(x, y);
			FindDiagonal(x, y);

		}
		else if (dir == Direction.Vertical)
		{
			FindVertical(x, y);
			FindDiagonal(x, y);
		}
		else
		{
			FindHorizontal(x, y);
			FindVertical(x, y);
			FindDiagonal(x, y);
		}
	}

	private void FindHorizontal(int x, int y)
	{
		if (CanVisit(x + 1, y))
		{
			isVisit[y, x + 1] = true;
			Find(x + 1, y, Direction.Horizontal);
			isVisit[y, x + 1] = false;
		}
	}

	private void FindVertical(int x, int y)
	{
		if (CanVisit(x, y + 1))
		{
			isVisit[y + 1, x] = true;
			Find(x, y + 1, Direction.Vertical);
			isVisit[y + 1, x] = false;
		}
	}

	private void FindDiagonal(int x, int y)
	{
		if (CanVisit(x + 1, y) && CanVisit(x, y + 1) && CanVisit(x + 1, y + 1))
		{
			isVisit[y + 1, x + 1] = true;
			Find(x + 1, y + 1, Direction.Diagonal);
			isVisit[y + 1, x + 1] = false;
		}
	}

	private bool CanVisit(int x, int y)
	{
		if (x > n - 1) return false;
		if (y > n - 1) return false;

		return isVisit[y, x] == false;
	}
}