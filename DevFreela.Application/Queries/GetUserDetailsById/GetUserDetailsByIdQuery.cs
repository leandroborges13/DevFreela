﻿using DevFreela.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetUserDetailsById
{
    public class GetUserDetailsByIdQuery : IRequest<ResultViewModel<UserViewModel>>
    {
        public GetUserDetailsByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
