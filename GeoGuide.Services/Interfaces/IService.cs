using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoGuide.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task DeleteAsync(string id);
        Task UpdateAsync(string id, T entity);
        Task<T> FindByIdAsync(string id);
		Task<int> GetCountAsync();
		Task<List<T>> GetPagedAsync(int skip, int pageSize);

	}
}
