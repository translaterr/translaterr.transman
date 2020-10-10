using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Translaterr.Transman.Data.Entities
{
    [Table("Translations")]
    public class TranslationEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public Guid PublicId { get; set; }

        [Required]
        public int ApplicationId { get; set; }
        public ApplicationEntity Application { get; set; }
        
        [Required]
        public int LanguageId { get; set; }
        public LanguageEntity Language {get; set; }
        
        public int EnvironmentId { get; set; }
        public EnvironmentEntity Environment { get; set; }
        
        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(255)]
        public string Key { get; set; }
        
        [Required]
        public string Value { get; set; }
    }
}