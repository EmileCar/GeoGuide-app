using GeoGuide.Domain;
using GeoGuide.ViewModels;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoGuide.Repositories
{
	public  class ApiDAO
	{
		private readonly IMongoClient _mongoClient;
		private readonly IMongoDatabase _database;
		private readonly IMongoCollection<Country> _countryCollection;

		public ApiDAO(IMongoClient mongoClient)
		{
			_mongoClient = mongoClient;
			_database = mongoClient.GetDatabase("geoguideDB");
			_countryCollection = _database.GetCollection<Country>("countries");
		}
		public async Task<List<CountrySearchResult>> GetCountrySearchResultsAsync()
		{
			var countrySearchResults = await _countryCollection.Find(country => true)
				.Project(country => new CountrySearchResult { Name = country.Name, CountryCode = country.CountryCode, Independent = country.Independent, Population = country.Population, Region = country.Region.Id })
				.ToListAsync();
			return countrySearchResults;
		}
	}
}
