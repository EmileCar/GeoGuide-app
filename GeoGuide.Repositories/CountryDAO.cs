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

        public async Task UpdateAsync(string id, Country entity)
        {
            // Create a filter to find the country by its ID
            var filter = Builders<Country>.Filter.Eq(c => c.CountryCode, id);

            // Create a list of update definitions to specify the properties to update
            var updateDefinitions = new List<UpdateDefinition<Country>>();

            // Update only the non-null and non-empty properties
            if (!string.IsNullOrEmpty(entity.Name))
            {
                updateDefinitions.Add(Builders<Country>.Update.Set(c => c.Name, entity.Name));
            }

            if (entity.Population != null)
            {
                updateDefinitions.Add(Builders<Country>.Update.Set(c => c.Population, entity.Population));
            }

            if (entity.Area != null)
            {
                updateDefinitions.Add(Builders<Country>.Update.Set(c => c.Area, entity.Area));
            }

            if (entity.Independent != null)
            {
                updateDefinitions.Add(Builders<Country>.Update.Set(c => c.Independent, entity.Independent));
            }

            if (!string.IsNullOrEmpty(entity.Capital))
            {
                updateDefinitions.Add(Builders<Country>.Update.Set(c => c.Capital, entity.Capital));
            }

            if (!string.IsNullOrEmpty(entity.Currency))
            {
                updateDefinitions.Add(Builders<Country>.Update.Set(c => c.Currency, entity.Currency));
            }

            if (entity.DrivingSide != null)
            {
                updateDefinitions.Add(Builders<Country>.Update.Set(c => c.DrivingSide, entity.DrivingSide));
            }

            if (entity.CoverageType != null)
            {
                updateDefinitions.Add(Builders<Country>.Update.Set(c => c.CoverageType, entity.CoverageType));
            }

            if (entity.Region != null)
            {
                updateDefinitions.Add(Builders<Country>.Update.Set(c => c.Region, entity.Region));
            }

            // Create the combined update definition
            var combinedUpdate = Builders<Country>.Update.Combine(updateDefinitions);

            // Execute the update operation
            await _countryCollection.UpdateOneAsync(filter, combinedUpdate);
        }


    }
}