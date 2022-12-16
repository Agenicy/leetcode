using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q232
{
	public class Program
	{
		public static void Run()
		{
			Log.Print("The answer should be ");
		}
	}
	public class MyQueue
	{
		Queue<int> inQ, outQ;
		public MyQueue()
		{
			inQ = new();
			outQ = new();
		}

		public void Push(int x)
		{
			while (outQ.Count > 0)
				inQ.Enqueue(outQ.Dequeue());

			inQ.Enqueue(x);
		}

		public int Pop()
		{
			while (inQ.Count > 0)
				outQ.Enqueue(inQ.Dequeue());

			return outQ.Dequeue();
		}

		public int Peek()
		{
			while (inQ.Count > 0)
				outQ.Enqueue(inQ.Dequeue());

			return outQ.Peek();
		}

		public bool Empty()
		{
			return inQ.Count == 0 & outQ.Count == 0;
		}
	}

}