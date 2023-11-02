using HolidaySearchFeature.DataModels;

namespace HolidaySearchFeature
{
	public class FindMyHoliday
	{
		public FindMyHoliday(IEnumerable<HotelModel> hotels, IEnumerable<FlightModel> flights)
		{
			Hotels = hotels;
			Flights = flights;
		}

		private IEnumerable<HotelModel> Hotels { get; }
		private IEnumerable<FlightModel> Flights { get; }

		public IEnumerable<HolidaySearchResult> Search(HolidayCriteria criteria)
		{
			throw new NotImplementedException();
		}
	}
}
