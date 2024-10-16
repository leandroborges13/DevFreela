using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsHandlerTest
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectsViewModels()
        {
            //Arrange
            var projects = new List<Project>()
            {
                new Project("Nome do teste", "Descrição do teste", 1, 1, 10000),
                new Project("Nome do teste", "Descrição do teste", 1, 1, 10000),
                new Project("Nome do teste", "Descrição do teste", 1, 1, 10000)
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();

            projectRepositoryMock.Setup(pr => pr.GetAll().Result).Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery();
            var getAllProjectQueryHandler = new GetAllProjectsHandler(projectRepositoryMock.Object);

            //Act

            var projectViewModelList = await getAllProjectQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            //Assert

            Assert.NotNull(projectViewModelList.Data);
            Assert.NotEmpty(projectViewModelList.Data);
            Assert.Equal(projects.Count, projectViewModelList.Data.Count);

            projectRepositoryMock.Verify(pr => pr.GetAll().Result, Times.Once);

        }
    }
}
