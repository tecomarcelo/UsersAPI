using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersAPI.Domain.Interfaces.Repositories;
using UsersAPI.Infra.Data.Contexts;

namespace UsersAPI.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext? _dataContext;

        public UnitOfWork(DataContext? dataContext)
        {
            _dataContext = dataContext;
        }

        public IUserRepository UserRepository => new UserRepository(_dataContext);

        public void SaveChanges()
        {
            _dataContext?.SaveChanges();
        }

        public void Dispose()
        {
            _dataContext?.Dispose();
        }
    }
}
