using GeoGuide.Domain;
using GeoGuide.Repositories.Interfaces;
using GeoGuide.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoGuide.Services
{
    public class CoverageTypeService : IService<CoverageType>
    {
        private readonly IDAO<CoverageType> _coverageTypeDAO;

        public CoverageTypeService(IDAO<CoverageType> coverageTypeDAO)
        {
            _coverageTypeDAO = coverageTypeDAO;
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
            return await _coverageTypeDAO.FindByIdAsync(id);
        }

        public async Task<List<CoverageType>> GetAllAsync()
        {
            return await _coverageTypeDAO.GetAllAsync();
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
