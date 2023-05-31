using DevGames.Domain.Entities;
using DevGames.Domain.Interfaces;
using DevGames.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevGames.Infra.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DevGamesDbContext context) : base(context)
        {
        }

        public Product Add(Product entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public async Task<Product> AddAsync(Product entity)
        {
            DbSet.AddAsync(entity);
            return entity;
        }

        public Product GetById(Guid id)
        {
            var context = DbSet.AsQueryable();
            var order = context.FirstOrDefault(x => x.Id == id);
            return order;
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            var context = DbSet.AsQueryable();
            var order = await context.FirstOrDefaultAsync(x => x.Id == id);
            return order;
        }

        public void Remove(Guid id)
        {
            var obj = GetById(id);
            if(obj != null)
            {
                DbSet.Remove(obj);
            }
        }

        public void Remove(Expression<Func<Product, bool>> expression)
        {
            var context = DbSet.AsQueryable();
            var entities = context.Where(expression);
            DbSet.RemoveRange(entities);
        }

        public IEnumerable<Product> Search(Expression<Func<Product, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            var entities = context.Where(predicate).ToList();
            return entities;
        }

        public IEnumerable<Product> Search(Expression<Func<Product, bool>> predicate, int pageNumber, int pageSize)
        {
            var context = DbSet.AsQueryable();
            var result = context.Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return result;
        }

        public async Task<IEnumerable<Product>> SearchAsync(Expression<Func<Product, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            var entities = await context.Where(predicate).ToListAsync();
            return entities;
        }

        public Product Update(Product entity)
        {
            DbSet.Update(entity);
            return entity;
        }
    }
}
