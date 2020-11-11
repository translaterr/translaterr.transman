using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Translaterr.Transman.Api.DTOs.Applications;
using Translaterr.Transman.Api.Models;
using Xunit;

namespace Translaterr.Transman.Api.Tests.Controllers.ApplicationsControllerTests
{
    public class ApplicationsControllerUpdateTests : BaseApplicationsControllerTests
    {
        public ApplicationsControllerUpdateTests() : base("ApplicationsControllerUpdateTests") { }
        
        [Fact]
        public async Task ACall_ShouldUpdateAndPersistTheChangesInTheDatabase()
        {
            // Arrange
            var application = Applications.First();
            var applicationName = "A new fancy or maybe sluggish name";
            var request = new ApplicationsUpdateRequest
            {
                Name = applicationName
            };
            
            // Act
            var result = await ApplicationsController.Update(Tenant.PublicId, application.PublicId, request, CancellationToken.None);
            var okObjectResult = result as NoContentResult;

            var applicationFromDatabase = await AppDbContext.Applications.FirstOrDefaultAsync(a => a.PublicId == application.PublicId);
            
            // Assert
            Assert.NotNull(okObjectResult);
            Assert.Equal(applicationName, applicationFromDatabase.Name);
        }
    }
}