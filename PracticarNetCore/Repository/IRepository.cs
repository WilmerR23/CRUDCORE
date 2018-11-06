using Microsoft.EntityFrameworkCore;
using PracticarNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PracticarNetCore.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> FindAll();
        Task<IEnumerable<T>> FindAll(string Include);
        Task<T> FindOne(Expression<Func<T, bool>> function);
        Task Save(T entity);
        void Update(T entity);
        void Delete(T entity);
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly Contexto _context;
        private readonly DbSet<T> _entity;

        public Repository(Contexto context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<T>> FindAll()
        {
            return await _entity.Include<T>("Pais").ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAll(string Include)
        {
            return await _entity.Include<T>(Include).ToListAsync();
        }

        public async Task<T> FindOne(Expression<Func<T,bool>> function)
        {
           return await _entity.FirstOrDefaultAsync(function);
        }        

        public async Task Save(T entity)
        {
           await _context.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }

}
