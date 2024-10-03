using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsHandler : IRequestHandler<GetAllSkillsQuery, ResultViewModel<List<Skill>>>
    {
        private readonly ISkillRepository _repository;
        public GetAllSkillsHandler(ISkillRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<List<Skill>>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = await _repository.GetAll();
            return ResultViewModel<List<Skill>>.Success(skills);
        }
    }
}
