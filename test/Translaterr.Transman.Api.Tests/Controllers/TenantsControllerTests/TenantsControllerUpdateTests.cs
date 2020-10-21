using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Translaterr.Transman.Api.DTOs.Tenants;
using Xunit;

namespace Translaterr.Transman.Api.Tests.Controllers.TenantsControllerTests
{
    public class TenantsControllerUpdateTests : BaseTenantsControllerTests
    {
        public TenantsControllerUpdateTests() : base("TenantsControllerUpdateTests") { }
        
        [Fact]
        public async Task ACall_ShouldUpdateTheGivenTenantInTheDatabase()
        {
            // Arrange
            var tenantSubject = Tenants.First();
            var publicIdSubject = tenantSubject.PublicId;
            var newName = "A new fancy name";
            var request = new TenantsUpdateRequest {Name = newName};
            
            // Act
            var result = await TenantsController.Update(publicIdSubject, request, CancellationToken.None);
            var noContentResult = result as NoContentResult;

            var tenantFromDb = await AppDbContext.Tenants.FirstOrDefaultAsync(t => t.PublicId == publicIdSubject);
            
            // Assert
            Assert.NotNull(noContentResult);
            Assert.NotNull(tenantFromDb);
            
            Assert.Equal(newName, tenantFromDb.Name);
        }
    }
}