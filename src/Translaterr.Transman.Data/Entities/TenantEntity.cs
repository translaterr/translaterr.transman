using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Translaterr.Transman.Abstractions.Types;
using Translaterr.Transman.Domain.Types;

namespace Translaterr.Transman.Data.Entities
{
    [Table("Tenants")]
    public class TenantEntity : IEntity<ITenant>
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public Guid PublicId { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public ICollection<ApplicationEntity> Applications { get; set; } = new List<ApplicationEntity>();

        public static TenantEntity FromDomain(ITenant tenant)
        {
            return new TenantEntity()
            {
                Id = tenant.Id,
                Name = tenant.Name,
                PublicId = tenant.PublicId,
            };
        }
        
        public ITenant ToDomain()
        {
            return new Tenant()
            {
                Id = Id,
                PublicId = PublicId,
                Name = Name,
            };
        }
    }
}