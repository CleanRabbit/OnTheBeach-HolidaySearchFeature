namespace HolidaySearchFeature.DataModels
{
    public class HotelModel
	{
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Arrival_Date { get; set; }
        public double Price_Per_Night { get; set; }
        public int Nights { get; set; }
        public String[] Local_Airports { get; set; } = Array.Empty<string>();
    }
}