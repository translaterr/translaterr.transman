using System;
using System.Collections.Generic;

namespace Translaterr.Transman.Abstractions.Types
{
    public interface ITranslation
    {
        public Guid Id { get; set; }
        public Guid ApplicationId { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public string DefaultValue { get; set; }
        public IList<ITranslationValue> Translations { get; set; }
    }
}