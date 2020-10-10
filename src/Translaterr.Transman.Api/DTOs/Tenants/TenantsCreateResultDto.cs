using System.Text.Json.Serialization;
using Translaterr.Transman.Abstractions.Types;
using Translaterr.Transman.Api.Models;

namespace Translaterr.Transman.Api.DTOs.Tenants
{
    public class TenantsCreateResultDto
    {
        [JsonPropertyName("tenant")]
        public TenantModel Tenant { get; set; }

        public TenantsCreateResultDto(ITenant tenant)
        {
            Tenant = new TenantModel(tenant);
        }
    }
}