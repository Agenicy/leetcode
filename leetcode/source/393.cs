using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q393
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			//Log.Print(solution.ValidUtf8(Parser.ParseArr1D("[248,130,130,130]")));
			//Log.Print(solution.ValidUtf8(Parser.ParseArr1D("[255]")));
			Log.Print(solution.ValidUtf8(Parser.ParseArr1D("[197,130,1]")));
			Log.Print(solution.ValidUtf8(Parser.ParseArr1D("[235,140,4]")));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public bool ValidUtf8(int[] data)
		{
			int pntr = 0;
			while (pntr < data.Length)
			{
				if (((data[pntr] & 0b_1111_1000) ^ 0b_1111_0000) == 0)
				{
					if (data.Length < pntr + 4 || ((data[pntr + 1] & 0b_1100_0000) ^ 0b_1000_0000) != 0 || ((data[pntr + 2] & 0b_1100_0000) ^ 0b_1000_0000) != 0 || ((data[pntr + 3] & 0b_1100_0000) ^ 0b_1000_0000) != 0)
						return false;
					pntr += 4;
				}
				else if (((data[pntr] & 0b_1111_0000) ^ 0b_1110_0000) == 0)
				{
					if (data.Length < pntr + 3 || ((data[pntr + 1] & 0b_1100_0000) ^ 0b_1000_0000) != 0 || ((data[pntr + 2] & 0b_1100_0000) ^ 0b_1000_0000) != 0)
						return false;
					pntr += 3;
				}
				else if (((data[pntr] & 0b_1110_0000) ^ 0b_1100_0000) == 0)
				{
					if (data.Length < pntr + 2 || ((data[pntr + 1] & 0b_1100_0000) ^ 0b_1000_0000) != 0)
						return false;
					pntr += 2;
				}
				else if (data[pntr] < 0b_1000_0000)
				{
					if (data.Length < pntr + 1)
						return false;
					pntr += 1;
				}
				else
					return false;
			}
			return true;
		}
	}
}