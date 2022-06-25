using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversitetSayti.Interfaces;
using UniversitetSayti.Models;

namespace UniversitetSayti.Repositories
{
    public class GenaricRepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly Universitet_SaytiContext _dbcontext;
        public GenaricRepositoryAsync(Universitet_SaytiContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async  Task<T> AddAsync(T entity)
        {
             await  _dbcontext.Set<T>().AddAsync(entity);
            await _dbcontext.SaveChangesAsync();
            return entity;
        }

        public async  Task DeleteAsync(T entity)
        {
             _dbcontext.Set<T>().Remove(entity);

            await _dbcontext.SaveChangesAsync();
        }

        public async  Task<IReadOnlyList<T>> GetAllAsync()
        {
           return await _dbcontext.Set<T>().ToListAsync();
        }

        public async  Task<T> GetidAsync(int id)
        {
           return  await _dbcontext.Set<T>().FindAsync(id);
        }

        public async  Task<IReadOnlyList<T>> GetPagedListAsync(int pageNumber, int pageSize)
        {
            return await _dbcontext.Set<T>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public async  Task UpdateAsync(T entity)
        {

            _dbcontext.Entry(entity).State = EntityState.Modified;
           await  _dbcontext.SaveChangesAsync();
            
        }
    }
}
