using static System.Console;

class Solutuin
{

	public static void Main(string[] args)
	{
		int size = int.Parse(ReadLine());
		var arr = Array.ConvertAll(ReadLine().Split(), int.Parse);
		int answer = 0;

		List<int> list = new List<int>() { arr[0] };
		int lastIndex = 0;
		
		for (int i = 1; i < size; i++)
		{
			if (arr[i] > list[lastIndex])
			{
				list.Add(arr[i]);
				lastIndex++;
			}
			else
			{
				int low = 0;
				int high = lastIndex;

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