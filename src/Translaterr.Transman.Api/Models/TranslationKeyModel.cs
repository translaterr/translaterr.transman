using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Translaterr.Transman.Domain.Types;

namespace Translaterr.Transman.Api.Models
{
    public class TranslationKeyModel
    {
        [JsonPropertyName("publicId")]
        public Guid PublicId { get; set; }
        
        [JsonPropertyName("key")]
        public string Key { get; set; }
        
        [JsonPropertyName("translationValues")]
        public IList<TranslationValueModel> TranslationValues { get; set; }

        public TranslationKeyModel(TranslationKey translationKey)
        {
            PublicId = translationKey.PublicId;
            Key = translationKey.Key;
            TranslationValues = translationKey.TranslationValues
                .Select(tv => new TranslationValueModel(tv))
                .ToList();
        }
    }
}