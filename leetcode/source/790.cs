using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetcode.Q790
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			Log.Print(solution.NumTilings(30));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		const int mod = (int)1e9 + 7;
		static Dictionary<int, long> D = new(), T = new();
		long GetD(int x)
		{
			if (D.ContainsKey(x))
				return D[x];
			switch (x)
			{
				case < 0:
					return 1;
				case <= 2:
					return x;
				default:
					return D[x] = (GetD(x - 2) + GetD(x - 1) + GetT(x - 1) * 2) % mod;
			}
		}
		long GetT(int x)
		{
			if (T.ContainsKey(x))
				return T[x];

			switch (x)
			{
				case 1:
					return 1;
				case < 2:
					return 0;
				default:
					return T[x] = (GetD(x - 2) + GetT(x - 1)) % mod;
			}
		}
		public int NumTilings(int n)
		{
			return (int)GetD(n);
		}
	}
}