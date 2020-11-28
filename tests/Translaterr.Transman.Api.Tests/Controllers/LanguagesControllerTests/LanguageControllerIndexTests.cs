using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Translaterr.Transman.Api.Controllers;
using Translaterr.Transman.Api.Models;
using Xunit;

namespace Translaterr.Transman.Api.Tests.Controllers.LanguagesControllerTests
{
    public class LanguagesControllerIndexTests : BaseLanguagesControllerTests
    {
        [Fact]
        public void ACall_ShouldReturnAListOfLanguages()
        {
            // Arrange
            
            // Act
            var result = LanguagesController.Index().Value;
            
            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}