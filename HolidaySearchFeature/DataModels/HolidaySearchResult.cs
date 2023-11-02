namespace HolidaySearchFeature.DataModels
{
	public class HolidaySearchResult
	{
		public double TotalPrice { get { return Flight.Price + (Hotel.Price_Per_Night * Hotel.Nights); } }
		public FlightModel Flight { get; set; } = new FlightModel();
		public HotelModel Hotel { get; set; } = new HotelModel();

	}
}