using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Translaterr.Transman.Api.DTOs.Tenants
{
    public class TenantsCreateRequestDto
    {
        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; }
    }
}