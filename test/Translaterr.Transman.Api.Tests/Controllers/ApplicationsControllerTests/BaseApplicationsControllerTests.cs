using System;
using System.Collections.Generic;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using Translaterr.Transman.Api.Controllers;
using Translaterr.Transman.Domain.Types;

namespace Translaterr.Transman.Api.Tests.Controllers.ApplicationsControllerTests
{
    public class BaseApplicationsControllerTests : BaseControllerTests
    {
        protected ApplicationsController ApplicationsController;
        protected ILogger<ApplicationsController> Logger;

        protected Tenant Tenant;
        protected IList<Application> Applications;
        
        public BaseApplicationsControllerTests(string testName) : base(testName)
        {
            Logger = A.Fake<ILogger<ApplicationsController>>();
            
            ApplicationsController = new ApplicationsController(Logger, AppDbContext);
            
            Tenant = new Tenant
            {
                Id = 1,
                Name = "TestTenant",
                PublicId = Guid.NewGuid()
            };
            
            Applications = new List<Application>
            {
                new Application
                {
                    Id = 1,
                    Name = "Frontpage",
                    Tenant = Tenant,
                    PublicId = Guid.NewGuid(),
                    FallbackLanguage = "nb",
                },
                new Application
                {
                    Id = 2,
                    Name = "Backend",
                    Tenant = Tenant,
                    PublicId = Guid.NewGuid(),
                    FallbackLanguage = "nb",
                },
                new Application
                {
                    Id = 3,
                    Name = "AlertService",
                    Tenant = Tenant,
                    PublicId = Guid.NewGuid(),
                    FallbackLanguage = "nb",
                },
            };

            AppDbContext.Tenants.Add(Tenant);
            AppDbContext.Applications.AddRange(Applications);
            AppDbContext.SaveChanges();
        }
    }
}