using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Translaterr.Transman.Api.Validators;

namespace Translaterr.Transman.Api.DTOs.Translations
{
    public class TranslationsCreateRequest
    {
        [JsonPropertyName("key")]
        [Required]
        [MaxLength(255)]
        [MinLength(1)]
        public string Key { get; set; }
        
        [JsonPropertyName("environmentId")]
        public Guid EnvironmentId { get; set; }
        
        [JsonPropertyName("languageCode")]
        [Required]
        [LanguageCode]
        public string LanguageCode { get; set; }
        
        [JsonPropertyName("value")]
        [Required]
        public string Value { get; set; }
    }
}