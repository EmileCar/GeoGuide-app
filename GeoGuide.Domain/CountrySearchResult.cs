namespace GeoGuide.ViewModels
{
	public class CountrySearchResult
	{
		public string CountryCode { get; set; } = string.Empty;
		public string Name { get; set; }
		public string Region { get; set; }
		public bool? Independent { get; set; }

		public int? Population { get; set; }

	}
}
