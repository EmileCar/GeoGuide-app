using GeoGuide.Domain;
using GeoGuide.Services.Interfaces;
using GeoGuide.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GeoGuide.Controllers.API
{
    [Route("api")]
    [ApiController]
    public class ApiController : Controller
    {
        private readonly IService<Country> _countryService;

        public ApiController(IService<Country> countryService)
        {
            _countryService = countryService;
        }
		// GET: api/
		[HttpGet("getAllCountries", Name = "getAllCountries")]
		public async Task<ActionResult<IEnumerable<Country>>> GetAllCountries()
        {
            try
            {
                return await _countryService.GetAllAsync();
            }
            catch (Exception ex)

            {
                return StatusCode(500, "Internal server error");
            }
        }

		[HttpGet("getCountriesByForm", Name = "getCountriesByForm")]
		public async Task<ActionResult<IEnumerable<Country>>> GetCountriesWithForm(CountriesVM countriesVM)
		{
            return View(countriesVM);
		}
	}
}
