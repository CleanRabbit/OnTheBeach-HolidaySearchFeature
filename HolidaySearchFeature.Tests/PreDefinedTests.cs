using HolidaySearchFeature.DataModels;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace HolidaySearchFeature.Tests
{
	[TestClass]
	public class PreDefinedTests
	{
		[TestInitialize]
		public void Init()
		{
			var reader = new StreamReader("FlightData.json");
			var flightDataAsJson = reader.ReadToEnd();
			TestFlightData = JsonSerializer.Deserialize<List<FlightModel>>(flightDataAsJson, new JsonSerializerOptions { PropertyNameCaseInsensitive=true,});
			reader.Close();

			reader = new StreamReader("HotelData.json");
			var hotelDataAsJson = reader.ReadToEnd();
			TestHotelData = JsonSerializer.Deserialize<List<HotelModel>>(hotelDataAsJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, });
			reader.Close();

		}

		internal IEnumerable<FlightModel>? TestFlightData { get; set; }
		internal IEnumerable<HotelModel>? TestHotelData { get; set; }
		internal const string DateFormat = "yyyy/MM/dd";

		[TestMethod]
		public void Customer1()
		{
			/* 
			 * Departing from: Manchester Airport (MAN)
			 * Traveling to: Malaga Airport (AGP)
			 * Departure Date: 2023/07/01
			 * Duration: 7 nights
			 */
			var searchCriteria = new HolidayCriteria
			{
				DepartingFrom = "MAN",
				TravelingTo = "AGP",
				DepartureDate = System.DateTime.ParseExact("2023/07/01", DateFormat, null),
				Duration = 7
			};


			var holidays = new FindMyHoliday(TestHotelData, TestFlightData).Search(searchCriteria);

			//Expects:
			// * Flight 2 and Hotel 9
			Assert.IsTrue(holidays.First().Flight.Id == 2);
			Assert.IsTrue(holidays.First().Hotel.Id == 9);
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
			var searchCriteria = new HolidayCriteria
			{
				DepartingFrom = "Any London Airport", //TODO: Any London Airport
				TravelingTo = "PMI",
				DepartureDate = System.DateTime.ParseExact("2023/06/15", DateFormat, null),
				Duration = 10
			};
			var holidays = new FindMyHoliday(TestHotelData, TestFlightData).Search(searchCriteria);


			//Expects:
			// * Flight 6 and Hotel 5
			Assert.IsTrue(holidays.First().Flight.Id == 6);
			Assert.IsTrue(holidays.First().Hotel.Id == 5);
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
			var searchCriteria = new HolidayCriteria
			{
				DepartingFrom = "Any Airport", //TODO: Any Airport
				TravelingTo = "LPA",
				DepartureDate = System.DateTime.ParseExact("2022/11/10", DateFormat, null),
				Duration = 14
			};
			var holidays = new FindMyHoliday(TestHotelData, TestFlightData).Search(searchCriteria);


			//Expects:
			// * Flight 7 and Hotel 6
			Assert.IsTrue(holidays.First().Flight.Id == 7);
			Assert.IsTrue(holidays.First().Hotel.Id == 6);
		}

		[TestCleanup]
		public void CleanUp()
		{
			
		}
	}
}