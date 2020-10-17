using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Translaterr.Transman.Api.Validators;

namespace Translaterr.Transman.Api.DTOs.Languages
{
    public class LanguagesCreateRequest
    {
        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; }
        
        [JsonPropertyName("isoCode")]
        [Required]
        [LanguageCode]
        public string IsoCode { get; set; }
    }
}