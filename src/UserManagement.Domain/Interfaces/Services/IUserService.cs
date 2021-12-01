using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Interfaces.Services
{
    public interface IUserService : IServiceBase<User>
    {
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUsers();
        Task AddUser(User user);
        Task<User> UpdateUser(User user);
        Task DeleteUser(int id);
    }
}
