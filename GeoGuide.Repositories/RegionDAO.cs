using GeoGuide.Domain;
using GeoGuide.Repositories.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoGuide.Repositories
{
	public class RegionDAO : IDAO<Region>
	{
		private readonly IMongoClient _mongoClient;
		private readonly IMongoDatabase _database;
		private readonly IMongoCollection<Region> _regionCollection;

		public RegionDAO(IMongoClient mongoClient)
		{
			_mongoClient = mongoClient;
			_database = mongoClient.GetDatabase("geoguideDB");
			_regionCollection = _database.GetCollection<Region>("regions");
		}

		public Task<Region> AddAsync(Region entity)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(string id)
		{
			throw new NotImplementedException();
		}

		public async Task<Region> FindByIdAsync(string id)
		{
            var region = await _regionCollection.Find(region => region.Id == id).FirstOrDefaultAsync();
            return region;
        }

		public async Task<List<Region>> GetAllAsync()
		{
			var regions = await _regionCollection.Find(region => true).ToListAsync();
			return regions;
		}

		public Task<int> GetCountAsync()
		{
			throw new NotImplementedException();
		}

		public Task<List<Region>> GetPagedAsync(int skip, int pageSize)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(string id, Region entity)
		{
			throw new NotImplementedException();
		}
	}
}
