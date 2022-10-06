using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace leetcode.Q981
{
	public class Program
	{
		public static void Run()
		{
			TimeMap solution = new TimeMap();

			TimeMap timeMap = new TimeMap();
			timeMap.Set("a", "bar", 1);
			timeMap.Set("x", "b", 3);
			Log.Print(timeMap.Get("b", 3));
			timeMap.Set("foo", "bar2", 4);
		}
	}

	public class TimeMap
	{
		Dictionary<string, SortedList<int, string>> map = new();


		public TimeMap()
		{

		}

		public void Set(string key, string value, int timestamp)
		{
			if (!map.ContainsKey(key))
				map[key] = new();

			map[key].Add(timestamp, value);
		}

		public string Get(string key, int timestamp)
		{
			if (map.ContainsKey(key))
			{
				var sl = map[key];
				int QS(int timestamp, int start, int end)
				{
					int mid = (start + end) / 2;
					if (sl.Keys[mid] == timestamp)
						return sl.Keys[mid];
					else if (start + 1 == end)
						return sl.Keys[start];
					else if (sl.Keys[mid] < timestamp)
						return QS(timestamp, mid, end);
					else
						return QS(timestamp, start, mid);
				}
				int st = QS(timestamp, 0, sl.Keys.Count);
				if (st <= timestamp)
					return map[key][st];
			}
			return "";
		}
	}
}