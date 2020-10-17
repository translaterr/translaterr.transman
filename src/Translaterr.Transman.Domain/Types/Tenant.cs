using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Translaterr.Transman.Domain.Types
{
    [Table("Tenants")]
    public class Tenant
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public Guid PublicId { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public ICollection<Application> Applications { get; set; } = new List<Application>();
    }
}