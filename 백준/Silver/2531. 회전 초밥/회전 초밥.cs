using static System.Console;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class Program
{
	public static void Main(string[] args)
	{
		Solution solution = new Solution();
		solution.Solve();
	}
}

public class Solution
{
	public void Solve()
	{
		var input = Array.ConvertAll(ReadLine().Split(' '), int.Parse);

		int n = input[0]; // 접시수
		int d = input[1]; // 초밥 가짓수
		int k = input[2]; // 연속해서 먹는 접시 수
		int c = input[3]; // 쿠폰 번호

		int[] arr = new int[n];

		for (int i = 0; i < n; i++)
			arr[i] = int.Parse(ReadLine());

		int[] count = new int[d + 1]; // 각 초밥 번호별 개수
		int unique = 0;

		//초기값 설정 0~k까지 체크
		for (int i = 0; i < k; i++)
		{
			if (count[arr[i]] == 0) unique++;
			count[arr[i]]++;
		}

		int max = unique + (count[c] == 0 ? 1 : 0); //쿠폰 초밥 포함 체크

		for (int i = 1; i < n; i++)
		{
			//맨 왼쪽 제거
			int remove = arr[i - 1];
			count[remove]--;
			if (count[remove] == 0) unique--;

			//오른쪽 끝에 추가
			int add = arr[(i + k - 1) % n]; // 원형벨트라서 %n
			if (count[add] == 0) unique++;
			count[add]++;

			int total = unique + (count[c] == 0 ? 1 : 0);
			max = Math.Max(max, total);
		}
		WriteLine(max);
	}
}