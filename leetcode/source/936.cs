using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q936
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.MovesToStamp("abc", "aabcbccc"));
			Log.Print(solution.MovesToStamp("abc", "aababc"));
			Log.Print("The answer should be ");
		}
	}

	public class Solution
	{
		public int[] MovesToStamp(string stamp, string t)
		{
			StringBuilder target = new(t);
			int len = target.Length - stamp.Length + 1;
			List<int> result = new();

			int total_stamp = 0, turn_stamp = -1;
			while (turn_stamp != 0)
			{
				turn_stamp = 0;
				for (int size = stamp.Length; size > 0; size--)
				{
					for (int i = 0; i <= stamp.Length - size; i++)
					{
						StringBuilder sb = new();
						for (int tmp = 0; tmp < i; tmp++)
							sb.Append("*");
						sb.Append(stamp.Substring(i, size));

						for (int tmp = 0; tmp < stamp.Length - size - i; tmp++)
							sb.Append("*");
						string new_stamp = sb.ToString();

						int pos = target.ToString().IndexOf(new_stamp, 0);
						while (pos != -1)
						{
							result.Add(pos);
							turn_stamp += size;
							for (int ind = pos; ind < pos + stamp.Length; ind++)
							{
								target[ind] = '*';
							}
							pos = target.ToString().IndexOf(new_stamp, 0);
						}
					}
				}
				total_stamp += turn_stamp;
			}
			result.Reverse();

			return total_stamp == target.Length ? result.ToArray() : new int[0];

		}
	}
}