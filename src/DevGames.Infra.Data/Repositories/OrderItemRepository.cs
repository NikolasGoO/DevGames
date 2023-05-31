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
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(DevGamesDbContext context) : base(context) 
        {
        }

        public OrderItem Add(OrderItem entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public async Task<OrderItem> AddAsync(OrderItem entity)
        {
            DbSet.AddAsync(entity);
            return entity;
        }

        public OrderItem GetById(Guid id)
        {
            var context = DbSet.AsQueryable();
            var orderItem = context.FirstOrDefault(c => c.Id == id);
            return orderItem;
        }

        public async Task<OrderItem> GetByIdAsync(Guid id)
        {
            var context = DbSet.AsQueryable();
            var orderItem = await context.FirstOrDefaultAsync(x => x.Id == id);
            return orderItem;
        }

        public void Remove(Guid id)
        {
            var obj = GetById(id);
            if(obj != null)
            {
                DbSet.Remove(obj);
            }
        }

        public void Remove(Expression<Func<OrderItem, bool>> expression)
        {
            var context = DbSet.AsQueryable();
            var entities = context.Where(expression);
            DbSet.RemoveRange(entities);
        }

        public IEnumerable<OrderItem> Search(Expression<Func<OrderItem, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            return context.Where(predicate).ToList();
        }

        public IEnumerable<OrderItem> Search(Expression<Func<OrderItem, bool>> predicate, int pageNumber, int pageSize)
        {
            var context = DbSet.AsQueryable();
            var result = context.Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return result;
        }

        public async Task<IEnumerable<OrderItem>> SearchAsync(Expression<Func<OrderItem, bool>> predicate)
        {
            var context = DbSet.AsQueryable(); 
            return await context.Where(predicate).ToListAsync();
        }

        public OrderItem Update(OrderItem entity)
        {
            DbSet.Update(entity);
            return entity;
        }
    }
}
