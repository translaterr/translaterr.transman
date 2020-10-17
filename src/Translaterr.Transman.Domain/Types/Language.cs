using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Translaterr.Transman.Domain.Types
{
    [Table("Languages")]
    public class Language
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(10)]
        public string IsoCode { get; set; }
        
        public ICollection<Translation> Translations { get; set; }
        
        public ICollection<ApplicationLanguage> ApplicationLanguages { get; set; }
        public ICollection<Application> DefaultApplications { get; set; }
    }
}