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
    public interface IProductAppService
    {
        Task<ProductViewModel> AddAsync(ProductViewModel product);
        ProductViewModel Update(ProductViewModel product);

        void Remove(Guid id);
        void Remove(Expression<Func<Product, bool>> expression);

        ProductViewModel GetById(Guid id);
        Task<ProductViewModel> GetByIdAsync(Guid id);

        IEnumerable<ProductViewModel> Search(Expression<Func<Product, bool>> predicate);
        Task<IEnumerable<ProductViewModel>> SearchAsync(Expression<Func<Product, bool>> predicate);
        IEnumerable<ProductViewModel> Search(Expression<Func<Product, bool>> predicate,
            int pageNumber,
            int pageSize);
        void DecreaseStock(Guid productId, int quantity);
        int CheckQuantityStock(Guid productId);
    }
}
