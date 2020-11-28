using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Translaterr.Transman.Api.Models;

namespace Translaterr.Transman.Api.DTOs.Translations
{
    public class TranslationsUpdateRequest
    {
        [Required]
        public string Key { get; set; }
        
        public string Description { get; set; }
        
        public string DefaultValue { get; set; }
        
        [JsonPropertyName("translations")]
        [Required]
        public IList<TranslationValueModel> Translations { get; set; }
    }
}