using System;
using System.Collections.Generic;
using System.Linq;


namespace Q1642
{
	public class Solution
	{

		public int FurthestBuilding(int[] heights, int bricks, int ladders)
		{
			int farthest = 0;
			long leftLadder = ladders;
			long leftBrick = bricks;
			List<int> allGap = new List<int>();
			checked
			{
				for (int i = 0; i < heights.Length - 1; i++, farthest++)
				{
					int gap = heights[i + 1] - heights[i];
					if (gap > 0)
					{
						if (leftBrick >= gap)
						{
							// go and record
							allGap.Add(gap);

							leftBrick -= gap;
						}
						else if (leftLadder > 0)
						{
							int max = int.MinValue;
							if (allGap.Count > 0)
								max = allGap.Max();
							if (max > gap)
							{
								// use ladder at old
								leftBrick += max;
								leftBrick -= gap;
								leftLadder -= 1;
								allGap.Remove(max);
								allGap.Add(gap);
							}
							else
							{
								// use ladder to ignore this
								leftLadder -= 1;

							}
						}
						else
						{
							return farthest;
						}
					}
				}
			}
			return farthest;
		}

	}
}
