using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode.Q126
{
	public class Program
	{
		public static void Run()
		{
			Solution solution = new Solution();

			//Log.Print(solution.FindLadders("aaaaa", "ggggg", new[] { "aaaaa", "caaaa", "cbaaa", "daaaa", "dbaaa", "eaaaa", "ebaaa", "faaaa", "fbaaa", "gaaaa", "gbaaa", "haaaa", "hbaaa", "iaaaa", "ibaaa", "jaaaa", "jbaaa", "kaaaa", "kbaaa", "laaaa", "lbaaa", "maaaa", "mbaaa", "naaaa", "nbaaa", "oaaaa", "obaaa", "paaaa", "pbaaa", "bbaaa", "bbcaa", "bbcba", "bbdaa", "bbdba", "bbeaa", "bbeba", "bbfaa", "bbfba", "bbgaa", "bbgba", "bbhaa", "bbhba", "bbiaa", "bbiba", "bbjaa", "bbjba", "bbkaa", "bbkba", "bblaa", "bblba", "bbmaa", "bbmba", "bbnaa", "bbnba", "bboaa", "bboba", "bbpaa", "bbpba", "bbbba", "abbba", "acbba", "dbbba", "dcbba", "ebbba", "ecbba", "fbbba", "fcbba", "gbbba", "gcbba", "hbbba", "hcbba", "ibbba", "icbba", "jbbba", "jcbba", "kbbba", "kcbba", "lbbba", "lcbba", "mbbba", "mcbba", "nbbba", "ncbba", "obbba", "ocbba", "pbbba", "pcbba", "ccbba", "ccaba", "ccaca", "ccdba", "ccdca", "cceba", "cceca", "ccfba", "ccfca", "ccgba", "ccgca", "cchba", "cchca", "cciba", "ccica", "ccjba", "ccjca", "cckba", "cckca", "cclba", "cclca", "ccmba", "ccmca", "ccnba", "ccnca", "ccoba", "ccoca", "ccpba", "ccpca", "cccca", "accca", "adcca", "bccca", "bdcca", "eccca", "edcca", "fccca", "fdcca", "gccca", "gdcca", "hccca", "hdcca", "iccca", "idcca", "jccca", "jdcca", "kccca", "kdcca", "lccca", "ldcca", "mccca", "mdcca", "nccca", "ndcca", "occca", "odcca", "pccca", "pdcca", "ddcca", "ddaca", "ddada", "ddbca", "ddbda", "ddeca", "ddeda", "ddfca", "ddfda", "ddgca", "ddgda", "ddhca", "ddhda", "ddica", "ddida", "ddjca", "ddjda", "ddkca", "ddkda", "ddlca", "ddlda", "ddmca", "ddmda", "ddnca", "ddnda", "ddoca", "ddoda", "ddpca", "ddpda", "dddda", "addda", "aedda", "bddda", "bedda", "cddda", "cedda", "fddda", "fedda", "gddda", "gedda", "hddda", "hedda", "iddda", "iedda", "jddda", "jedda", "kddda", "kedda", "lddda", "ledda", "mddda", "medda", "nddda", "nedda", "oddda", "oedda", "pddda", "pedda", "eedda", "eeada", "eeaea", "eebda", "eebea", "eecda", "eecea", "eefda", "eefea", "eegda", "eegea", "eehda", "eehea", "eeida", "eeiea", "eejda", "eejea", "eekda", "eekea", "eelda", "eelea", "eemda", "eemea", "eenda", "eenea", "eeoda", "eeoea", "eepda", "eepea", "eeeea", "ggggg", "agggg", "ahggg", "bgggg", "bhggg", "cgggg", "chggg", "dgggg", "dhggg", "egggg", "ehggg", "fgggg", "fhggg", "igggg", "ihggg", "jgggg", "jhggg", "kgggg", "khggg", "lgggg", "lhggg", "mgggg", "mhggg", "ngggg", "nhggg", "ogggg", "ohggg", "pgggg", "phggg", "hhggg", "hhagg", "hhahg", "hhbgg", "hhbhg", "hhcgg", "hhchg", "hhdgg", "hhdhg", "hhegg", "hhehg", "hhfgg", "hhfhg", "hhigg", "hhihg", "hhjgg", "hhjhg", "hhkgg", "hhkhg", "hhlgg", "hhlhg", "hhmgg", "hhmhg", "hhngg", "hhnhg", "hhogg", "hhohg", "hhpgg", "hhphg", "hhhhg", "ahhhg", "aihhg", "bhhhg", "bihhg", "chhhg", "cihhg", "dhhhg", "dihhg", "ehhhg", "eihhg", "fhhhg", "fihhg", "ghhhg", "gihhg", "jhhhg", "jihhg", "khhhg", "kihhg", "lhhhg", "lihhg", "mhhhg", "mihhg", "nhhhg", "nihhg", "ohhhg", "oihhg", "phhhg", "pihhg", "iihhg", "iiahg", "iiaig", "iibhg", "iibig", "iichg", "iicig", "iidhg", "iidig", "iiehg", "iieig", "iifhg", "iifig", "iighg", "iigig", "iijhg", "iijig", "iikhg", "iikig", "iilhg", "iilig", "iimhg", "iimig", "iinhg", "iinig", "iiohg", "iioig", "iiphg", "iipig", "iiiig", "aiiig", "ajiig", "biiig", "bjiig", "ciiig", "cjiig", "diiig", "djiig", "eiiig", "ejiig", "fiiig", "fjiig", "giiig", "gjiig", "hiiig", "hjiig", "kiiig", "kjiig", "liiig", "ljiig", "miiig", "mjiig", "niiig", "njiig", "oiiig", "ojiig", "piiig", "pjiig", "jjiig", "jjaig", "jjajg", "jjbig", "jjbjg", "jjcig", "jjcjg", "jjdig", "jjdjg", "jjeig", "jjejg", "jjfig", "jjfjg", "jjgig", "jjgjg", "jjhig", "jjhjg", "jjkig", "jjkjg", "jjlig", "jjljg", "jjmig", "jjmjg", "jjnig", "jjnjg", "jjoig", "jjojg", "jjpig", "jjpjg", "jjjjg", "ajjjg", "akjjg", "bjjjg", "bkjjg", "cjjjg", "ckjjg", "djjjg", "dkjjg", "ejjjg", "ekjjg", "fjjjg", "fkjjg", "gjjjg", "gkjjg", "hjjjg", "hkjjg", "ijjjg", "ikjjg", "ljjjg", "lkjjg", "mjjjg", "mkjjg", "njjjg", "nkjjg", "ojjjg", "okjjg", "pjjjg", "pkjjg", "kkjjg", "kkajg", "kkakg", "kkbjg", "kkbkg", "kkcjg", "kkckg", "kkdjg", "kkdkg", "kkejg", "kkekg", "kkfjg", "kkfkg", "kkgjg", "kkgkg", "kkhjg", "kkhkg", "kkijg", "kkikg", "kkljg", "kklkg", "kkmjg", "kkmkg", "kknjg", "kknkg", "kkojg", "kkokg", "kkpjg", "kkpkg", "kkkkg", "ggggx", "gggxx", "ggxxx", "gxxxx", "xxxxx", "xxxxy", "xxxyy", "xxyyy", "xyyyy", "yyyyy", "yyyyw", "yyyww", "yywww", "ywwww", "wwwww", "wwvww", "wvvww", "vvvww", "vvvwz", "avvwz", "aavwz", "aaawz", "aaaaz" }));

			Log.Print(solution.FindLadders("magic", "pearl", new[] { "flail", "halon", "lexus", "joint", "pears", "slabs", "lorie", "lapse", "wroth", "yalow", "swear", "cavil", "piety", "yogis", "dhaka", "laxer", "tatum", "provo", "truss", "tends", "deana", "dried", "hutch", "basho", "flyby", "miler", "fries", "floes", "lingo", "wider", "scary", "marks", "perry", "igloo", "melts", "lanny", "satan", "foamy", "perks", "denim", "plugs", "cloak", "cyril", "women", "issue", "rocky", "marry", "trash", "merry", "topic", "hicks", "dicky", "prado", "casio", "lapel", "diane", "serer", "paige", "parry", "elope", "balds", "dated", "copra", "earth", "marty", "slake", "balms", "daryl", "loves", "civet", "sweat", "daley", "touch", "maria", "dacca", "muggy", "chore", "felix", "ogled", "acids", "terse", "cults", "darla", "snubs", "boats", "recta", "cohan", "purse", "joist", "grosz", "sheri", "steam", "manic", "luisa", "gluts", "spits", "boxer", "abner", "cooke", "scowl", "kenya", "hasps", "roger", "edwin", "black", "terns", "folks", "demur", "dingo", "party", "brian", "numbs", "forgo", "gunny", "waled", "bucks", "titan", "ruffs", "pizza", "ravel", "poole", "suits", "stoic", "segre", "white", "lemur", "belts", "scums", "parks", "gusts", "ozark", "umped", "heard", "lorna", "emile", "orbit", "onset", "cruet", "amiss", "fumed", "gelds", "italy", "rakes", "loxed", "kilts", "mania", "tombs", "gaped", "merge", "molar", "smith", "tangs", "misty", "wefts", "yawns", "smile", "scuff", "width", "paris", "coded", "sodom", "shits", "benny", "pudgy", "mayer", "peary", "curve", "tulsa", "ramos", "thick", "dogie", "gourd", "strop", "ahmad", "clove", "tract", "calyx", "maris", "wants", "lipid", "pearl", "maybe", "banjo", "south", "blend", "diana", "lanai", "waged", "shari", "magic", "duchy", "decca", "wried", "maine", "nutty", "turns", "satyr", "holds", "finks", "twits", "peaks", "teems", "peace", "melon", "czars", "robby", "tabby", "shove", "minty", "marta", "dregs", "lacks", "casts", "aruba", "stall", "nurse", "jewry", "knuth" }));
			Log.Print(solution.FindLadders("red", "tax", new[] { "ted", "tex", "red", "tax", "tad", "den", "rex", "pee" }));
			Log.Print(solution.FindLadders("a", "c", new[] { "a", "b", "c" }));
			Log.Print(solution.FindLadders("hot", "dog", new[] { "hot", "cog", "dog", "tot", "hog", "hop", "pot", "dot" }));
			Log.Print(solution.FindLadders("hit", "cog", new[] { "hot", "dot", "dog", "lot", "log", "cog" }));
			Log.Print(solution.FindLadders("hit", "cog", new[] { "hot", "dot", "dog", "lot", "log" }));
			Log.Print("The answer should be ");
		}
	}
	public class Solution
	{
		public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
		{
			if (!wordList.Contains(endWord)) return (IList<IList<string>>)new List<IList<string>>();

			List<IList<string>> ret = new();

			bool Check(string a, string b) => Enumerable.Range(0, a.Length).Sum((x) => a[x] == b[x] ? 0 : 1) == 1;

			Dictionary<string, List<List<string>>> path_Front = new();
			path_Front[beginWord] = new() { new List<string>() { beginWord } };

			Dictionary<string, List<List<string>>> path_Back = new();
			path_Back[endWord] = new() { new List<string>() { endWord } };

			wordList = new List<string>(wordList);
			bool isEnd;
			while (true)
			{

				// front go one step
				Dictionary<string, List<List<string>>> nextPathFront = new();
				foreach (var key in path_Front.Keys)
					wordList.Remove(key);
				foreach (var key in path_Front.Keys)
				{
					foreach (var w in wordList)
					{
						if (Check(key, w))
						{
							foreach (var old in path_Front[key])
							{
								List<string> next = new(old);
								next.Add(w);
								if (nextPathFront.ContainsKey(w))
									nextPathFront[w].Add(next);
								else
									nextPathFront[w] = new() { next };
							}
						}
					}
				}
				if (nextPathFront.Count > 0)
					path_Front = nextPathFront;


				// check
				isEnd = false;
				foreach (var used in path_Front.Keys)
				{
					if (path_Back.ContainsKey(used))
					{
						isEnd = true;
						var t = path_Front[used];
						foreach (var list_front in t)
						{
							foreach (var list_back in path_Back[used])
							{
								var temp = new List<string>(list_front);
								for (int i = list_back.Count - 2; i >= 0; i--)
								{
									temp.Add(list_back[i]);
								}
								ret.Add(temp);
							}
						}
					}
				}
				if (isEnd)
					return (IList<IList<string>>)ret;
				// check end


				// back go one step
				Dictionary<string, List<List<string>>> nextPathBack = new();
				foreach (var key in path_Back.Keys)
					wordList.Remove(key);
				foreach (var key in path_Back.Keys)
				{
					foreach (var w in wordList)
					{
						if (Check(key, w))
						{
							foreach (var old in path_Back[key])
							{
								List<string> next = new(old);
								next.Add(w);
								if (nextPathBack.ContainsKey(w))
									nextPathBack[w].Add(next);
								else
									nextPathBack[w] = new() { next };
							}
						}
					}
				}
				if (nextPathFront.Count > 0)
					path_Back = nextPathBack;

				// check
				isEnd = false;
				foreach (var used in path_Front.Keys)
				{
					if (path_Back.ContainsKey(used))
					{
						isEnd = true;
						var t = path_Front[used];
						foreach (var list_front in t)
						{
							foreach (var list_back in path_Back[used])
							{
								var temp = new List<string>(list_front);
								for (int i = list_back.Count - 2; i >= 0; i--)
								{
									temp.Add(list_back[i]);
								}
								ret.Add(temp);
							}
						}
					}
				}
				if (isEnd)
					return (IList<IList<string>>)ret;
				// check end

				if (nextPathFront.Count == 0 && nextPathFront.Count == 0)
					return (IList<IList<string>>)new List<IList<string>>();

			}
		}
	}
}