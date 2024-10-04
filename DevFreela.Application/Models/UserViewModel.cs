

using DevFreela.Core.Entities;
using System.Xml.Linq;

namespace DevFreela.Application.Models
{
    public class UserViewModel
    {
        public UserViewModel(string fullName, string email, DateTime birthDate, List<UserSkill> skills)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Skills = skills.Select(c => c.Skill.Description).ToList();
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public List<string> Skills { get; private set; }

        public static UserViewModel FromEntity(User user) => new(user.FullName, user.Email, user.BirthDate, user.UserSkills);
        
    }
}
