using GeoGuide.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GeoGuide.ViewModels
{
	public class CountryEditVM
	{
		public Country Country { get; set; }
		public IEnumerable<SelectListItem>? Regions { get; set; }
		public IEnumerable<SelectListItem>? CoverageTypes { get; set; }


        // New properties for selected Region and CoverageType
        public string? SelectedRegion { get; set; }
        public string? SelectedCoverageType { get; set; }
    }
}
