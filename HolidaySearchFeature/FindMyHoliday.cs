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
			//We're matching each criteria item relevant to the hotel selection, and assuming it's a match if nothing was specified
			var hotelsMatchingCriteria = Hotels
				.Where(h => !string.IsNullOrWhiteSpace(criteria.HotelName) ? h.Name.Equals(criteria.HotelName) : true)
				.Where(h => !string.IsNullOrWhiteSpace(criteria.TravelingTo) ? h.Local_Airports.Contains(criteria.TravelingTo) : true)
				.Where(h => criteria.DepartureDate != null ? h.Arrival_Date == criteria.DepartureDate : true)
				.Where(h => criteria.Duration != 0? h.Nights == criteria.Duration : true);

			//We're matching each criteria item relevant to the flight selection, and assuming it's a match if nothing was specified
			var flightsMatchingCriteria = Flights
				.Where(f => !string.IsNullOrWhiteSpace(criteria.DepartingFrom) ? f.From.Equals(criteria.DepartingFrom) : true)
				.Where(f => !string.IsNullOrWhiteSpace(criteria.TravelingTo) ? f.To.Equals(criteria.TravelingTo) : true)
				.Where(f => criteria.DepartureDate != null ? f.Departure_Date == criteria.DepartureDate : true);

			//We've now got a list of hotels and flights that match the given criteria.
			//Problem here is we don't truly know if we were given an open list of flights or an open list of hotels (or worse, both)
			//So we need to link flights to hotels and narrow down the list to only those viable
			//Let's link the hotels list by local airports to the flight destinations. That should narrow it down

			var query = hotelsMatchingCriteria
				.Select(h => flightsMatchingCriteria
					.Where(f => h.Local_Airports.Contains(f.To))
					.Where(f => h.Arrival_Date == f.Departure_Date)
					.Select(f => new HolidaySearchResult { Hotel = h, Flight = f }))
				.SelectMany(r => r)
				.OrderBy(r => r.TotalPrice);

			return query;
		}
	}
}
