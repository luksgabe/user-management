using UserManagement.Domain.Interfaces.Repositories;

namespace UserManagement.Domain.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        IUserRepository userRepository { get; }
        bool Commit();

        public void Dispose();
    }
}
