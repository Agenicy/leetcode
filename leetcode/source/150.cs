using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q150
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.EvalRPN(new[] { "4", "13", "5", "/", "+" }));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public int EvalRPN(string[] tokens)
		{
			Stack<int> stack = new();
			int a, b;
			foreach (var next in tokens)
			{
				switch (next)
				{
					case "+":
						a = stack.Pop(); b = stack.Pop();
						stack.Push(b + a);
						break;
					case "-":
						a = stack.Pop(); b = stack.Pop();
						stack.Push(b - a);
						break;
					case "*":
						a = stack.Pop(); b = stack.Pop();
						stack.Push(b * a);
						break;
					case "/":
						a = stack.Pop(); b = stack.Pop();
						stack.Push(b / a);
						break;
					default:
						stack.Push(int.Parse(next));
						break;
				}
			}
			return stack.Pop();
		}
	}
}