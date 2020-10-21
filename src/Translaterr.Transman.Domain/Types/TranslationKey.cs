using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Translaterr.Transman.Domain.Types
{
    [Table("TranslationKeys")]
    public class TranslationKey
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public Guid PublicId { get; set; }

        [Required]
        public int ApplicationId { get; set; }
        public Application Application { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string Key { get; set; }
        
        public ICollection<TranslationValue> TranslationValues { get; set; }
    }
}