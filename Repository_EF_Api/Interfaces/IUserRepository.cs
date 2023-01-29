using Repository_EF_Api.Models;

namespace Repository_EF_Api.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task Create(User user);
        Task Update(User user);
        Task Delete(User user);
    }
}
