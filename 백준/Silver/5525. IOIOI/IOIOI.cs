using static System.Console;

internal class Algorithm
{
	public static void Main(string[] args)
	{
		int n = int.Parse(ReadLine());
		int length = int.Parse(ReadLine());
		string s = ReadLine();
		int answer = 0;

		int o = 0;
		for (int i = 1; i < length - 1; i++)
		{
			if (s[i - 1] == 'I' && s[i] == 'O' && s[i + 1] == 'I')
			{
				o++;
				i++;
				
				if (o == n)
				{
					o--;
					answer++;
				}
			}
			else o = 0;
		}
		Write(answer);
	}
}