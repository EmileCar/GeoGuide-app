using GeoGuide.Domain;
using GeoGuide.Repositories;
using GeoGuide.Repositories.Interfaces;
using GeoGuide.Services.Interfaces;

namespace GeoGuide.Services
{
    public class CountryService : IService<Country>
    {
        private readonly IDAO<Country> _countryDao;

        public CountryService(IDAO<Country> countryDao)
        {
            _countryDao = countryDao;
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
            return await _countryDao.FindByIdAsync(id);
        }

        public async Task<List<Country>> GetAllAsync()
        {
            return await _countryDao.GetAllAsync();
        }

		public async Task<int> GetCountAsync()
		{
			return await _countryDao.GetCountAsync();
		}

		public async Task<List<Country>> GetPagedAsync(int skip, int pageSize)
		{
			return await _countryDao.GetPagedAsync(skip, pageSize);
		}

		public Task UpdateAsync(string id, Country entity)
        {
            throw new NotImplementedException();
        }
    }
}