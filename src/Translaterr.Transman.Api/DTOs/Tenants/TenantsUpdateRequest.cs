using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Translaterr.Transman.Api.DTOs.Tenants
{
    public class TenantsUpdateRequest
    {
        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; }
    }
}