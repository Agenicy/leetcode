using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q950
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.DeckRevealedIncreasing(new[] { 17, 13, 11, 2, 3, 5, 7 }));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int[] DeckRevealedIncreasing(int[] deck)
		{
			if (deck.Length <= 1) return deck;
			Array.Sort(deck);
			int[] ret = new int[deck.Length];
			int ind = 0;

			void Skip()
			{
				do
				{
					if (++ind >= ret.Length)
						ind = 1;
				}
				while (ret[ind] != 0);
			}

			for (int i = 0; i < deck.Length-1; i++)
			{
				ret[ind] = deck[i];
				if(i < deck.Length -1)
					Skip(); Skip();
			}
			Skip();
			ret[ind] = deck[deck.Length - 1];

			return ret;
		}
	}
}