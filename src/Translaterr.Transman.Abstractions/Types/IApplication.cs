using System;
using System.Collections.Generic;

namespace Translaterr.Transman.Abstractions.Types
{
    public interface IApplication : IType
    {
        public int Id { get; set; }
        
        public Guid PublicId { get; set; }
        
        public string Name { get; set; }
        
        public ILanguage DefaultLanguage { get; set; }
        public IList<ILanguage> Languages { get; set; }
        public IList<ITranslation> Translations { get; set; }
    }
}