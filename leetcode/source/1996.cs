using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q1996
{
    public class Program
    {
        public static void Run()
        {
            Solution solution = new Solution();

            Log.Print(solution.NumberOfWeakCharacters(Parser.ParseArr2D("[[1,1],[2,1],[2,2],[1,2]]")));
            Log.Print(solution.NumberOfWeakCharacters(Parser.ParseArr2D("[[5,5],[6,3],[3,6]]")));
            Log.Print(solution.NumberOfWeakCharacters(Parser.ParseArr2D("[[2,2],[3,3]]")));
            Log.Print(solution.NumberOfWeakCharacters(Parser.ParseArr2D("[[1,5],[10,4],[4,3]]")));
            Log.Print("The answer should be 0/ 1/ 1 ");
        }
    }
    public class Solution
    {
        public int NumberOfWeakCharacters(int[][] properties)
        {
            /*
            SortedList<int, List<int>> list = new();
            for (int i = 0; i < properties.Length; i++)
            {
                if (list.ContainsKey(-properties[i][0]))
                    list[-properties[i][0]].Add(properties[i][1]);
                else
                    list.Add(-properties[i][0], new() { properties[i][1] });
            }

            int max = int.MinValue;
            int count = 0;
            for (int i = 0; i < list.Values.Count; i++)
            {
                int new_max = max;
                foreach (var item in list.Values[i])
                {
                    if (max > item)
                        ++count;
                    new_max =  Math.Max(item, new_max);
                }

                max = new_max;
            }
            return count;*/

            var list = properties.OrderByDescending(p => p[0]).ThenBy(p => p[1]).ToList();
            int max = int.MinValue;
            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (max > list[i][1])
                    ++count;
                max = Math.Max(max, list[i][1]);
            }
            return count;
        }
    }
}