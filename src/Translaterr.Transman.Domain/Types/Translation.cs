using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Translaterr.Transman.Domain.Types
{
    [Table("Translations")]
    public class Translation
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public Guid PublicId { get; set; }

        [Required]
        public int ApplicationId { get; set; }
        public Application Application { get; set; }
        
        [Required]
        public string LanguageCode {get; set; }
        
        public int EnvironmentId { get; set; }
        public Environment Environment { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string Key { get; set; }
        
        [Required]
        public string Value { get; set; }
    }
}