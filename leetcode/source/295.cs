using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q295
{
	public class Program
	{
		public static void Run()
		{
			Log.Print("The answer should be ");
		}
	}
	public class MedianFinder
	{
		int count;
		PriorityQueue<int, int> smallQ;
		PriorityQueue<int, int> bigQ;

		public MedianFinder()
		{
			count = 0;
			smallQ = new();
			bigQ = new();
		}

		void PushSmall(int x) => smallQ.Enqueue(x, -x);
		void PushBig(int x) => bigQ.Enqueue(x, x);

		public void AddNum(int num)
		{
			Console.Write(String.Format("{0} ", num));
			if (count == 0)
			{
				PushSmall(num);
			}
			else
			{
				int med = smallQ.Peek();
				if (num <= med)
					PushSmall(num);
				else
					PushBig(num);

				if (bigQ.Count > smallQ.Count)
				{
					PushSmall(bigQ.Dequeue());
				}
				else if (bigQ.Count < smallQ.Count-1)
				{
					PushBig(smallQ.Dequeue());
				}
			}
			count++;
		}

		public double FindMedian()
		{
			if (count % 2 == 0)
				return ((float)smallQ.Peek() + bigQ.Peek()) / 2;
			else
				return smallQ.Peek();
		}
	}

	/**
	 * Your MedianFinder object will be instantiated and called as such:
	 * MedianFinder obj = new MedianFinder();
	 * obj.AddNum(num);
	 * double param_2 = obj.FindMedian();
	 */
}