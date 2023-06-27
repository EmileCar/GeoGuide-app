using GeoGuide.Domain;
using GeoGuide.Models;
using GeoGuide.Services.Interfaces;
using GeoGuide.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GeoGuide.Controllers
{
	public class CountryController : Controller
	{
		private readonly ILogger<CountryController> _logger;
		private readonly IService<Country> _countryService;
		private readonly IService<Region> _regionService;


		public CountryController(ILogger<CountryController> logger, IService<Country> countryService, IService<Region> regionService)
		{
			_logger = logger;
			_countryService = countryService;
			_regionService = regionService;
		}

		public async Task<IActionResult> Index()
		{
			var countrySearchVM = new CountrySearchVM();
			countrySearchVM.Regions = await _regionService.GetAllAsync();
			return View(countrySearchVM);
		}

		public async Task<IActionResult> Detail(string countryCode)
		{
			var country = await _countryService.FindByIdAsync(countryCode);

			if (country == null)
			{
				return NotFound();
			}

			return View(country);
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
