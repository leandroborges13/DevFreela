using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ResultViewModel<LoginUserViewModel>>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;
        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }
        public async Task<ResultViewModel<LoginUserViewModel>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);
            var user = await _userRepository.GetByEmailAndPasswordAsync(request.Email, passwordHash);

            if (user is null)
            {
                return ResultViewModel<LoginUserViewModel>.Error("Usuário não existe.");
            }

            var token = _authService.GenerateJWTToken(user.Email, user.Role);

            var model = new LoginUserViewModel(user.Email, token);

            return ResultViewModel<LoginUserViewModel>.Success(model);
        }
    }
}

