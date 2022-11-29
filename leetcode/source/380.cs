using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace leetcode.Q380
{
	public class Program
	{
		public static void Run()
		{
			RandomizedSet obj = new RandomizedSet();
			Log.Print(obj.Insert(1));
			Log.Print(obj.Insert(2));
			Log.Print(obj.GetRandom());
			Log.Print(obj.GetRandom());
			Log.Print(obj.GetRandom());
			Log.Print(obj.GetRandom());
			Log.Print(obj.GetRandom());
			Log.Print(obj.GetRandom());
			Log.Print(obj.GetRandom());
		}
	}
	public class RandomizedSet
	{
		HashSet<int> set;
		List<int> list;
		Random rand;
		public RandomizedSet()
		{
			set = new();
			rand = new();
		}

		public bool Insert(int val)
		{
			list = null;
			return set.Add(val);
		}

		public bool Remove(int val)
		{
			list = null;
			return set.Remove(val);
		}

		public int GetRandom()
		{
			list ??= set.ToList();
			return list[rand.Next(0, list.Count)];
		}
	}

}