using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HolidaySearchFeature.Tests
{
	[TestClass]
	public class PreDefinedTests
	{
		[TestMethod]
		public void Customer1()
		{
			/* 
			 * Departing from: Manchester Airport (MAN)
			 * Traveling to: Malaga Airport (AGP)
			 * Departure Date: 2023/07/01
			 * Duration: 7 nights
			 */


			//Expects:
			// * Flight 2 and Hotel 9
		}

		[TestMethod]
		public void Customer2()
		{
			/* 
			 * Departing from: Any London Airport
			 * Traveling to: Mallorca Airport (PMI)
			 * Departure Date: 2023/06/15
			 * Duration: 10 nights
			 */


			//Expects:
			// * Flight 6 and Hotel 5
		}

		[TestMethod]
		public void Customer3()
		{
			/* 
			 * Departing from: Any Airport
			 * Traveling to: Gran Canaria Airport (LPA)
			 * Departure Date: 2022/11/10
			 * Duration: 14 nights
			 */


			//Expects:
			// * Flight 7 and Hotel 6
		}
	}
}