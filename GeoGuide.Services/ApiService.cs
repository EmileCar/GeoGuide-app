using GeoGuide.Domain;
using GeoGuide.Repositories;
using GeoGuide.Repositories.Interfaces;
using GeoGuide.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoGuide.Services
{
	public class ApiService
	{
		private readonly ApiDAO _apiDAO;

		public ApiService(ApiDAO apiDAO)
		{
			_apiDAO = apiDAO;
		}

		public async Task<List<CountrySearchResult>> GetCountrySearchResultsAsync()
		{
			return await _apiDAO.GetCountrySearchResultsAsync();
		}
	}
}
