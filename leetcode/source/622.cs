using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace leetcode.Q622
{
	public class Program
	{
		public static void Run()
		{
			string[] op_code = new[] { "MyCircularQueue", "enQueue", "deQueue", "enQueue", "enQueue", "deQueue", "isFull", "isFull", "Front", "deQueue", "enQueue", "Front", "enQueue", "enQueue", "Rear", "Rear", "deQueue", "enQueue", "enQueue", "Rear", "Rear", "Front", "Rear", "Rear", "deQueue", "enQueue", "Rear", "deQueue", "Rear", "Rear", "Front", "Front", "enQueue", "enQueue", "Front", "enQueue", "enQueue", "enQueue", "Front", "isEmpty", "enQueue", "Rear", "enQueue", "Front", "enQueue", "enQueue", "Front", "enQueue", "deQueue", "deQueue", "enQueue", "deQueue", "Front", "enQueue", "Rear", "isEmpty", "Front", "enQueue", "Front", "deQueue", "enQueue", "enQueue", "deQueue", "deQueue", "Front", "Front", "deQueue", "isEmpty", "enQueue", "Rear", "Front", "enQueue", "isEmpty", "Front", "Front", "enQueue", "enQueue", "enQueue", "Rear", "Front", "Front", "enQueue", "isEmpty", "deQueue", "enQueue", "enQueue", "Rear", "deQueue", "Rear", "Front", "enQueue", "deQueue", "Rear", "Front", "Rear", "deQueue", "Rear", "Rear", "enQueue", "enQueue", "Rear", "enQueue" };
			int?[] param = Parser.ParseArr1D_Nullable("[[81],[69],[],[92],[12],[],[],[],[],[],[28],[],[13],[45],[],[],[],[24],[27],[],[],[],[],[],[],[88],[],[],[],[],[],[],[53],[39],[],[28],[66],[17],[],[],[47],[],[87],[],[92],[94],[],[59],[],[],[99],[],[],[84],[],[],[],[52],[],[],[86],[30],[],[],[],[],[],[],[45],[],[],[83],[],[],[],[22],[77],[23],[],[],[],[14],[],[],[90],[57],[],[],[],[],[34],[],[],[],[],[],[],[],[49],[59],[],[71]]");
			char[] chars = new char[0];
			MyCircularQueue obj = new MyCircularQueue((int)param[0]);
			for (int i = 1; i < op_code.Length; i++)
			{
				Log.Print(obj.GetType().GetMethod(op_code[i], BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).Invoke(obj, param[i] == null ? null : new object[] { param[i] }));
			}

			Log.Print("The answer should be ");
		}
	}
	public class MyCircularQueue
	{
		int[] buffer = null;
		int front = 0, rear = 0;
		int Count = 0;
		public MyCircularQueue(int k)
		{
			buffer = new int[k];
		}

		public bool EnQueue(int value)
		{
			if (IsFull())
				return false;

			if (!IsEmpty() || front != rear)
				rear = (rear + 1) % buffer.Length;

			++Count;
			buffer[rear] = value;
			return true;
		}

		public bool DeQueue()
		{
			if (IsEmpty())
				return false;

			--Count;
			front = (front + 1) % buffer.Length;
			return true;
		}

		public int Front()
		{
			if (IsEmpty())
				return -1;
			else
				return buffer[front];
		}

		public int Rear()
		{
			if (IsEmpty())
				return -1;
			else
				return buffer[rear];
		}

		public bool IsEmpty()
		{
			return Count == 0;
		}

		public bool IsFull()
		{
			return Count == buffer.Length;
		}
	}
}