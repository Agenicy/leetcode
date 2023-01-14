using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q1061
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.SmallestEquivalentString("dccaccbdafgeabeeghbigbhicggfbhiccfgbechdicbhdcgahi", "igfcigeciahdafgegfbeddhgbacaeehcdiehiifgbhhehhccde", "sanfbzzwblekirguignnfkpzgqjmjmfokrdfuqbgyflpsfpzbo"));
			Log.Print(solution.SmallestEquivalentString("leetcode", "programs", "sourcecode"));
			Log.Print(solution.SmallestEquivalentString("parker", "morris", "parser"));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public string SmallestEquivalentString(string s1, string s2, string baseStr)
		{
			int[] eq = Enumerable.Range(0, 26).ToArray();

			void ChangeRef(int origin, int to)
			{
				while (eq[to] != to)
					to = eq[to];

				if (to >= origin)
					return;

				if (eq[origin] == origin)
					eq[origin] = to;
				else
				{
					ChangeRef(eq[origin], to);

					if (eq[origin] > to)
						eq[origin] = to;
				}
			}

			for (int i = 0; i < s1.Length; i++)
			{
				ChangeRef(s1[i] - 'a', s2[i] - 'a');
				ChangeRef(s2[i] - 'a', s1[i] - 'a');
			}

			StringBuilder sb = new();
			for (int i = 0; i < baseStr.Length; i++)
			{
				int map = baseStr[i] - 'a';
				while (eq[map] != map)
				{
					map = eq[map];
				}
				sb.Append((char)(map + 'a'));
			}
			return sb.ToString();
		}
	}
}