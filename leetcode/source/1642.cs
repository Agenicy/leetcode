using System;
using System.Collections.Generic;

namespace Q1642
{
	public class Solution
	{
		class Gap
		{
			public int index, value;
			public Gap(int index, int value)
			{
				this.index = index;
				this.value = value;
				int_IndexRecord.Add(index);
			}

			public static List<int> int_IndexRecord = new List<int>();
		}

		public int FurthestBuilding(int[] heights, int bricks, int ladders)
		{
			List<Gap> allGap = new List<Gap>();

			for (int i = 0; i < heights.Length - 1; i++)
			{
				int gap = heights[i + 1] - heights[i];
				if (gap > 0)
					allGap.Add(new Gap(i, gap));
			}

			List<Gap> sortestGap = new List<Gap>(allGap);
			sortestGap.Sort((a, b) => b.value.CompareTo(a.value));

			int farthest = heights.Length - 1;

			long sum = Check(sortestGap, ladders);
			while (sum > bricks)
			{
				/* solve by greedy
				 * see a ladder as some bricks,
				 * assume Gap A = 10 at position 1; Gap B = 8 at position 2; Gap C = 9 at position 3,
				 * put a ladder at A can save more bricks.
				 * 
				 * So, no matter how far we want to travel, put a ladder at A is the best strategy.
				 * 
				 * Another example:
				 * assume Gap A = 9 at position 1; Gap B = 8 at position 2; Gap C = 10 at position 3
				 * put a ladder at C is the best strategy.
				 * but if the sum of brick is only 16, which can't reach position 3
				 * we can trim the last position (which means 3) and try again.
				 * This way, we simplified the question to: Gap A = 9 at position 1; Gap B = 8 at position 2
				 * thus, put a ladder at A is still the best strategy.
				 */
				/* Finally, we got a strategy that:
				 * swap the biggest gap as a ladder, if we still can't pass,
				 * trim the last building and try it again.
				 */
				int rear = Gap.int_IndexRecord.Count - 1;
				farthest = Gap.int_IndexRecord[rear];

				sum -= allGap[rear].value;
				allGap.RemoveAt(rear);
				sortestGap.RemoveAll(x => x.index == farthest);
				Gap.int_IndexRecord.RemoveAt(rear);

				allGap.Sort((a, b) => b.value.CompareTo(a.value));

			}
			return farthest;
		}

		long Check(List<Gap> sortedGap, int from)
		{
			long sum = 0;
			checked
			{
				for (int i = from; i < sortedGap.Count; i++)
				{
					sum += sortedGap[i].value;
				}
			}
			return sum;
		}
	}
}
