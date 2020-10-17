using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Translaterr.Transman.Api.Models;
using Xunit;

namespace Translaterr.Transman.Api.Tests.Controllers.LanguageController
{
    public class LanguageControllerIndexTests : BaseLanguageControllerTests
    {
        [Fact]
        public async Task ACall_ShouldReturnAListOfLanguages()
        {
            // Arrange
            
            // Act
            var result = LanguagesController.Index();
            var okObjectResult = result as OkObjectResult;
            var languages = okObjectResult?.Value as List<LanguageModel>;
            
            // Assert
            Assert.NotNull(okObjectResult);
            Assert.NotNull(languages);
            Assert.NotEmpty(languages);
        }
    }
}