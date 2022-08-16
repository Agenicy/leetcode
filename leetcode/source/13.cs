using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q13
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.RomanToInt("III"));
			Log.Print(solution.RomanToInt("LVIII"));
			Log.Print(solution.RomanToInt("MCMXCIV"));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int RomanToInt(string s)
		{
			int ret = 0;

			if (s.Contains("CM"))
			{
				s = s.Replace("CM", "");
				ret += 900;
			}
			if (s.Contains("CD"))
			{
				s = s.Replace("CD", "");
				ret += 400;
			}
			if (s.Contains("XC"))
			{
				s = s.Replace("XC", "");
				ret += 90;
			}
			if (s.Contains("XL"))
			{
				s = s.Replace("XL", "");
				ret += 40;
			}
			if (s.Contains("IX"))
			{
				s = s.Replace("IX", "");
				ret += 9;
			}
			if (s.Contains("IV"))
			{
				s = s.Replace("IV", "");
				ret += 4;
			}

			foreach (var x in s)
			{
				switch (x)
				{
					case 'M':
						ret += 1000;
						break;
					case 'D':
						ret += 500;
						break;
					case 'C':
						ret += 100;
						break;
					case 'L':
						ret += 50;
						break;
					case 'X':
						ret += 10;
						break;
					case 'V':
						ret += 5;
						break;
					case 'I':
						ret += 1;
						break;
					default:
						break;
				}
			}

			return ret;
		}
	}
}