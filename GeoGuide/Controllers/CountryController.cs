using GeoGuide.Domain;
using GeoGuide.Models;
using GeoGuide.Services.Interfaces;
using GeoGuide.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace GeoGuide.Controllers
{
	public class CountryController : Controller
	{
		private readonly ILogger<CountryController> _logger;
		private readonly IService<Country> _countryService;

		public CountryController(ILogger<CountryController> logger, IService<Country> countryService)
		{
			_logger = logger;
			_countryService = countryService;
		}

		public async Task<IActionResult> Index(int pagenumber = 1)
		{
			try
			{
				_logger.LogInformation("Fetching all the Countries from the storage");

				int totalCountriesCount = await _countryService.GetCountAsync();

				int pageSize = 25; 
				int totalPages = (int)Math.Ceiling((double)totalCountriesCount / pageSize);
				int skip = (pagenumber - 1) * pageSize;

				var countries = await _countryService.GetPagedAsync(skip, pageSize);

				var countriesVM = new CountriesVM
				{
					Countries = countries,
					CurrentPage = pagenumber,
					PageSize= pageSize,
					TotalPages = totalPages
				};
				return View(countriesVM);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong: {ex}");
				return NotFound();
			}
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
