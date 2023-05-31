using DevGames.Domain.Shared.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevGames.Infra.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context.DevGamesDbContext _context;

        public UnitOfWork(Context.DevGamesDbContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
