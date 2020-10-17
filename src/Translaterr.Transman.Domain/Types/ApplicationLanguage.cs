using System.ComponentModel.DataAnnotations.Schema;

namespace Translaterr.Transman.Domain.Types
{
    [Table("ApplicationsLanguages")]
    public class ApplicationLanguage
    {
        public int ApplicationId { get; set; }
        public Application Application { get; set; }
        
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}