using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace leetcode.Q732
{
	public class Program
	{
		public static void Run()
		{
			MyCalendarThree myCalendarThree = new MyCalendarThree();
			Log.Print(myCalendarThree.Book(10, 20)); // return 1, The first event can be booked and is disjoint, so the maximum k-booking is a 1-booking.
			Log.Print(myCalendarThree.Book(50, 60)); // return 1, The second event can be booked and is disjoint, so the maximum k-booking is a 1-booking.
			Log.Print(myCalendarThree.Book(10, 40)); // return 2, The third event [10, 40) intersects the first event, and the maximum k-booking is a 2-booking.
			Log.Print(myCalendarThree.Book(5, 15)); // return 3, The remaining events cause the maximum K-booking to be only a 3-booking.
			Log.Print(myCalendarThree.Book(5, 10)); // return 3
			Log.Print(myCalendarThree.Book(25, 55)); // return 3
		}
	}


	public class MyCalendarThree
	{
		SortedList<int, int> starts = new();
		int res = 0;

		public MyCalendarThree()
		{
			starts.Add(0, 0);
		}

		public int Book(int start, int end)
		{
			int[] spl = new[] { start, end };
			int[] ind = new int[2];
			for (int x = 0; x < 2; x++)
			{
				for (int i = 0; i < starts.Count; i++)
				{
					if (starts.Keys[i] == spl[x])
					{
						ind[x] = i;
						break;
					}
					if (starts.Keys[i] > spl[x])
					{
						ind[x] = i;
						starts.Add(spl[x], starts.Values[i - 1]);
						break;
					}
					if (i == starts.Count-1)
					{
						starts.Add(spl[x], 0);
						ind[x] = starts.Count - 1;
					}
				}
			}

			for (int i = ind[0]; i < ind[1]; i++)
			{
				res = Math.Max(res, ++starts[starts.Keys[i]]);
			}
			return res;
		}
	}
}