using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Translaterr.Transman.Api.DTOs.Applications;
using Translaterr.Transman.Api.Models;
using Xunit;

namespace Translaterr.Transman.Api.Tests.Controllers.ApplicationsControllerTests
{
    public class ApplicationsControllerCreateTests : BaseApplicationsControllerTests
    {
        public ApplicationsControllerCreateTests() : base("ApplicationsControllerCreateTests") { }

        [Fact]
        public async Task ACall_ShouldCreateAndPersistTheNewApplicationInTheDatabase()
        {
            // Arrange
            var applicationName = "A Fancy New Application";
            var request = new ApplicationsCreateRequest
            {
                Name = applicationName
            };
            
            // Act
            var result = await ApplicationsController.Create(Tenant.PublicId, request, CancellationToken.None);
            var okObjectResult = result as OkObjectResult;
            var application = okObjectResult?.Value as ApplicationModel;

            var applicationFromDatabase = await AppDbContext.Applications.FirstOrDefaultAsync(a => a.PublicId == application.PublicId);
            
            // Assert
            Assert.NotNull(application);
            Assert.Equal(applicationName, applicationFromDatabase.Name);
        }
    }
}