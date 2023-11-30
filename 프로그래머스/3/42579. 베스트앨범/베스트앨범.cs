using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
	{
		public class Test
		{
			public int index;
			public int play;
		}
		public int[] solution(string[] genres, int[] plays)
		{
			List<int> answer = new List<int>();
			
			// 장르 고유번호 재생 횟수
			Dictionary<string, List<Test>> dic = new Dictionary<string, List<Test>>();
			Dictionary<string, int> genresTotalPlayDic = new Dictionary<string, int>();

			for (int i = 0; i <genres.Length; i++)
			{
				if (!dic.ContainsKey(genres[i]))
					dic.Add(genres[i], new List<Test>());

				dic[genres[i]].Add(new Test(){index = i,play = plays[i]});
				

				if (!genresTotalPlayDic.ContainsKey(genres[i]))
					genresTotalPlayDic.Add(genres[i], 0);

				genresTotalPlayDic[genres[i]] += plays[i];
			}

			var playCntList = genresTotalPlayDic.ToList();
			playCntList.Sort((a,b)=> b.Value.CompareTo(a.Value));
			
			string[] temp = dic.Keys.ToArray();
			for (int i = 0; i < temp.Length; i++)
			{
				dic[temp[i]].Sort((a,b)=> b.play.CompareTo(a.play));
			}

			for (int i = 0; i < playCntList.Count; i++)
			{
				string genre = playCntList[i].Key;

				for (int j = 0; j < dic[genre].Count; j++)
				{
					if (j == 2)
						break;
					
					answer.Add(dic[genre][j].index);
				}
			}
			
			return answer.ToArray();
		}
	}