using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Translaterr.Transman.Api.DTOs.Translations.Support
{
    public class TranslationValueDto
    {
        [JsonPropertyName("languageCode")]
        [Required]
        public string LanguageCode { get; set; }
        
        [Required]
        public string Value { get; set; }
    }
}