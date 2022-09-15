using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode
{
	partial class Program
	{
		static void Main(string[] args)
		{
			Q2007.Program.Run();
		}
	}
	#region fold
	public class Parser
	{
		public static int[] ParseArr1D(string input)
		{
			System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>();
			input = input.Replace(" ", "").Replace("[", "").Replace("]", "");
			var array = input.Split(',');
			for (int i = 0; i < array.Length; i += 1)
			{
				list.Add(int.Parse(array[i]));
			}
			return list.ToArray();
		}
		public static int[][] ParseArr2D(string input)
		{
			List<int[]> ret = new List<int[]>();
			input = input.Replace(" ", "");
			input = input.Substring(2, input.Length - 3);
			foreach (var s in input.Replace("],", "").Replace("]", "").Split("["))
			{
				string[] array = s.Split(',');
				var list = new List<int>(Enumerable.Range(0, array.Length).Select(x => int.Parse(array[x])));
				ret.Add(list.ToArray());
			}
			return ret.ToArray();
		}

	}

	public class Log
	{
		public static void Print(bool s) => Console.WriteLine(s);
		public static void Print(string s) => Console.WriteLine(s);
		public static void Print(int s) => Console.WriteLine(s);

		public static void Print(int[] arr)
		{
			var rowCount = arr.GetLength(0);
			Console.Write("[");
			for (int row = 0; row < rowCount; row++)
			{
				Console.Write(String.Format("{0} ", arr[row]));
			}
			Console.Write("]");
			Console.WriteLine();
		}

		public static void Print(int[,] arr)
		{
			var rowCount = arr.GetLength(0);
			var colCount = arr.GetLength(1);
			for (int row = 0; row < rowCount; row++)
			{
				for (int col = 0; col < colCount; col++)
					Console.Write(String.Format("{0} ", arr[row, col]));
				Console.WriteLine();
			}
			Console.WriteLine();
		}
		public static void Print(IList<int> arr)
		{
			var rowCount = arr.Count();
			Console.Write("[");
			for (int row = 0; row < rowCount; row++)
			{
				Console.Write(String.Format("{0} ", arr[row]));
			}
			Console.Write("]");
			Console.WriteLine();
		}
		public static void Print(IList<IList<int>> arr)
		{
			foreach (var row in arr)
			{
				Console.Write("[");
				foreach (var col in row)
					Console.Write(String.Format("{0} ", col));
				Console.Write("]");
				Console.WriteLine();
			}
			Console.WriteLine();
		}
		public static void Print(IList<IList<string>> arr)
		{
			foreach (var row in arr)
			{
				Console.Write("[");
				foreach (var col in row)
					Console.Write(String.Format("{0} ", col));
				Console.Write("]");
				Console.WriteLine();
			}
			Console.WriteLine();
		}

		internal static void Print(IList<string> list)
		{
			var rowCount = list.Count();
			Console.Write("[");
			for (int row = 0; row < rowCount; row++)
			{
				Console.Write(list[row]);
			}
			Console.Write("]");
			Console.WriteLine();
		}
		public static void Print(TreeNode s) => TreeNode.Preorder(s);
	}

	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
		{
			this.val = val;
			this.left = left;
			this.right = right;
		}

		public static TreeNode Build(string input)
		{
			List<int?> value = new() { null };
			input = input.Replace(" ", "").Replace("[", "").Replace("]", "");
			var array = input.Split(',');
			for (int i = 0; i < array.Length; i += 1)
			{
				if (array[i] != "null")
					value.Add(int.Parse(array[i]));
				else
					value.Add(null);
			}

			TreeNode[] temp = new TreeNode[value.Count];
			for (int i = 0; i < value.Count; i++)
			{
				if(value[i] != null)
					temp[i] = new TreeNode((int)value[i]);
				else
					temp[i] = null;
			}
			int front = 1, last = 2;
			while(last < value.Count)
			{
				while (temp[front] is null)
					++front;

				temp[front].left = temp[last++];
				temp[front++].right = (last < value.Count)?temp[last++]:null;
			}

			return temp[1];
		}

		public static void Preorder(TreeNode root)
		{
			if (root == null)
				Console.WriteLine("[null]");
			else
			{
				Console.Write("[" + root.val.ToString());
				Queue<TreeNode> treeNodes = new Queue<TreeNode>();
				treeNodes.Enqueue(root.left);
				treeNodes.Enqueue(root.right);

				while (treeNodes.Count > 0)
				{
					var next = treeNodes.Dequeue();
					if (next == null)
					{
						Console.Write(",null");
					}
					else
					{
						Console.Write("," + next.val.ToString());
						treeNodes.Enqueue(next.left);
						treeNodes.Enqueue(next.right);
					}
				}
				Console.Write("]\n");
			}
		}

		public override string ToString()
		{
			return $"{val}, {left.val}, {right.val}";
		}
	}

	public class ListNode
	{
		public int val;
		public ListNode next;
		public ListNode(int val = 0, ListNode next = null)
		{
			this.val = val;
			this.next = next;
		}

		public static ListNode Build(int[] ints)
		{
			ListNode listNode = new ListNode(ints[0]);
			ListNode last = listNode;

			for (int i = 1; i < ints.Length; i++)
			{
				last.next = new ListNode(ints[i]);
				last = last.next;
			}
			return listNode;
		}

		public override string ToString()
		{
			if (next != null)
				return val.ToString() + next.ToString();
			else return val.ToString();
		}
	}
	#endregion
}
