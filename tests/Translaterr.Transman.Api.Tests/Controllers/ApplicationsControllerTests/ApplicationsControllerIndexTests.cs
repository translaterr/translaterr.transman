using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Translaterr.Transman.Api.Models;
using Xunit;

namespace Translaterr.Transman.Api.Tests.Controllers.ApplicationsControllerTests
{
    public class ApplicationsControllerIndexTests : BaseApplicationsControllerTests
    {
        public ApplicationsControllerIndexTests() : base("ApplicationsControllerIndexTests") { }

        [Fact]
        public async Task ACall_ShouldReturnTheCorrectAmountOfApplications()
        {
            // Arrange
            
            // Act
            var result = await ApplicationsController.Index(Tenant.PublicId, CancellationToken.None);
            var okObjectResult = result as OkObjectResult;
            var applications = okObjectResult?.Value as List<ApplicationModel>;
            
            // Assert
            Assert.NotNull(applications);
            Assert.Equal(Applications.Count, applications.Count);
        }
    }
}