using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q948
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.BagOfTokensScore(Parser.ParseArr1D("[81,91,31]"), 73));
			Log.Print(solution.BagOfTokensScore(Parser.ParseArr1D("[100,200,300,400]"), 200));
			Log.Print("The answer should be 1/ 2 ");
		}
	}
	public class Solution
	{
		public int BagOfTokensScore(int[] tokens, int power)
		{
			Array.Sort(tokens);

			int front = 0, rear = tokens.Length - 1;
			int score = 0;
			while (front < rear)
			{
				if (power < tokens[front] && score == 0) return score;
				while (power > tokens[front])
				{
					power -= tokens[front++];
					++score;
				}
				if (front < rear)
				{
					power += tokens[rear--];
					--score;
				}
			}
			if (front == rear && power >= tokens[front])
				score++;
			return score;
		}
	}
}