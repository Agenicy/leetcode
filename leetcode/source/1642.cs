using System;
using System.Collections.Generic;
using System.Linq;


namespace leetcode.Q1642
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();
			Console.WriteLine(solution.FurthestBuilding(new[] { 4, 2, 7, 6, 9, 14, 12 }, 5, 1));
			Console.WriteLine(solution.FurthestBuilding(new[] { 4, 12, 2, 7, 3, 18, 20, 3, 19 }, 10, 2));
			Console.WriteLine(solution.FurthestBuilding(new[] { 14, 3, 19, 3 }, 17, 0));
			Console.WriteLine(solution.FurthestBuilding(new[] { 2, 7, 9, 12 }, 5, 1));
			Console.WriteLine(solution.FurthestBuilding(new[] { 1, 13, 1, 1, 13, 5, 11, 11 }, 10, 8));
			Console.WriteLine("The answer should be 4/ 7/ 3/ 3/ 7");


			string[] lines = System.IO.File.ReadAllLines("../../../testcase/1642/testcase1.txt");
			List<int> vs = new List<int>();
			foreach (var item in lines[0].Split(','))
			{
				vs.Add(int.Parse(item));
			}
			Console.WriteLine(solution.FurthestBuilding(vs.ToArray(), int.Parse(lines[1]), int.Parse(lines[2])));
			Console.WriteLine("The answer should be 72329");

			lines = System.IO.File.ReadAllLines("../../../testcase/1642/testcase2.txt");
			vs = new List<int>();
			foreach (var item in lines[0].Split(','))
			{
				vs.Add(int.Parse(item));
			}
			Console.WriteLine(solution.FurthestBuilding(vs.ToArray(), int.Parse(lines[1]), int.Parse(lines[2])));
			Console.WriteLine("The answer should be 589");
		}
	}
	public class Solution
	{
		class GapHandler
		{
			List<int> heap;

			public GapHandler(int size = 16)
			{
				heap = new List<int>(size) { -1, -1 };
			}
			int root { get => heap[1]; set => heap[1] = value; }

			void Heapify(int index)
			{
				int parent = index / 2;
				if(heap[parent] < heap[index])
				{
					(heap[parent], heap[index]) = (heap[index], heap[parent]);
				}
				if (parent > 1)
					Heapify(parent);
			}

			void HeapifyTopDown(int index)
			{
				int left = index * 2;
				int right = left + 1;

				if(left < heap.Count && right < heap.Count && heap[left]!=-1 && heap[right] != -1)
				{
					if(heap[left] > heap[right])
					{
						heap[index] = heap[left];
						HeapifyTopDown(left);
					}
					else
					{
						heap[index] = heap[right];
						HeapifyTopDown(right);
					}
				}else if(left < heap.Count && heap[left] != -1)
				{
					heap[index] = heap[left];
					HeapifyTopDown(left);
				}
				else if (right < heap.Count && heap[right] != -1)
				{
					heap[index] = heap[right];
					HeapifyTopDown(right);
				}
				else
				{
					// no child
					heap[index] = -1;
				}

			}

			public void Add(int value)
			{
				if (root == -1)
				{
					root = value;
				}
				else
				{
					heap.Add(value);
					Heapify(heap.Count - 1);
				}
			}

			public int Peek()
			{
				return root;
			}

			public void Pop()
			{
				HeapifyTopDown(1);
			}
		}

		public int FurthestBuilding(int[] heights, int bricks, int ladders)
		{
			int farthest = 0;
			long leftLadder = ladders;
			long leftBrick = bricks;
			GapHandler gapHandler = new GapHandler(heights.Length);

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
