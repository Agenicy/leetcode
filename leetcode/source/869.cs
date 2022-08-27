using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q869
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.ReorderedPowerOf2(1));
			Log.Print(solution.ReorderedPowerOf2(10));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{

        // Returns the count of digits of N
        // Eg. N = 112223334, returns [0,2,3,3,1,0,0,0,0,0]
        public int[] count(int N)
        {
            int[] ans = new int[10];
            while (N > 0)
            {
                ans[N % 10]++;
                N /= 10;
            }
            return ans;
        }
        public bool ReorderedPowerOf2(int n)
		{
            int[] A = count(n);
            for (int i = 0; i < 31; ++i)
                if (Enumerable.SequenceEqual(A, count(1 << i)))
                    return true;
            return false;
        }
	}
}