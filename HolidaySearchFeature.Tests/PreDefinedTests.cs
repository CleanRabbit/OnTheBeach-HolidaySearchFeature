using HolidaySearchFeature.DataModels;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
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

		internal List<FlightModel>? TestFlightData { get; set; }
		internal List<HotelModel>? TestHotelData { get; set; }

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

		[TestCleanup]
		public void CleanUp()
		{
			
		}
	}
}