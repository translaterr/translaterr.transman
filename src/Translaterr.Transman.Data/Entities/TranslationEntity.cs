using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson.Serialization.Attributes;
using Translaterr.Transman.Abstractions.Types;

namespace Translaterr.Transman.Data.Entities
{
    public class TranslationEntity
    {
        [BsonId]
        public Guid Id { get; set; }
        
        [BsonElement("ApplicationId")]
        public Guid ApplicationId { get; set; }
        
        [BsonElement("Key")]
        public string Key { get; set; }
        
        [BsonElement("Description")]
        public string Description { get; set; }
        
        [BsonElement("DefaultValue")]
        public string DefaultValue { get; set; }
        
        [BsonElement("Translations")]
        public IList<TranslationValueEntity> Translations { get; set; } = new List<TranslationValueEntity>();

        public TranslationEntity(ITranslation translation)
        {
            Id = translation.Id;
            ApplicationId = translation.ApplicationId;
            Key = translation.Key;
            Description = translation.Description;
            DefaultValue = translation.DefaultValue;
            Translations = translation.Translations.Select(tv => new TranslationValueEntity(tv)).ToList();
        }

        public ITranslation ToDomain() => new Translation()
        {
            Id = Id,
            ApplicationId = ApplicationId,
            Key = Key,
            Description = Description,
            DefaultValue = DefaultValue,
            Translations = Translations.Select(t => t.ToDomain()).ToList()
        };
    }
}