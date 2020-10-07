using System.ComponentModel.DataAnnotations.Schema;

namespace Translaterr.Transman.Data.Entities
{
    [Table("ApplicationsLanguages")]
    public class ApplicationLanguageEntity
    {
        public int ApplicationId { get; set; }
        public ApplicationEntity Application { get; set; }
        
        public int LanguageId { get; set; }
        public LanguageEntity Language { get; set; }
    }
}