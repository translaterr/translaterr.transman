using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Translaterr.Transman.Data.Entities
{
    [Table("Languages")]
    public class LanguageEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        [Column(TypeName = "CHAR")]
        [StringLength(2)]
        public string IsoCode { get; set; }
        
        public ICollection<TranslationEntity> Translations { get; set; }
        
        public ICollection<ApplicationLanguageEntity> ApplicationLanguages { get; set; }
        public ICollection<ApplicationEntity> DefaultApplications { get; set; }
    }
}