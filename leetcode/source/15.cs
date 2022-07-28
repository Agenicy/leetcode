using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q15
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();


			Log.Print(solution.ThreeSum(Parser.ParseArr1D("[0,0,0,0]")));
			Log.Print(solution.ThreeSum(Parser.ParseArr1D("[-1,0,1,2,-1,-4]")));
			Log.Print(solution.ThreeSum(Parser.ParseArr1D("[0,1,1]")));
			Log.Print(solution.ThreeSum(Parser.ParseArr1D("[0,0,0]")));
			Log.Print("The answer should be [[-1,-1,2],[-1,0,1]]/ []/ [0,0,0]");
		}
	}
	public class Solution
	{
		public IList<IList<int>> ThreeSum(int[] nums)
		{
			List<IList<int>> list = new List<IList<int>>();
			HashSet<int> set = new();

			Dictionary<int, List<int>> check = new();
			for (int i = 0; i < nums.Length; i++)
			{
				if (!check.ContainsKey(nums[i]))
					check[nums[i]] = new List<int>();
				check[nums[i]].Add(i);
			}

			for (int i = 0; i < nums.Length; i++)
			{
				for (int j = i + 1; j < nums.Length; j++)
				{
					int num = -(nums[i] + nums[j]);
					if (check.ContainsKey(num))
					{
						var temp = new List<int>() { nums[i], nums[j], num };
						temp.Sort();
						int hash = (int)(temp[0] * 10007 + temp[1] * 1009 + temp[2]);
						if (set.Contains(hash))
							continue;
						for (int k = 0; k < check[num].Count; k++)
						{
							if (check[num][k] > j)
							{
								set.Add(hash);
								list.Add(temp);
								break;
							}
						}
					}
				}
			}
			return list;
		}
	}
}