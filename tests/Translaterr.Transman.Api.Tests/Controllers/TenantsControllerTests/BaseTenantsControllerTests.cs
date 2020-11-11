using System;
using System.Collections.Generic;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using Translaterr.Transman.Api.Controllers;
using Translaterr.Transman.Domain.Types;

namespace Translaterr.Transman.Api.Tests.Controllers.TenantsControllerTests
{
    public class BaseTenantsControllerTests : BaseControllerTests
    {
        protected TenantsController TenantsController;
        protected ILogger<TenantsController> Logger;
        
        protected readonly IList<Tenant> Tenants = new List<Tenant>
        {
            new Tenant()
            {
                Id = 1,
                Name = "TestTenant1",
                PublicId = Guid.NewGuid(),
            },
            new Tenant()
            {
                Id = 2,
                Name = "TestTenant2",
                PublicId = Guid.NewGuid(),
            },
            new Tenant()
            {
                Id = 3,
                Name = "TestTenant3",
                PublicId = Guid.NewGuid(),
            },
        };

        public BaseTenantsControllerTests(string testsName) : base(testsName)
        {
            Logger = A.Fake<ILogger<TenantsController>>();
            AppDbContext.Tenants.AddRange(Tenants);
            AppDbContext.SaveChanges();
            
            TenantsController = new TenantsController(Logger, AppDbContext);
        }
    }
}