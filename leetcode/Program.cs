#define Q820

using System;
using System.Collections.Generic;

#if Q820
using Q820;
#endif

namespace leetcode
{
	class Program
	{
		static void Main(string[] args)
		{
			Solution solution = new Solution();
#if Q820
			Console.WriteLine(solution.MinimumLengthEncoding(new[] { "time", "me", "bell" }));
#endif
		}
	}

}
