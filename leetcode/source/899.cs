using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q899
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.OrderlyQueue("baaca", 3));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public string OrderlyQueue(string s, int k)
		{
			if(k == 1)
			{
				string str = s + s;
				return Enumerable.Range(0, s.Length).Min(x => str.Substring(x, s.Length));
			}
			else
			{
				char[] str = s.ToCharArray();
				Array.Sort(str);
				return new string(str);
			}
		}
	}
}