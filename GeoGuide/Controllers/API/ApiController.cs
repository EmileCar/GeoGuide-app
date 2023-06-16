using GeoGuide.Domain;
using GeoGuide.Services;
using GeoGuide.Services.Interfaces;
using GeoGuide.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GeoGuide.Controllers.API
{
    [Route("api")]
    [ApiController]
    public class ApiController : Controller
    {
        private readonly ApiService _apiService;

        public ApiController(ApiService apiService)
        {
			_apiService = apiService;
        }
		// GET: api/
		[HttpGet("getAllCountries", Name = "getAllCountries")]
		public async Task<ActionResult<IEnumerable<CountrySearchResult>>> GetAllCountries()
        {
            try
            {
                return await _apiService.GetCountrySearchResultsAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

		[HttpGet("getCountriesByForm", Name = "getCountriesByForm")]
		public async Task<ActionResult<IEnumerable<Country>>> GetCountriesWithForm(CountrySearchVM countriesVM)
		{
            return View(countriesVM);
		}
	}
}
