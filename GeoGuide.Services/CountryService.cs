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

        public Task<Country> FindByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Country>> GetAllAsync()
        {
            return await _countryDao.GetAllAsync();
        }

        public Task UpdateAsync(string id, Country entity)
        {
            throw new NotImplementedException();
        }
    }
}