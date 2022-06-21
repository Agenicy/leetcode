using System;
using System.Collections.Generic;
using System.Linq;


namespace Q1642
{
	public class Solution
	{
		class GapCounter
		{
			public int times = 0;
			public int values = 0;
			public GapCounter(int v, int t) { times = t; values = v; }
		}

		class GapHandler
		{

			LinkedList<GapCounter> allGap = new LinkedList<GapCounter>();
			public void Add(int value)
			{
				if (allGap.Count == 0)
				{
					allGap.AddFirst(new LinkedListNode<GapCounter>(new GapCounter(value, 1)));
				}
				else
				{
					LinkedListNode<GapCounter> ind = allGap.First;
					LinkedListNode<GapCounter> prev = null;
					for (; ind.Value.values > value; ind = ind.Next)
					{
						prev = ind;
						if (ind == allGap.Last)
							break;
					}

					if (ind.Value.values == value)
						ind.Value.times++;
					else if (ind.Value.values > value)
					{
						// occurs at the end of list
						allGap.AddAfter(ind, new LinkedListNode<GapCounter>(new GapCounter(value, 1)));
					}
					else
					{
						if (prev == null)
							allGap.AddFirst(new LinkedListNode<GapCounter>(new GapCounter(value, 1)));
						else
							allGap.AddAfter(prev, new LinkedListNode<GapCounter>(new GapCounter(value, 1)));
					}
				}
			}

			public int Peek()
			{
				if (allGap.Count > 0)
					return allGap.First.Value.values;
				else
					return int.MinValue;
			}

			public void Pop()
			{
				if (allGap.First.Value.times > 1)
				{
					allGap.First.Value.times--;
				}
				else
				{
					allGap.RemoveFirst();
				}
			}
		}

		public int FurthestBuilding(int[] heights, int bricks, int ladders)
		{
			int farthest = 0;
			long leftLadder = ladders;
			long leftBrick = bricks;
			GapHandler gapHandler = new GapHandler();

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
							leftBrick -= gap;
							gapHandler.Add(gap);
						}
						else if (leftLadder > 0)
						{
							int max = gapHandler.Peek();
							if (max > gap)
							{
								// use ladder at old
								leftBrick += max - gap;
								leftLadder -= 1;
								gapHandler.Pop();
								gapHandler.Add(gap);
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
