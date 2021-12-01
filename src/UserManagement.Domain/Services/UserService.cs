using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces.Services;
using UserManagement.Domain.Interfaces.UoW;

namespace UserManagement.Domain.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddUser(User user)
        {
            user.InclusionDate = DateTime.UtcNow.ToLocalTime();
            await _unitOfWork.userRepository.AddAsync(user);
            _unitOfWork.Commit();
        }

        public async Task<User> UpdateUser(User user)
        {
            var result = await _unitOfWork.userRepository.UpdateAsync(user);
            _unitOfWork.Commit();
            return result;
        }

        public async Task<User> GetUser(int id)
        {
            return await _unitOfWork.userRepository.GetAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _unitOfWork.userRepository.GetAsync();
        }
        public async Task DeleteUser(int id)
        {
            await Task.Run(() => {
                _unitOfWork.userRepository.Delete(id);
                _unitOfWork.Commit();
            });
        }

    }
}
