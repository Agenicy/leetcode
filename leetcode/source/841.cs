using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q841
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.CanVisitAllRooms(Parser.ParseArr2D("[[1],[2],[3],[0]]")));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public bool CanVisitAllRooms(IList<IList<int>> rooms)
		{
			BitArray bitArray = new BitArray(rooms.Count);
			bitArray[0] = true;
			HashSet<int> keys = new();
			void GetKeys(int id)
			{
				foreach (var k in rooms[id])
				{
					if (!bitArray[k])
						keys.Add(k);
				}
			}
			void Unlock(int id)
			{
				if (bitArray[id])
					return;
				bitArray[id] = true;
				GetKeys(id); 
				keys.Remove(id);
			}
			GetKeys(0);
			while(keys.Count > 0)
			{
				Unlock(keys.First());
			}
			return bitArray.Cast<bool>().All(x => x);
		}
	}
}