using MongoDB.Bson.Serialization.Attributes;
using Translaterr.Transman.Abstractions.Types;

namespace Translaterr.Transman.Data.Entities
{
    public class TranslationValueEntity
    {
        [BsonElement("LanguageCode")]
        public string LanguageCode { get; set; }
        
        [BsonElement("Value")]
        public string Value { get; set; }

        public TranslationValueEntity(ITranslationValue translationValue)
        {
            LanguageCode = translationValue.LanguageCode;
            Value = translationValue.Value;
        }
        
        public ITranslationValue ToDomain() => new TranslationValue()
        {
            LanguageCode = LanguageCode,
            Value = Value,
        };
    }
}