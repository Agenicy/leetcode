using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q899
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.OrderlyQueue("baaca", 3));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public string OrderlyQueue(string s, int k)
		{
			LinkedList<char> str = new LinkedList<char>(s);
			StringBuilder sb = new StringBuilder();
			while(str.Count > 0)
			{
				LinkedListNode<char> min = str.First;
				LinkedListNode<char> now = str.First.Next;
				for (int i = 1; i < k & now != null; i++)
				{
					if (now.Value < min.Value)
						min = now;
					now = now.Next;
				}
				sb.Append(min.Value);
				str.Remove(min);
			}
			return sb.ToString();
		}
	}
}