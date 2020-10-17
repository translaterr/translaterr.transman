using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Translaterr.Transman.Domain.Types
{
    public class Environment
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public Guid PublicId { get; set; }
        
        [Required]
        public int ApplicationId { get; set; }
        public Application Application { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public ICollection<Translation> Translations { get; set; }
    }
}