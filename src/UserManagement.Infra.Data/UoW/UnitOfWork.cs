using UserManagement.Domain.Interfaces.Repositories;
using UserManagement.Domain.Interfaces.UoW;
using UserManagement.Infra.Data.Context;
using UserManagement.Infra.Data.Repositories;

namespace UserManagement.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IUserRepository _userRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IUserRepository userRepository => _userRepository = _userRepository ?? new UserRepository(_context);

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
