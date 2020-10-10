using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Translaterr.Transman.Abstractions.Types;

namespace Translaterr.Transman.Data.Entities
{
    public class EnvironmentEntity : IEntity<IEnvironment>
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public Guid PublicId { get; set; }
        
        [Required]
        public int ApplicationId { get; set; }
        public ApplicationEntity Application { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public ICollection<TranslationEntity> Translations { get; set; }

        public static EnvironmentEntity FromDomain(IEnvironment environment)
        {
            return new EnvironmentEntity()
            {
                Id = environment.Id,
                PublicId = environment.PublicId,
                ApplicationId = environment.ApplicationId,
                Name = environment.Name,
            };
        }

        public IEnvironment ToDomain()
        {
            return new Domain.Types.Environment()
            {
                Id = Id,
                PublicId = PublicId,
                ApplicationId = ApplicationId,
                Name = Name,
            };
        }
    }
}