using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversitetSayti.Interfaces
{
   public  interface IRepositoryAsync<T> where T:class 
    {
        Task<T> GetidAsync(int id);

        Task<IReadOnlyList<T>> GetAllAsync();

        Task<IReadOnlyList<T>> GetPagedListAsync(int pageNumber, int pageSize);

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
