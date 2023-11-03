using HolidaySearchFeature.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace HolidaySearchFeature.Tests
{
	[TestClass]
	public class EdgeCases : TestClassBase
	{
		[TestMethod]
		public void Case1_NoHotelMatchingFlight()
		{
			var searchCriteria = new HolidayCriteria
			{
				DepartingFrom = "MAN",
				TravelingTo = "AGP",
				DepartureDate = System.DateTime.ParseExact("2023/04/11", DateFormat, null)
			};


			var holidays = new FindMyHoliday(TestHotelData, TestFlightData).Search(searchCriteria);

			Assert.IsNotNull(holidays);
			Assert.IsTrue(!holidays.Any());
		}

		[TestMethod]
		public void Case2_NoFlightMatchingHotel()
		{
			var searchCriteria = new HolidayCriteria
			{
				HotelName = "Boutique Hotel Cordial La Peregrina",
				DepartureDate = System.DateTime.ParseExact("2022/10/10", DateFormat, null)
			};


			var holidays = new FindMyHoliday(TestHotelData, TestFlightData).Search(searchCriteria);

			Assert.IsNotNull(holidays);
			Assert.IsTrue(!holidays.Any());
		}

		[TestMethod]
		public void Case3_NoMatchesAtAll()
		{
			var searchCriteria = new HolidayCriteria
			{
				TravelingTo = "LAX",
			};


			var holidays = new FindMyHoliday(TestHotelData, TestFlightData).Search(searchCriteria);

			Assert.IsNotNull(holidays);
			Assert.IsTrue(!holidays.Any());
		}
	}
}
