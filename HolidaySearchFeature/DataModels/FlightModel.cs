namespace HolidaySearchFeature.DataModels
{
	public class FlightModel
	{
        public int Id { get; set; }
        public string Airline { get; set; } = string.Empty;
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public double Price { get; set; }
        public DateTime Departure_Date { get; set; }
	}
}
