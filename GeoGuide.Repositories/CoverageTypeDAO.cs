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
    public class CoverageTypeDAO : IDAO<CoverageType>
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<CoverageType> _coverageTypeCollection;

        public CoverageTypeDAO(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
            _database = mongoClient.GetDatabase("geoguideDB");
            _coverageTypeCollection = _database.GetCollection<CoverageType>("coverageTypes");
        }
        public Task<CoverageType> AddAsync(CoverageType entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<CoverageType> FindByIdAsync(string id)
        {
            var coverageType = await _coverageTypeCollection.Find(coverage => coverage.CoverageId == id).FirstOrDefaultAsync();
            return coverageType;
        }

        public async Task<List<CoverageType>> GetAllAsync()
        {
            var coverageTypes = await _coverageTypeCollection.Find(region => true).ToListAsync();
            return coverageTypes;
        }

        public Task<int> GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<CoverageType>> GetPagedAsync(int skip, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(string id, CoverageType entity)
        {
            throw new NotImplementedException();
        }
    }
}
