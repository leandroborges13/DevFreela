using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.InsertUserSkill
{
    public class InsertUserSkillHandler : IRequestHandler<InsertUserSkillCommand, ResultViewModel>
    {
        private readonly IUserRepository _repository;
        public InsertUserSkillHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel> Handle(InsertUserSkillCommand request, CancellationToken cancellationToken)
        {
            var userSkill = new UserSkill(request.IdUser, request.IdSkill);

            await _repository.AddSkill(userSkill);

            return ResultViewModel.Success();
        }
    }
}
