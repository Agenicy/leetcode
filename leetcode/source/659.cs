using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q659
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			//Log.Print(solution.IsPossible(Parser.ParseArr1D("[1,2,3,3,4,5]")));
			Log.Print(solution.IsPossible(Parser.ParseArr1D("[1,2,3,3,4,4,5,5]")));
			Log.Print(solution.IsPossible(Parser.ParseArr1D("[1,2,3,4,4,5]")));
			Log.Print("The answer should be t/ t/ f");
		}
	}
	public class Solution
	{
		public bool IsPossible(int[] nums)
		{
			List<List<int>> pq = new();
			pq.Add(new() { nums[0] });

			for (int i = 1; i < nums.Length; i++)
			{
				var next = nums[i];

				// clearance non useful
				for (int j = pq.Count - 1; j >= 0; j--)
				{
					if (next > (pq[j].Last() + 1))
					{
						if (pq[j].Count < 3)
							return false;
						pq.RemoveAt(j);
					}
				}

				bool needAdd = true;

				for (int j = pq.Count - 1; j >= 0; j--)
				{
					var select = pq[j];
					if (next > select.Last())
					{
						select.Add(next);
						needAdd = false;
						break;
					}
				}
				if (needAdd)
					pq.Add(new() { next });

				pq.Sort((a, b) => (b.Count.CompareTo(a.Count)));
			}
			return pq.Last().Count >= 3;
		}
	}
}