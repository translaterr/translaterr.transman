using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Translaterr.Transman.Data.Entities
{
    [Table("Translations")]
    public class TranslationEntity
    {
        [Key]
        public int Id { get; set; }
        
        public ApplicationEntity Application { get; set; }
        
        public LanguageEntity Language {get; set; }
        
        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(255)]
        public string Key { get; set; }
        
        [Required]
        public string Value { get; set; }
    }
}