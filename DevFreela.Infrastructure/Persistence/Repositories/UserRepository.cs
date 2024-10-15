using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _context;
        public UserRepository(DevFreelaDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task AddSkill(UserSkill skill)
        {
            await _context.UserSkills.AddAsync(skill);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Users.AnyAsync(p => p.Id == id);
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users
                .Where(p => !p.IsDeleted).ToListAsync();
        }

        public async Task<User> GetByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _context.Users.SingleOrDefaultAsync(p => p.Email == email && p.Password == passwordHash);
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.Users.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<User?> GetDetailsById(int id)
        {
            var user = await _context.Users
                .Include(p => p.UserSkills)
                .Include(p => p.FreelanceProjects)
                .Include(p => p.OwnedProjects)
                .Include(p => p.Comments)
                .SingleOrDefaultAsync(p => p.Id == id);

            return user;
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
