using System;
using System.Collections.Generic;

namespace Translaterr.Transman.Abstractions.Types
{
    public class Translation : ITranslation
    {
        public Guid Id { get; set; }
        public Guid ApplicationId { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public string DefaultValue { get; set; }
        public IList<ITranslationValue> Translations { get; set; }
        
        public Translation() {}

        public Translation(Guid id, Guid applicationId)
        {
            Id = id;
            ApplicationId = applicationId;
        }
    }
}