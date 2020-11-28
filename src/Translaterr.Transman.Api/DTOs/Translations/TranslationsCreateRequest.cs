using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Translaterr.Transman.Api.Models;

namespace Translaterr.Transman.Api.DTOs.Translations
{
    public class TranslationsCreateRequest
    {
        [JsonPropertyName("key")]
        [Required]
        [MaxLength(255)]
        [MinLength(1)]
        public string Key { get; set; }
        
        [JsonPropertyName("translations")]
        [Required]
        public IList<TranslationValueModel> Translations { get; set; }
    }
}