using System.Globalization;
using System.Text.Json.Serialization;
using Translaterr.Transman.Domain.Types;

namespace Translaterr.Transman.Api.Models
{
    public class LanguageModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("isoCode")]
        public string IsoCode { get; set; }

        public LanguageModel(CultureInfo cultureInfo)
        {
            Name = cultureInfo.EnglishName;
            IsoCode = cultureInfo.Name;
        }

        public LanguageModel(Language language)
        {
            Name = language.Name;
            IsoCode = language.IsoCode;
        }
    }
}