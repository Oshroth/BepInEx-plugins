using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipperHelper
{
	internal class CoinHelper
	{
		public static string FormatCoins(double coins)
		{
			return coins switch
			{
				>= 1E+36f => ((double)coins / 1E+36).ToString("0.##") + " Undecillion",
				>= 1E+33f => ((double)coins / 1E+33).ToString("0.##") + " Decillion",
				>= 1E+30f => ((double)coins / 1E+30).ToString("0.##") + " Nonillion",
				>= 1E+27f => ((double)coins / 1E+27).ToString("0.##") + " Octillion",
				>= 1E+24f => ((double)coins / 1E+24).ToString("0.##") + " Septillion",
				>= 1E+21f => ((double)coins / 1E+21).ToString("0.##") + " Sextillion",
				>= 1E+18f => ((double)coins / 1E+18).ToString("0.##") + " Quintillion",
				>= 1E+15f => ((double)coins / 1E+15).ToString("0.##") + " Quadrillion",
				>= 1E+12f => ((double)coins / 1000000000000.0).ToString("0.##") + " Trillion",
				>= 1E+09f => ((double)coins / 1000000000.0).ToString("0.##") + " Billion",
				>= 1000000f => ((double)coins / 1000000.0).ToString("0.##") + " Million",
				>= 1000f => ((double)coins / 1000.0).ToString("0.##") + " Thousand",
				_ => ((double)coins / 1.0).ToString("##") ?? ""
			};
		}
	}
}
