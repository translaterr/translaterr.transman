using System.Globalization;
using System.Text.Json.Serialization;

namespace Translaterr.Transman.Api.Models
{
    public class LanguageModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("languageCode")]
        public string LanguageCode { get; set; }

        public LanguageModel(CultureInfo cultureInfo)
        {
            Name = cultureInfo.EnglishName;
            LanguageCode = cultureInfo.Name;
        }
    }
}