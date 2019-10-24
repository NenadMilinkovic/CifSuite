using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinesLogicLayer;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace CifSuiteCore.Repository
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> DeleteUser(int id)
        {
            User user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);

            _context.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetUser(int id)
        {
            User user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            IEnumerable<User> users = _context.Users.AsQueryable();
            return users;
        }

        public async Task<User> UpdateUser(User user)
        {
            User oldUser = await _context.Users.SingleOrDefaultAsync(x => x.Id == user.Id);
            oldUser.Update(user);

            await _context.SaveChangesAsync();

            return user;
        }
    }
}
