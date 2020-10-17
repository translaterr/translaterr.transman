using FakeItEasy;
using Microsoft.Extensions.Logging;
using Translaterr.Transman.Api.Controllers;

namespace Translaterr.Transman.Api.Tests.Controllers.LanguageController
{
    public abstract class BaseLanguageControllerTests : BaseControllerTests
    {
        protected LanguagesController LanguagesController;

        protected ILogger<LanguagesController> Logger;

        public BaseLanguageControllerTests()
        {
            Logger = A.Fake<ILogger<LanguagesController>>();
            
            LanguagesController = new LanguagesController(Logger);
        }
    }
}