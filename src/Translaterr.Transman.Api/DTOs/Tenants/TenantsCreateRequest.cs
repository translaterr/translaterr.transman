using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Translaterr.Transman.Api.DTOs.Tenants
{
    public class TenantsCreateRequest
    {
        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; }
    }
}