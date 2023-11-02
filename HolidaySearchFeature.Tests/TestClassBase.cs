using HolidaySearchFeature.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace HolidaySearchFeature.Tests
{
	public class TestClassBase
	{

		[TestInitialize]
		public void Init()
		{
			var reader = new StreamReader("FlightData.json");
			var flightDataAsJson = reader.ReadToEnd();
			TestFlightData = JsonSerializer.Deserialize<List<FlightModel>>(flightDataAsJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, });
			reader.Close();

			reader = new StreamReader("HotelData.json");
			var hotelDataAsJson = reader.ReadToEnd();
			TestHotelData = JsonSerializer.Deserialize<List<HotelModel>>(hotelDataAsJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, });
			reader.Close();

		}

		internal IEnumerable<FlightModel>? TestFlightData { get; set; }
		internal IEnumerable<HotelModel>? TestHotelData { get; set; }
		internal const string DateFormat = "yyyy/MM/dd";

	}
}
