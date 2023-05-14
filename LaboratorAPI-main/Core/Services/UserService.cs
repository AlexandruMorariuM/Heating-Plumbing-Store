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
            try
            {
                var results = unitOfWork.Users.GetAll();
                return results;
            }
            catch (Exception e)
            {
                Console.WriteLine("Core.Services => List<User> GetAll(): " + e.Message);
                throw new Exception("Error while reading all users! ", e);
            }
        }

        public UserDto GetById(int userId)
        {
            var user = unitOfWork.Users.GetById(userId);
            var result = user.ToUserDto();
            return result;
        }

    }
}
