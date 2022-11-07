using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q1323
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.Maximum69Number(9669));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int Maximum69Number(int num)
		{
			char[] s = num.ToString().ToCharArray();
			for (int i = 0; i < s.Length; i++)
			{
				if (s[i] == '6')
				{
					s[i] = '9';
					break;
				}
			}
			return int.Parse(new String(s));
		}
	}
}