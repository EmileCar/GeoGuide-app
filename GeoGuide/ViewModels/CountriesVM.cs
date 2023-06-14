using GeoGuide.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GeoGuide.ViewModels
{
	public class CountriesVM
	{
		[Required]
		public List<Country> Countries { get; set; }
		public string Keyword { get; set; } = string.Empty;
		public int CurrentPage { get; set; }
		public int TotalPages { get; set; }
		public int PageSize { get; set; }
		public bool Filtered { get; set; }
	}
}
