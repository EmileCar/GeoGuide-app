using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoGuide.Repositories.Interfaces
{
    public interface IDAO<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task DeleteAsync(string id);
        Task UpdateAsync(string id, T entity);
        Task<T> FindByIdAsync(string id);
    }
}
