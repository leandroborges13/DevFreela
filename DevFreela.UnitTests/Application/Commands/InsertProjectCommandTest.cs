using DevFreela.Application.Commands.InsertProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.UnitTests.Application.Commands
{
    public class InsertProjectCommandTest
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectId()
        {
            //Arrange
            var projectRepositoryMock = new Mock<IProjectRepository>();

            var insertProjectCommand = new InsertProjectCommand()
            {
                Title = "Title Test",
                Description = "Description Test",
                IdClient = 1,
                IdFreelancer = 2,
                TotalCost = 40000
            };

            var insertProjectHandler = new InsertProjectHandler(projectRepositoryMock.Object);
            //Act

            var id = await insertProjectHandler.Handle(insertProjectCommand, new CancellationToken());
            //Assert

            Assert.True(id.Data >= 0);
            projectRepositoryMock.Verify(pr => pr.Add(It.IsAny<Project>()), Times.Once);
        }
    }
}
