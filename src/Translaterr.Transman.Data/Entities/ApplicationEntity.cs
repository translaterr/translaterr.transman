using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Translaterr.Transman.Data.Entities
{
    [Table("Applications")]
    public class ApplicationEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public Guid PublicId { get; set; } = Guid.NewGuid();
        
        public TenantEntity Tenant { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public LanguageEntity FallbackLanguage { get; set; }
        
        public LanguageEntity DefaultLanguage { get; set; }
        public ICollection<ApplicationLanguageEntity> ApplicationLanguages { get; set; }
        public ICollection<TranslationEntity> Translations { get; set; }
    }
}