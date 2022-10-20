using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q12
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.ToString());
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public string IntToRoman(int num)
		{
			StringBuilder sb = new();
			while(num >= 1000)
			{
				num -= 1000;
				sb.Append("M");
			}
			if(num >= 900)
			{
				num -= 900;
				sb.Append("CM");
			}
			if (num >= 500)
			{
				num -= 500;
				sb.Append("D");
			}
			if (num >= 400)
			{
				num -= 400;
				sb.Append("CD");
			}
			while (num >= 100)
			{
				num -= 100;
				sb.Append("C");
			}

			if (num >= 90)
			{
				num -= 90;
				sb.Append("XC");
			}
			if (num >= 50)
			{
				num -= 50;
				sb.Append("L");
			}
			if (num >= 40)
			{
				num -= 40;
				sb.Append("XL");
			}
			while (num >= 10)
			{
				num -= 10;
				sb.Append("X");
			}

			if (num >= 9)
			{
				num -= 9;
				sb.Append("IX");
			}
			if (num >= 5)
			{
				num -= 5;
				sb.Append("V");
			}
			if (num >= 4)
			{
				num -= 4;
				sb.Append("IV");
			}
			while (num >= 1)
			{
				num -= 1;
				sb.Append("I");
			}

			return sb.ToString();
		}
	}
}