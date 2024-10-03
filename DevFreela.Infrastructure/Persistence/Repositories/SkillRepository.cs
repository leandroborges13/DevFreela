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
    public class SkillRepository : ISkillRepository
    {
        private readonly DevFreelaDbContext _context;
        public SkillRepository(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Skill skill)
        {
            await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();

            return skill.Id;
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Skills.AnyAsync(p => p.Id == id);
        }

        public async Task<List<Skill>> GetAll()
        {
            return await _context.Skills
                .Where(p => !p.IsDeleted).ToListAsync();
        }

        public async Task<Skill?> GetById(int id)
        {
            return await _context.Skills.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task Update(Skill user)
        {
            _context.Skills.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
