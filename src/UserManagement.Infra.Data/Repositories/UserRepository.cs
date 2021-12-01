
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces.Repositories;
using UserManagement.Infra.Data.Context;

namespace UserManagement.Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
