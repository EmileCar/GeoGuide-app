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

        public Task<Country> FindByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Country>> GetAllAsync()
        {
            return await _countryCollection.Find(country => true).ToListAsync();
        }

        public Task UpdateAsync(string id, Country entity)
        {
            throw new NotImplementedException();
        }
    }
}