using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q729
{
	public class Program
	{
		public static void Run()
		{
			MyCalendar myCalendar;
			myCalendar = new MyCalendar(); 
			Log.Print(myCalendar.Book(20, 29));
			Log.Print(myCalendar.Book(13, 22));
			Log.Print(myCalendar.Book(44, 50));
			Log.Print(myCalendar.Book(1, 7));
			Log.Print(myCalendar.Book(2, 10));
			Log.Print(myCalendar.Book(14, 20));
			Log.Print(myCalendar.Book(19, 25));
			Log.Print(myCalendar.Book(36, 42));
			Log.Print(myCalendar.Book(45, 50));
			Log.Print(myCalendar.Book(47, 50));
			Log.Print(myCalendar.Book(39, 45));
			Log.Print(myCalendar.Book(44, 50));
			Log.Print(myCalendar.Book(16, 25));
			Log.Print(myCalendar.Book(45, 50));
			Log.Print(myCalendar.Book(45, 50));
			Log.Print(myCalendar.Book(12, 20));
			Log.Print(myCalendar.Book(21, 29));
			Log.Print(myCalendar.Book(11, 20));
			Log.Print(myCalendar.Book(12, 17));
			Log.Print(myCalendar.Book(34, 40));
			Log.Print(myCalendar.Book(10, 18));
			Log.Print(myCalendar.Book(38, 44));
			Log.Print(myCalendar.Book(23, 32));
			Log.Print(myCalendar.Book(38, 44));
			Log.Print(myCalendar.Book(15, 20));
			Log.Print(myCalendar.Book(27, 33));
			Log.Print(myCalendar.Book(34, 42));
			Log.Print(myCalendar.Book(44, 50));
			Log.Print(myCalendar.Book(35, 40));
			Log.Print(myCalendar.Book(24, 31));
			Log.Print("\n");

			/*
			myCalendar = new MyCalendar();
			Log.Print(myCalendar.Book(47, 50));
			Log.Print(myCalendar.Book(33, 41));
			Log.Print(myCalendar.Book(39, 45));
			Log.Print(myCalendar.Book(33, 42));
			Log.Print(myCalendar.Book(25, 32));
			Log.Print(myCalendar.Book(26, 35));
			Log.Print(myCalendar.Book(19, 25));
			Log.Print(myCalendar.Book(3, 8));
			Log.Print(myCalendar.Book(8, 13));
			Log.Print(myCalendar.Book(18, 27));
			Log.Print("\n");

			myCalendar = new MyCalendar();
			Log.Print(myCalendar.Book(10, 20)); // return True
			Log.Print(myCalendar.Book(15, 25)); // return False, It can not be booked because time 15 is already booked by another event.
			Log.Print(myCalendar.Book(20, 30)); // return True, The event can be booked, as the first event takes every time less than 20, but not including 20.
			*/

		}
	}



	public class MyCalendar
	{
		SegmentTree segmentTree;

		public MyCalendar()
		{
			segmentTree = null;
		}

		public bool Book(int start, int end)
		{
			if (segmentTree == null)
			{
				segmentTree = new SegmentTree(start, end);
				return true;
			}

			var res = segmentTree.Insert(new SegmentTree(start, end));
			if (res != null)
			{
				segmentTree = res;
				return true;
			}
			else
				return false;
		}
	}

	class SegmentTree
	{
		public int min, max;
		public SegmentTree left, right;
		public SegmentTree(int min, int max)
		{
			this.min = min;
			this.max = max;
		}

		public SegmentTree Insert(SegmentTree node)
		{
			if (node.min >= this.max)
			{
				var par = new SegmentTree(this.min, node.max);
				par.left = this;
				par.right = node;
				return par;
			}
			else if (this.min >= node.max)
			{
				var par = new SegmentTree(node.min, this.max);
				par.right = this;
				par.left = node;
				return par;
			}

			else if ((this.min <= node.min && this.max >= node.max))
			{
				if (left == null || right == null)
					return null;

				if (node.min >= right.min)
				{
					var res = right.Insert(node);
					if (res != null)
					{
						right = res;
						return this;
					}
				}
				else if (node.max <= left.max)
				{
					var res = left.Insert(node);
					if (res != null)
					{
						left = res;
						return this;
					}
				}
				else if (node.min >= left.max && node.max <= right.min)
				{
					var par = new SegmentTree(left.min, node.max);
					par.right = node;
					par.left = left;
					left = par;
					return this;
				}
				return null;
			}

			return null;
		}
	}
}