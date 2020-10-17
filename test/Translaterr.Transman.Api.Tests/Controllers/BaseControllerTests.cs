using Microsoft.EntityFrameworkCore;
using Translaterr.Transman.Domain.Data;

namespace Translaterr.Transman.Api.Tests.Controllers
{
    public abstract class BaseControllerTests
    {
        protected AppDbContext AppDbContext;

        public BaseControllerTests()
        {
            AppDbContext = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                    .UseInMemoryDatabase("controllers")
                    .Options);
        }
    }
}