using System;
using System.Collections.Generic;

public class Solution {
		private HashSet<int> hashSet = new HashSet<int>();
	private bool[] visit;
	
	public int solution(string numbers) 
	{
		int answer = 0;

		visit = new bool[numbers.Length];

		Find("", numbers);
		
		foreach (var val in hashSet)
		{
			if (IsPrime(val))
				answer++;
		}
		
		return answer;
	}

	private void Find(string s,string numbers)
	{
		if (s.Length == visit.Length)
			return;

		for (int i = 0; i < numbers.Length; i++)
		{
			if(visit[i])
				continue;

			visit[i] = true;
			Find(s + numbers[i],numbers);
			visit[i] = false;

			hashSet.Add(int.Parse(s + numbers[i]));
		}
	}
	
	private bool IsPrime(int num)
	{
		if (num <= 1)
			return false;

		var sqrt = Math.Sqrt(num);
        
		for (int i = 2; i <= sqrt; i++)
			if (num % i == 0)
				return false;

		return true;
	}
}