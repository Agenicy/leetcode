#define Q1423

using System;
using System.Collections.Generic;
#if Q4
using Q4;
#elif Q215
using Q215;
#elif Q630
using Q630;
#elif Q665
using Q665;
#elif Q820
using Q820;
#elif Q1354
using Q1354;
#elif Q1423
using Q1423;
#elif Q1642
using Q1642;
#endif

namespace leetcode
{
	class Program
	{
		static void Main(string[] args)
		{
			Solution solution = new Solution();
#if Q4
			Console.WriteLine(solution.FindMedianSortedArrays(new[] { 1, 3 }, new[] { 2 }));
			Console.WriteLine(solution.FindMedianSortedArrays(new[] { 1, 2 }, new[] { 3, 4 }));
			Console.WriteLine(solution.FindMedianSortedArrays(new int[0] { }, new[] { 1 }));
			Console.WriteLine("The answer should be 2.0/ 2.5/ 1");
#elif Q215
			Console.WriteLine(solution.FindKthLargest(new[] { 3, 2, 1, 5, 6, 4 }, 2));
			Console.WriteLine(solution.FindKthLargest(new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4));
			Console.WriteLine("The answer should be 5/ 4");
			Console.WriteLine(solution.FindKthLargest(new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4));
			Console.WriteLine("The answer should be 4");
#elif Q630
			Console.WriteLine(solution.ScheduleCourse(Parser.Parse("[[100, 200],[200, 1300],[1000, 1250],[2000, 3200]]")));
			Console.WriteLine(solution.ScheduleCourse(Parser.Parse("[[1,2]]")));
			Console.WriteLine(solution.ScheduleCourse(Parser.Parse("[[3,2],[4,3]]")));
			Console.WriteLine(solution.ScheduleCourse(Parser.Parse("[[1,2],[2,3]]")));
			Console.WriteLine(solution.ScheduleCourse(Parser.Parse("[[7,17],[3,12],[10,20],[9,10],[5,20],[10,19],[4,18]]")));
			Console.WriteLine("The answer should be 3/ 1 /0/ 2/ 4");
#elif Q665
			Console.WriteLine(solution.CheckPossibility(Parser.Parse("[4,2,3]")));
			Console.WriteLine(solution.CheckPossibility(Parser.Parse("[4,2,1]")));
			Console.WriteLine(solution.CheckPossibility(Parser.Parse("[3,4,2,3]")));
			Console.WriteLine(solution.CheckPossibility(Parser.Parse("[5, 7, 1, 8]")));
			Console.WriteLine(solution.CheckPossibility(Parser.Parse("[-1, 4, 2, 3]")));
			Console.WriteLine(solution.CheckPossibility(Parser.Parse("[1, 4,1,2]")));
			Console.WriteLine("The answer should be t/ f/ f/ t/ t/ t");
#elif Q820
			Console.WriteLine(solution.MinimumLengthEncoding(new[] { "time", "me", "bell" }));
#elif Q1354

			/*Console.WriteLine(solution.IsPossible(Parser.Parse("[9,3,5]")));
			Console.WriteLine(solution.IsPossible(Parser.Parse("[1,1,1,2]")));
			Console.WriteLine(solution.IsPossible(Parser.Parse("[8,5]")));
			Console.WriteLine(solution.IsPossible(Parser.Parse("[1,1000000000]")));
			Console.WriteLine(solution.IsPossible(Parser.Parse("[2,900000001]")));
			Console.WriteLine(solution.IsPossible(Parser.Parse("[2,900000002]")));*/
			Console.WriteLine(solution.IsPossible(Parser.Parse(
				"[792878242,156371282,184671022,434721674,10020216,195079049," +
				"405142078,538057214,259515787,937089409,511709428,170584077," +
				"354105792,16690191,158708394,305603899,981855547,423743396," +
				"684156584,667243497,56698123,61462768,555034807,37694031,425521212," +
				"836326014,473914560,954574459,561862726,805657520,593882955," +
				"741428824,458433816,522554443,321237652,793677868,530114876," +
				"450056919,420828686,618797583,426188449,959066478,114993410,281950232," +
				"796127065,953882010,719023621,703696454,175566185,496151800,144556644," +
				"17326965,839038444,588300314,375869468,229402189,335424345,931061161," +
				"859996026,43922010,734403367,69675585,681076076,484262638,831658304," +
				"983665917,919971934,379528253,43043574,290639228,248602316,238317921," +
				"372678711,685651238,948500244,103505946,302040365,558944260,562286238," +
				"541849754,105560439,520011547,213593429,773894929,23438215,915587729,671013832," +
				"96445976,331223164,413216764,620095908,13582237,199184171,150208270,851708907," +
				"735661937,382372108,253160866,809746623,596811509,359977357,178151198,894756314," +
				"572314564,956778410,613623914,756186859,561939934,563965475,40274225,111551432," +
				"708359197,310096537,415650010,21850744,851123443,107315025,742401293,691173927," +
				"530442346,83015039,261686918,41029628,183332965,356801892,31361471,281949038," +
				"796101224,428479917,580410275,289589792,789519234,478915248,513555102,151429243," +
				"783767842,251663355,628622122,500125755,202027793,773261588,198449354,207680452," +
				"605696703,51575404,22092619,598218003,873029376,173171739,763578485,446644188,717622642," +
				"450521113,781721677,693716537,145665694,505562328,119296606,367266919,244961305,292518525," +
				"123338915,927486812,178300811,851708774,737323455,222024394,38385992,779145570,2051589," +
				"659496193,599087582,121080547,309248083,144132177,630409101,657368515,721738771,673232473," +
				"259782961,380759309,289857629,355096491,8135206,573797856,827559804,301554509,306036441," +
				"105779547,108219348,83684373,850406669,716203652,408589149,638264758,912551757,298772025," +
				"420623805,169594558,168762355,486149388,354491517,685735993,28502131,839428206,561199720," +
				"970621984,978803120,607905522,271975195,271168215,112006429,652177973,185718391,151964629," +
				"525517436,787455644,119321481,654151373,462583136,685987902,197194560,66071692,271912887," +
				"439005263,213204228,981554531,551298588,101134575,168318902,87678384,573580959,699551461," +
				"487128375,761666283,954871379,394049292,907050432,377653829,192655463,405661577,730014106," +
				"441723705,2438483,717275608,753298231,750301289,209097183,102497571,274737931,954992196," +
				"849729177,819874064,849572649,2223000,398570747,368564407,964258126,38506422,708712954," +
				"680015597,301847512,902409863,800783158,933141020,707010377,485490618,854545369,886343374," +
				"575872856,792712468,759179332,483909693,819525008,974584943,649818387,633699775,277310359," +
				"560014081,677233002,402982006,656297322,911148750,78245259,159387258,452158380,990895549," +
				"230657487,107097175,812876926,109653684,487739647,334240298,983034197,574493858,650104345," +
				"347298537,308873039,682867427,258905821,861721616,469903004,455596568,243123205,859904822," +
				"189999203,674404972,586044570,399722004,200206216,312323036,219885719,745116002,492502389," +
				"67452314,497707477,225440900,949988698,636367879,166852359,196236035,19427727,854598665," +
				"156894853,706501384,590683764,617896370,87536537,622059380,577624569,523987490,936112597," +
				"148000338,21337047,934623205,707760407,140348033,165563119,950952085,929396296,594826521," +
				"269277018,191485017,958783989,114515611,904641724,680145706,427166997,72819826,434762902," +
				"419140747,159588938,347014008,185777438,568372321,493787170,977773677,280401477,450031484," +
				"864875906,875968901,91527892,801552770,604341036,664123503,856509396,167598401,247439177,315157371]")));
			Console.WriteLine("The answer should be t/ f/ t/ t/ t/ t/ f");
#elif Q1423
			Console.WriteLine(solution.MaxScore(Parser.Parse("[1,2,3,4,5,6,1]"), 3));
			Console.WriteLine(solution.MaxScore(Parser.Parse("[2,2,2]"), 2));
			Console.WriteLine(solution.MaxScore(Parser.Parse("[9,7,7,9,7,7,9]"), 7));
			Console.WriteLine(solution.MaxScore(Parser.Parse("[100, 40, 17, 9, 73, 75]"), 3));
			Console.WriteLine("The answer should be 12/ 4/ 55/ 248");
#elif Q1642
			Console.WriteLine(solution.FurthestBuilding(new[] { 4, 2, 7, 6, 9, 14, 12 }, 5, 1));
			Console.WriteLine(solution.FurthestBuilding(new[] { 4, 12, 2, 7, 3, 18, 20, 3, 19 }, 10, 2));
			Console.WriteLine(solution.FurthestBuilding(new[] { 14, 3, 19, 3 }, 17, 0));
			Console.WriteLine(solution.FurthestBuilding(new[] { 2, 7, 9, 12}, 5, 1));
			Console.WriteLine(solution.FurthestBuilding(new[] { 1, 13, 1, 1, 13, 5, 11, 11 }, 10, 8));
			Console.WriteLine("The answer should be 4/ 7/ 3/ 3/ 7");

			
			string[] lines = System.IO.File.ReadAllLines("../../../testcase/1642/testcase1.txt");
			List<int> vs = new List<int>();
			foreach (var item in lines[0].Split(','))
			{
				vs.Add(int.Parse(item));
			}
			Console.WriteLine(solution.FurthestBuilding(vs.ToArray(), int.Parse(lines[1]), int.Parse(lines[2])));
			Console.WriteLine("The answer should be 72329");

			lines = System.IO.File.ReadAllLines("../../../testcase/1642/testcase2.txt");
			vs = new List<int>();
			foreach (var item in lines[0].Split(','))
			{
				vs.Add(int.Parse(item));
			}
			Console.WriteLine(solution.FurthestBuilding(vs.ToArray(), int.Parse(lines[1]), int.Parse(lines[2])));
			Console.WriteLine("The answer should be 589");
#endif
		}
	}

}
