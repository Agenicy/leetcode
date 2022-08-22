using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q342
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

		public bool IsPowerOfFour(int n)
		{
			switch (n)
			{
				case 1:
				case 4:
				case 16:
				case 64:
				case 256:
				case 1024:
				case 4096:
				case 16384:
				case 65536:
				case 262144:
				case 1048576:
				case 4194304:
				case 16777216:
				case 67108864:
				case 268435456:
				case 1073741824:
					return true;
				default:
					return false;
			}
		}
	}
}