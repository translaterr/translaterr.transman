using System.Text.Json.Serialization;
using Translaterr.Transman.Domain.Types;

namespace Translaterr.Transman.Api.Models
{
    public class TranslationValueModel
    {
        [JsonPropertyName("languageCode")]
        public string LanguageCode { get; set; }
        
        [JsonPropertyName("value")]
        public string Value { get; set; }

        public TranslationValueModel(TranslationValue translationValue)
        {
            LanguageCode = translationValue.LanguageCode;
            Value = translationValue.Value;
        }
    }
}