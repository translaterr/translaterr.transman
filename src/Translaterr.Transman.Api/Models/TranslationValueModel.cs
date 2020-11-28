using System.Text.Json.Serialization;
using Translaterr.Transman.Abstractions.Types;

namespace Translaterr.Transman.Api.Models
{
    public class TranslationValueModel
    {
        [JsonPropertyName("languageCode")]
        public string LanguageCode { get; set; }
        
        [JsonPropertyName("value")]
        public string Value { get; set; }

        public TranslationValueModel() {}
        
        public TranslationValueModel(ITranslationValue translationValueModel)
        {
            LanguageCode = translationValueModel.LanguageCode;
            Value = translationValueModel.Value;
        }
        
        public ITranslationValue ToDomain() => new TranslationValue()
        {
            LanguageCode = LanguageCode,
            Value = Value,
        };
    }
}