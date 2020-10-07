using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Translaterr.Transman.Data.Entities
{
    [Table("Tenants")]
    public class TenantEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public Guid PublicId { get; set; } = Guid.NewGuid();
        
        [Required]
        public string Name { get; set; }
        
        public ICollection<ApplicationEntity> Applications { get; set; }
    }
}