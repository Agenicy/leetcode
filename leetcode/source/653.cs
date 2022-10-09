using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q653
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
		public bool FindTarget(TreeNode root, int k)
		{

			HashSet<int> visited = new();

			bool Inplace(TreeNode ptr)
			{
				if (visited.Contains(k - ptr.val))
					return true;
				visited.Add(ptr.val);

				if (ptr.left != null)
					if(Inplace(ptr.left)) return true;
				if (ptr.right != null)
					if (Inplace(ptr.right)) return true;
				return false;
			}
			return Inplace(root);
		}
	}
}