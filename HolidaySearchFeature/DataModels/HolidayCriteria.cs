namespace HolidaySearchFeature.DataModels
{
	public class HolidayCriteria
	{
		public string DepartingFrom { get; set; } = string.Empty;
		public string TravelingTo { get; set; } = string.Empty;
		public DateTime DepartureDate { get; set; }
		public int Duration { get; set; }

	}
}