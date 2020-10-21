using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Translaterr.Transman.Api.DTOs.Tenants;
using Translaterr.Transman.Api.Models;
using Xunit;

namespace Translaterr.Transman.Api.Tests.Controllers.TenantsControllerTests
{
    public class TenantsControllerCreateTests : BaseTenantsControllerTests
    {
        public TenantsControllerCreateTests() : base("TenantsControllerCreateTests") { }
        
        [Fact]
        public async Task ACall_ShouldCreateTheGivenTenantAndPersistIt()
        {
            // Arrange
            var tenantName = "A test tenant";
            var request = new TenantsCreateRequest()
            {
                Name = tenantName,
            };
            
            // Act
            var result = await TenantsController.Create(request, CancellationToken.None);
            var okObjectResult = result as OkObjectResult;
            var tenant = okObjectResult?.Value as TenantModel;
            
            // Assert
            Assert.NotNull(tenant);
            Assert.Equal(tenantName, tenant.Name);
            Assert.NotNull(tenant.PublicId);
            Assert.IsType<Guid>(tenant.PublicId);
        }
        
    }
}