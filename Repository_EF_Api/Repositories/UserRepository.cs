using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Repository_EF_Api.Data;
using Repository_EF_Api.Interfaces;
using Repository_EF_Api.Models;

namespace Repository_EF_Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Create(User user)
        {
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt= DateTime.Now;

            _context.User.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.User.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task Update(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
