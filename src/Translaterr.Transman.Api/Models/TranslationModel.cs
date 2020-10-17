using System;
using System.Text.Json.Serialization;
using Translaterr.Transman.Domain.Types;

namespace Translaterr.Transman.Api.Models
{
    public class TranslationModel
    {
        [JsonPropertyName("publicId")]
        public Guid PublicId { get; set; }
        
        [JsonPropertyName("key")]
        public string Key { get; set; }
        
        [JsonPropertyName("environment")]
        public string Environment { get; set; }
        
        [JsonPropertyName("languageCode")]
        public string LanguageCode { get; set; }
        
        [JsonPropertyName("value")]
        public string Value { get; set; }

        public TranslationModel(Translation translation)
        {
            PublicId = translation.PublicId;
            Key = translation.Key;
            Environment = translation.Environment?.Name;
        }
    }
}