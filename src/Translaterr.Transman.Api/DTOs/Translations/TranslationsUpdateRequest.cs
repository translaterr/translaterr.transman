using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Translaterr.Transman.Api.DTOs.Translations.Support;

namespace Translaterr.Transman.Api.DTOs.Translations
{
    public class TranslationsUpdateRequest
    {
        [JsonPropertyName("values")]
        [Required]
        [MinLength(1)]
        public IList<TranslationValueDto> Values { get; set; }
    }
}