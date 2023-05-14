using DataLayer;
using DataLayer.Dtos;
using DataLayer.Entities;
using DataLayer.Mapping;

namespace Core.Services
{
    public class UserService
    {
        private readonly UnitOfWork unitOfWork;
        public UserService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<User> GetAll()
        {
            var results = unitOfWork.Users.GetAll();

            return results;
        }

        public UserDto GetById(int userId)
        {
            var user = unitOfWork.Users.GetById(userId);

            var result = user.ToUserDto();

            return result;
        }

    }
}
