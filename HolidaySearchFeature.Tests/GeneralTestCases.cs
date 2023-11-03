using HolidaySearchFeature.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace HolidaySearchFeature.Tests
{
	[TestClass]
	public class GeneralTestCases : TestClassBase
	{

		[TestMethod]
		public void Case1_GetCheapestHolidayFromManchester()
		{/* 
			 * Departing from: Manchester Airport (MAN)
			 * Traveling to: Any Airport
			 * Departure Date: 2023/07/01
			 * Duration: Any duration
			 */
			var searchCriteria = new HolidayCriteria
			{
				DepartingFrom = "MAN",
				DepartureDate = System.DateTime.ParseExact("2023/07/01", DateFormat, null)
			};


			var holidays = new FindMyHoliday(TestHotelData, TestFlightData).Search(searchCriteria);

			//Expects:
			// * Flight 2 and Hotel 9
			Assert.IsTrue(holidays.First().Flight.Id == 2);
			Assert.IsTrue(holidays.First().Hotel.Id == 9);
		}


		[TestMethod]
		public void Case2_GetFlightsToSpecificHotel()
		{/* 
			 * Departing from: Manchester Airport (MAN)
			 * Traveling to: Any Airport
			 * Departure Date: 2023/07/01
			 * Duration: Any duration
			 */
			var searchCriteria = new HolidayCriteria
			{
				HotelName = "Jumeirah Port Soller",
				DepartureDate = System.DateTime.ParseExact("2023/06/15", DateFormat, null)
			};


			var holidays = new FindMyHoliday(TestHotelData, TestFlightData).Search(searchCriteria);

			//Expects:
			// * Flight 2 and Hotel 9
			Assert.IsTrue(holidays.First().Flight.Id == 6);
			Assert.IsTrue(holidays.First().Hotel.Id == 13);
		}


	}
}
