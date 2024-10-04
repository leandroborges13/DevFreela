using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<int> Add(User user);
        Task<User?> GetById(int id);
        Task<List<User>> GetAll();
        Task<User?> GetDetailsById(int id);
        Task Update(User user);
        Task<bool> Exists(int id);
        Task AddSkill(UserSkill skill);
    }
}
