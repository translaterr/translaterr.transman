using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Translaterr.Transman.Domain.Types
{
    [Table("TranslationValue")]
    public class TranslationValue
    {
        [Required]
        public int TranslationKeyId { get; set; }
        public TranslationKey TranslationKey { get; set; }
        
        [Required]
        public string LanguageCode { get; set; }
        
        [Required]
        public string Value { get; set; }
    }
}