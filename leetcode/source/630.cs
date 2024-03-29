﻿using System;
using System.Collections.Generic;

namespace leetcode.Q630
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();
			Console.WriteLine(solution.ScheduleCourse(Parser.Parse("[[100, 200],[200, 1300],[1000, 1250],[2000, 3200]]")));
			Console.WriteLine(solution.ScheduleCourse(Parser.Parse("[[1,2]]")));
			Console.WriteLine(solution.ScheduleCourse(Parser.Parse("[[3,2],[4,3]]")));
			Console.WriteLine(solution.ScheduleCourse(Parser.Parse("[[1,2],[2,3]]")));
			Console.WriteLine(solution.ScheduleCourse(Parser.Parse("[[7,17],[3,12],[10,20],[9,10],[5,20],[10,19],[4,18]]")));
			Console.WriteLine("The answer should be 3/ 1 /0/ 2/ 4");
		}
	}
	public class Parser
	{
		public static int[][] Parse(string input)
		{
			//[[100,200],[200,1300],[1000,1250],[2000,3200]]
			List<int[]> ret = new List<int[]>();
			input = input.Replace("[", "").Replace("]", "");
			var array = input.Split(',');
			for (int i = 0; i < array.Length; i += 2)
			{
				ret.Add(new int[] { int.Parse(array[i]), int.Parse(array[i + 1]) });
			}
			return ret.ToArray();
		}
	}

	public class Solution
	{
		class Course
		{
			public int duration, lastDay;
			public Course(int duration, int lastDay)
			{
				this.duration = duration;
				this.lastDay = lastDay;
			}
		}

		public int ScheduleCourse(int[][] courses)
		{
			// courses[i] = [durationi, lastDayi]

			List<Course> list_LD = new List<Course>(courses.Length);


			for (int i = 0; i < courses.Length; i++)
			{
				list_LD.Add(new Course(courses[i][0], courses[i][1]));
			}
			list_LD.Sort((a, b) => a.lastDay.CompareTo(b.lastDay));

			// append first course
			PriorityQueue<int, int> queue = new PriorityQueue<int, int>();
			int lastDayNow = 0;

			foreach (var c in list_LD)
			{
					queue.Enqueue(c.duration, -c.duration);
					lastDayNow += c.duration;
				
				if (lastDayNow > c.lastDay)
				{
					lastDayNow -= queue.Peek();
					queue.Dequeue();
				}
			}
			return queue.Count;
		}
	}
}
