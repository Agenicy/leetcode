using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q658
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.FindClosestElements(Parser.ParseArr1D("[3,5,8,10]"), 2, 15));
			Log.Print(solution.FindClosestElements(Parser.ParseArr1D("[0,0,1,2,3,3,4,7,7,8]"), 3, 5));
			Log.Print(solution.FindClosestElements(Parser.ParseArr1D("[1,2,3,4,5]"), 4, 3));
			Log.Print(solution.FindClosestElements(Parser.ParseArr1D("[1,2,3,4,5]"), 4, -1));
			Log.Print(solution.FindClosestElements(Parser.ParseArr1D("[1,1,1,10,10,10]"), 1, 9));
			Log.Print("The answer should be [3,3,4]");
		}
	}
	public class Solution
	{
		public IList<int> FindClosestElements(int[] arr, int k, int x)
		{
			LinkedList<int> ret = new();
			int place;
			for (place = 0; place < arr.Length && x > arr[place]; place++) ;
			int front = place - 1, rear = place;
			for (int i = 0; i < k; i++)
			{
				if (rear == arr.Length)
					ret.AddFirst(arr[front--]);
				else if (front == -1)
					ret.AddLast(arr[rear++]);
				else
				{
					if (x - arr[front] <= arr[rear] - x)
						ret.AddFirst(arr[front--]);
					else
						ret.AddLast(arr[rear++]);
				}
			}
			return ret.ToList();
		}
	}
}