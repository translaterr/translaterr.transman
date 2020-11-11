using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Translaterr.Transman.Api.Tests.Controllers.TenantsControllerTests
{
    public class TenantsControllerDeleteTests : BaseTenantsControllerTests
    {
        public TenantsControllerDeleteTests() : base("TenantsControllerDeleteTests") { }
        
        [Fact]
        public async Task ACall_ShouldDeleteTheTenantFromTheDatabase()
        {
            // Arrange
            var tenantSubject = Tenants.First();
            var publicIdSubject = tenantSubject.PublicId;
            
            // Act
            var result = await TenantsController.Delete(publicIdSubject, CancellationToken.None);
            var okResult = result as OkResult;

            var tenantFromDb = await AppDbContext.Tenants.FirstOrDefaultAsync(t => t.PublicId == publicIdSubject);
            
            // Assert
            Assert.NotNull(okResult);
            Assert.Null(tenantFromDb);
        }
    }
}