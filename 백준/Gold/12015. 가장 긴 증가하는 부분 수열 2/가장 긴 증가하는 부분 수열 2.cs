using static System.Console;

class Solutuin
{

	public static void Main(string[] args)
	{
		int size = int.Parse(ReadLine());
		var arr = Array.ConvertAll(ReadLine().Split(), int.Parse);
		
		List<int> list = new List<int>(){arr[0]};

		int lastIndex = 0;
		
		for (int i = 1; i < size; i++)
		{
			//값이 리스트의 마지막 숫자보다 클때
			if (list[lastIndex] < arr[i])
			{
				list.Add(arr[i]);
				lastIndex++;
			}
			else
			{
				int low = 0;
				int high = lastIndex;
				
				//이분 탐색
				while (low < high)
				{
					int mid = (low + high) / 2;

					if (list[mid] < arr[i]) 
						low = mid + 1;
					else high = mid;
				}

				list[low] = arr[i];
			}
		}
		
		Write(list.Count);
	}
}