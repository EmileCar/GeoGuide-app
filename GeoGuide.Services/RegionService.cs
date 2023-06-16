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
	public class RegionService : IService<Region>
	{
		private readonly IDAO<Region> _regionDAO;

		public RegionService(IDAO<Region> regionDAO)
		{
			_regionDAO = regionDAO;
		}
		public Task<Region> AddAsync(Region entity)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(string id)
		{
			throw new NotImplementedException();
		}

		public Task<Region> FindByIdAsync(string id)
		{
			throw new NotImplementedException();
		}

		public async Task<List<Region>> GetAllAsync()
		{
			return await _regionDAO.GetAllAsync();
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
