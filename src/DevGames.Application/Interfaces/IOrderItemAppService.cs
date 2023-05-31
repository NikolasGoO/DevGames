using DevGames.Application.ViewModel;
using DevGames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevGames.Application.Interfaces
{
    public interface IOrderItemAppService
    {
        Task<OrderItemViewModel> AddAsync(OrderItemViewModel orderItem);
        OrderItemViewModel Update(OrderItemViewModel orderItem);
            
        void Remove(Guid id);
        void Remove(Expression<Func<OrderItem, bool>> expression);

        OrderItemViewModel GetById(Guid id);
        Task<OrderItemViewModel> GetByIdAsync(Guid id);

        IEnumerable<OrderItemViewModel> Search(Expression<Func<OrderItem, bool>> predicate);
        Task<IEnumerable<OrderItemViewModel>> SearchAsync(Expression<Func<OrderItem, bool>> predicate);
        IEnumerable<OrderItemViewModel> Search(Expression<Func<OrderItem, bool>> predicate,
            int pageNumber,
            int pageSize);
    }
}
