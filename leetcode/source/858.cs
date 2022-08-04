using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q858
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.MirrorReflection(2, 1));
			Log.Print(solution.MirrorReflection(3, 1));
			Log.Print(solution.MirrorReflection(4, 3));
			Log.Print(solution.MirrorReflection(3, 2));
			Log.Print("The answer should be 2/ 1/ 2/ 0");
		}
	}
	public class Solution
	{
		public int MirrorReflection(int p, int q)
		{
			int gcd = GCD(p, q);
			p /= gcd;
			q /= gcd;
			if (p % q == 0) return 2 - (p / q) % 2;
			if (p % 2 == 0) return 2;
			else return q % 2;
		}

		int GCD(int p, int q)
		{
			if (p == 0) return q;
			else if (q == 0) return p;
			else if (p == 1 || q == 1) return 1;
			else return GCD(Math.Min(p, q), Math.Abs(p - q));
		}
	}
}