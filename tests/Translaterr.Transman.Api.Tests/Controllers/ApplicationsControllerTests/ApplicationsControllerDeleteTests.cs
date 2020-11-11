using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Translaterr.Transman.Api.Tests.Controllers.ApplicationsControllerTests
{
    public class ApplicationsControllerDeleteTests : BaseApplicationsControllerTests
    {
        public ApplicationsControllerDeleteTests() : base("ApplicationsControllerDeleteTests") { }

        [Fact]
        public async Task ACall_ShouldDeleteTheApplicationFromTheDatabase()
        {
            // Arrange
            var application = Applications.First();
            
            // Act
            var result = await ApplicationsController.Delete(Tenant.PublicId, application.PublicId, CancellationToken.None);
            var okResult = result as OkResult;

            var applicationFromDb = await AppDbContext.Applications.FirstOrDefaultAsync(a => a.PublicId == application.PublicId);

            // Assert
            Assert.NotNull(okResult);
            Assert.Null(applicationFromDb);
        }
    }
}