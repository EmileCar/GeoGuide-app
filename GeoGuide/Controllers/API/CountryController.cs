using GeoGuide.Domain;
using GeoGuide.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeoGuide.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly IService<Country> _countryService;

        public CountryController(IService<Country> countryService)
        {
            _countryService = countryService;
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetAsync()
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
    }
}
