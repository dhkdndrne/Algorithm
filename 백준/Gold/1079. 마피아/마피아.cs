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
	private int n, myNum, maxNight;
	private int[,] R;
	private int[] guilt;

	public void solution()
	{
		n = int.Parse(ReadLine());
		guilt = Array.ConvertAll(ReadLine().Split(), int.Parse);
		R = new int[n, n];

		for (int i = 0; i < n; i++)
		{
			var input = Array.ConvertAll(ReadLine().Split(), int.Parse);
			for (int j = 0; j < n; j++)
			{
				R[i, j] = input[j];
			}
		}

		myNum = int.Parse(ReadLine());

		bool[] alive = new bool[n];
		for (int i = 0; i < n; i++)
		{
			alive[i] = true;
		}

		Play(alive, n, 0);
		WriteLine(maxNight);
	}

	private void Play(bool[] alive, int survivors, int night)
	{
		if (survivors == 1)
		{
			maxNight = Math.Max(night, maxNight);
			return;
		}

		if (survivors % 2 == 1) // 낮일 때
		{
			int maxGuilt = int.MinValue;
			int maxIndex = -1;

			// 유죄 지수가 가장 높은 사람 찾기
			for (int i = 0; i < n; i++)
			{
				if (alive[i] && guilt[i] > maxGuilt)
				{
					maxGuilt = guilt[i];
					maxIndex = i;
				}
			}

			if (maxIndex == myNum) // 내가 죽었을 때
			{
				maxNight = Math.Max(night, maxNight);
				return;
			}

			alive[maxIndex] = false; // 해당 사람 제거
			Play(alive, survivors - 1, night);
			alive[maxIndex] = true; // 상태 복구
		}
		else // 밤일 때
		{
			for (int target = 0; target < n; target++)
			{
				if (target != myNum && alive[target])
				{
					alive[target] = false;

					// 유죄 지수 업데이트
					for (int i = 0; i < n; i++)
					{
						if (alive[i])
						{
							guilt[i] += R[target, i];
						}
					}

					Play(alive, survivors - 1, night + 1);

					// 상태 복구
					for (int i = 0; i < n; i++)
					{
						if (alive[i])
						{
							guilt[i] -= R[target, i];
						}
					}
					alive[target] = true;
				}
			}
		}
	}
}