using System;
using System.Globalization;
using Translaterr.Transman.Api.Validators;
using Xunit;

namespace Translaterr.Transman.Api.Tests.Validators
{
    public class LanguageCodeValidatorTests
    {
        private LanguageCode _languageCodeValidator;

        public LanguageCodeValidatorTests()
        {
            _languageCodeValidator = new LanguageCode();
        }

        [Fact]
        public void AnEmptyLanguageCodeIsInvalid()
        {
            Assert.False(_languageCodeValidator.IsValid(""));
        }

        [Fact]
        public void ANullValueIsValid()
        {
            Assert.True(_languageCodeValidator.IsValid(null));
        }

        [Fact]
        public void AllLanguageCodesIsValid()
        {
            var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            
            foreach(var culture in cultures)
            {
                // Avoid checking for empty string
                if (string.IsNullOrEmpty(culture.Name))
                {
                    continue;
                }
                
                Assert.True(_languageCodeValidator.IsValid(culture.Name));
            }
        }

        [Theory]
        [InlineData("nbnbnbnb")]
        [InlineData("roflcoptermao")]
        [InlineData("leetspeak")]
        public void ANonExistingLanguageCodeIsInvalid(string languageCode)
        {
            Assert.False(_languageCodeValidator.IsValid(languageCode));
        }
    }
}