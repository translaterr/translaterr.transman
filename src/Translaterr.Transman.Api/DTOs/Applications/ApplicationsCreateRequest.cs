using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Translaterr.Transman.Api.DTOs.Applications
{
    public class ApplicationsCreateRequest
    {
        [JsonPropertyName("name")]
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
    }
}