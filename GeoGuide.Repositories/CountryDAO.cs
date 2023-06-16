using GeoGuide.Domain;
using GeoGuide.Repositories.Interfaces;
using MongoDB.Driver;

namespace GeoGuide.Repositories
{
    public class CountryDAO : IDAO<Country>
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Country> _countryCollection;

        public CountryDAO(IMongoClient mongoClient) { 
            _mongoClient= mongoClient;
            _database = mongoClient.GetDatabase("geoguideDB");
            _countryCollection = _database.GetCollection<Country>("countries");
        }
        public Task<Country> AddAsync(Country entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

		public async Task<Country> FindByIdAsync(string id)
		{
			var country = await _countryCollection.Find(country => country.CountryCode == id).FirstOrDefaultAsync();
			return country;
		}


		public async Task<List<Country>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<int> GetCountAsync()
		{
			var count = await _countryCollection.CountDocumentsAsync(Builders<Country>.Filter.Empty);
			return (int)count;
		}

		public async Task<List<Country>> GetPagedAsync(int skip, int pageSize)
		{
			var countries = await _countryCollection.Find(Builders<Country>.Filter.Empty)
				.Skip(skip)
				.Limit(pageSize)
				.ToListAsync();
			return countries;
		}

		public Task UpdateAsync(string id, Country entity)
        {
            throw new NotImplementedException();
        }
    }
}