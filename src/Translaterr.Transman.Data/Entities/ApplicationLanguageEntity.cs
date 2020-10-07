using System.ComponentModel.DataAnnotations;

namespace Translaterr.Transman.Data.Entities
{
    public class ApplicationLanguageEntity
    {
        public int ApplicationId { get; set; }
        public ApplicationEntity Application { get; set; }
        
        public int LanguageId { get; set; }
        public LanguageEntity Language { get; set; }
    }
}