using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Translaterr.Transman.Abstractions.Types;

namespace Translaterr.Transman.Api.Models
{
    public class TranslationModel
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }
        
        [JsonPropertyName("description")]
        public string Description { get; set; }
        
        [JsonPropertyName("defaultValue")]
        public string DefaultValue { get; set; }
        
        [JsonPropertyName("translations")]
        public IEnumerable<TranslationValueModel> Translations { get; set; }

        public TranslationModel() { }

        public TranslationModel(ITranslation translation)
        {
            Key = translation.Key;
            Description = translation.Description;
            DefaultValue = translation.DefaultValue;
            Translations = translation.Translations.Select(t => new TranslationValueModel(t)).ToList();
        }
        
        public ITranslation ToDomain(Guid applicationId) => new Translation()
        {
            ApplicationId = applicationId,
            Key = Key,
            Description = Description,
            DefaultValue = DefaultValue,
            Translations = Translations.Select(t => t.ToDomain()).ToList()
        };
    }
}