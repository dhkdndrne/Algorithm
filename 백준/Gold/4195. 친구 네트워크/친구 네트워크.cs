using System.Text;
using static System.Console;

class Solutuin
{
	private static Dictionary<string, string> personDic = new Dictionary<string, string>(); //이름, 그룹장 이름
	private static Dictionary<string, int> groupDic = new Dictionary<string, int>();        //그룹장 이름 , 그룹원 수

	public static void Main(string[] args)
	{
		StringBuilder sb = new StringBuilder();
		int t = int.Parse(ReadLine());

		while (t > 0)
		{
			int f = int.Parse(ReadLine());
			personDic.Clear();
			groupDic.Clear();

			for (int i = 0; i < f; i++)
			{
				var input = ReadLine().Split();
				Write(Union(input[0],input[1]) +"\n");
			}
            
			t--;
		}
	}
	private static int Union(string s1, string s2)
	{
		s1 = Find(s1);
		s2 = Find(s2);
		
		if(s1.Equals(s2))
			return groupDic[s1];
        
		groupDic[s1] += groupDic[s2];
		personDic[s2] = s1;
		return groupDic[s1];
	}

	private static string Find(string s)
	{
		if (!personDic.ContainsKey(s))
		{
			personDic.Add(s, s);
			groupDic.Add(s, 1);

			return s;
		}

		if (s == personDic[s]) return s;
		return personDic[s] = Find(personDic[s]);
	}
}