using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Translaterr.Transman.Api.Models;
using Xunit;

namespace Translaterr.Transman.Api.Tests.Controllers.TenantsControllerTests
{
    public class TenantsControllerIndexTests : BaseTenantsControllerTests
    {
        public TenantsControllerIndexTests() : base("TenantsControllerIndexTests") { }
        
        [Fact]
        public async Task ACall_ShouldReturnTheCorrectAmountOfTenants()
        {
            // Arrange
            
            // Act
            var result = await TenantsController.Index(CancellationToken.None);
            var okObjectResult = result as OkObjectResult;
            var tenants = okObjectResult?.Value as List<TenantModel>;
            
            // Assert
            Assert.NotNull(tenants);
            Assert.True(tenants.Count == Tenants.Count);
        }
    }
}