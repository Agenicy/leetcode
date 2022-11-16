using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace leetcode.Q374
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.GuessNumber(10));
			Log.Print("The answer should be ");
		}
	}
	/** 
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is higher than the picked number
 *			      1 if num is lower than the picked number
 *               otherwise return 0
 * int guess(int num);
 */
	public class GuessGame
	{
		int pick = 6;
		public int guess(int num) => num > pick ? -1 : num < pick ? 1 : 0;
	}

	public class Solution : GuessGame
	{
		public int GuessNumber(int n)
		{
			int g = n;
			int next = g;
			while (next > 0)
			{
				switch (guess(g))
				{
					case 0: return g;
					case -1:
						g -= next;
						break;
					case 1:
						break;
				}
				next = (next + 1) / 2;
				g += next;
			}
			return g;
		}
	}
}