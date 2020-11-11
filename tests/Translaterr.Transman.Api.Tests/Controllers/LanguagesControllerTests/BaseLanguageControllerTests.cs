using FakeItEasy;
using Microsoft.Extensions.Logging;
using Translaterr.Transman.Api.Controllers;

namespace Translaterr.Transman.Api.Tests.Controllers.LanguagesControllerTests
{
    public abstract class BaseLanguagesControllerTests : BaseControllerTests
    {
        protected LanguagesController LanguagesController;

        protected ILogger<LanguagesController> Logger;

        public BaseLanguagesControllerTests(string testsName) : base(testsName)
        {
            Logger = A.Fake<ILogger<LanguagesController>>();
            
            LanguagesController = new LanguagesController(Logger);
        }
    }
}