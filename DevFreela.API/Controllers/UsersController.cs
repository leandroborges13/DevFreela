﻿using DevFreela.Application.Commands.InsertSkill;
using DevFreela.Application.Commands.InsertUser;
using DevFreela.Application.Commands.InsertUserSkill;
using DevFreela.Application.Commands.LoginUser;
using DevFreela.Application.Queries.GetAllUsers;
using DevFreela.Application.Queries.GetUserById;
using DevFreela.Application.Queries.GetUserDetailsById;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllUsersQuery();
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("details/{id}")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> GetDetailsById(int id)
        {
            var query = new GetUserDetailsByIdQuery(id);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserByIdQuery(id);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        //POST api/users
        [HttpPost]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Post(InsertUserCommand command)
        {

            var result = await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost("{id}/skills")]
        public async Task<IActionResult> PostSkills(InsertUserSkillCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/profile-pictures")]
        public IActionResult PostProfilePicture(IFormFile file)
        {
            var description = $"File: {file.FileName}, Size: {file.Length}";

            //processa imagem
            return Ok(description);
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {

            var result = await _mediator.Send(command);

            if(!result.IsSuccess)
            {
                return BadRequest("Não foi possível efetuar o login!");
            }

            return Ok(result);
        }
    }
}
