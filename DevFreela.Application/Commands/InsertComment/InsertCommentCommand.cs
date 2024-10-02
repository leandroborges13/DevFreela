using DevFreela.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.InsertComment
{
    public class InsertCommentCommand : IRequest<ResultViewModel>
    {
        //public InsertCommentCommand(string content, int idProject, int idUser)
        //{
        //    Content = content;
        //    IdProject = idProject;
        //    IdUser = idUser;
        //}

        public string Content { get; set; }
        public int IdProject { get; set; }
        public int IdUser { get; set; }
    }
}
