using System;

namespace Q1689
{
	public class Solution
	{
		public int MinPartitions(string n)
		{
			int max = 0;
			for (int i = 0; i < n.Length; i++)
			{
				max = Math.Max(max, n[i]-'0');
			}
			return max;
		}
	}
}