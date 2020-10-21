using System;
using Microsoft.EntityFrameworkCore;
using Translaterr.Transman.Domain.Data;

namespace Translaterr.Transman.Api.Tests.Controllers
{
    public abstract class BaseControllerTests : IDisposable
    {
        protected AppDbContext AppDbContext;

        public BaseControllerTests(string databaseName)
        {
            AppDbContext = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                    .UseInMemoryDatabase(databaseName)
                    .Options);
        }

        public void Dispose()
        {
            AppDbContext?.Dispose();
        }
    }
}