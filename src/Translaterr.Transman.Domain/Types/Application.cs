using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Translaterr.Transman.Domain.Types
{
    [Table("Applications")]
    public class Application
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public Guid PublicId { get; set; }
        
        [Required]
        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public string FallbackLanguage { get; set; }
        public ICollection<Translation> Translations { get; set; }
        public ICollection<Environment> Environments { get; set; }
    }
}