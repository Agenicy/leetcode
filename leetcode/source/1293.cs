using leetcode.Q429;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace leetcode.Q1293
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.ToString());
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		class Node
		{
			public int x, y;
			public int step = 0;
			public int breakLeft = 0;
			public Node(int x, int y, int step, int breakLeft)
			{
				this.x = x; this.y = y;
				this.step = step;
				this.breakLeft = breakLeft;
			}
			public override int GetHashCode()
			{
				return (x, y, breakLeft).GetHashCode();
			}
		}

		public int ShortestPath(int[][] grid, int k)
		{
			int xMax = grid.Length;
			int yMax = grid[0].Length;
			PriorityQueue<Node, Node> FS = new(Comparer<Node>.Create((x, y) => -(x.x + x.y).CompareTo(y.x + y.y)));
			PriorityQueue<Node, Node> BS = new(Comparer<Node>.Create((x, y) => (x.x + x.y).CompareTo(y.x + y.y)));
			Node head = new Node(0, 0, 0, (k + 1) / 2);
			Node tail = new Node(xMax - 1, yMax - 1, 0, k / 2);
			FS.Enqueue(head, head);
			BS.Enqueue(tail, tail);
			HashSet<Node> visited = new();

			while (FS.Count > 0 && BS.Count > 0)
			{
				{
					Node next = FS.Dequeue();
					foreach ((int xb, int yb) in new[] { (0, 1), (0, -1), (1, 0), (-1, 0) })
					{
						int xs = next.x + xb;
						int ys = next.y + yb;
						if (0 <= xs && xs < xMax && 0 <= ys && ys < yMax)
						{
						}
					}
				}
			}
		}
	}
}