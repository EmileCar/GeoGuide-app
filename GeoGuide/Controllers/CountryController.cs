using GeoGuide.Domain;
using GeoGuide.Models;
using GeoGuide.Services.Interfaces;
using GeoGuide.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace GeoGuide.Controllers
{
	public class CountryController : Controller
	{
		private readonly ILogger<CountryController> _logger;
		private readonly IService<Country> _countryService;
		private readonly IService<Region> _regionService;
		private readonly IService<CoverageType> _coverageTypeService;


		public CountryController(ILogger<CountryController> logger, IService<Country> countryService, IService<Region> regionService, IService<CoverageType> coverageTypeService)
		{
			_logger = logger;
			_countryService = countryService;
			_regionService = regionService;
			_coverageTypeService = coverageTypeService;
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

		[HttpGet]
		public async Task<IActionResult> Edit(string countryCode)
		{

			// Retrieve the country from the database using the countryCode
			var country = await _countryService.FindByIdAsync(countryCode);

			if (country == null)
			{
				return RedirectToAction("Index");
			}

            var regions = await _regionService.GetAllAsync();
			var coverageTypes = await _coverageTypeService.GetAllAsync();

            var countryEditVM = new CountryEditVM()
            {
                Country = country,
                Regions = regions.Select(r => new SelectListItem
                {
                    Value = r.Id,
                    Text = r.Name,
                    Selected = r.Id == country.Region?.Id
                }),
				CoverageTypes = coverageTypes.Select(ct => new SelectListItem
				{
					Value = ct.CoverageId,
					Text = ct.Type,
					Selected = ct.CoverageId.Equals(country.CoverageType?.CoverageId)
				})
            };


            return View(countryEditVM);
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CountryEditVM countryEditVM)
        {
            if (ModelState.IsValid)
            {
				// Assign the selected Region and CoverageType objects to the Country object
				countryEditVM.Country.Region = await _regionService.FindByIdAsync(countryEditVM.SelectedRegion);
                countryEditVM.Country.CoverageType = await _coverageTypeService.FindByIdAsync(countryEditVM.SelectedCoverageType);

                // Update the country in the database with the edited values
                _countryService.UpdateAsync(countryEditVM.Country.CountryCode, countryEditVM.Country);

                // Redirect to the detail page or any other appropriate action
                return RedirectToAction("Detail", new { countryCode = countryEditVM.Country.CountryCode });
            }

            // If the model state is not valid, return the view with the validation errors
            return View(countryEditVM);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
