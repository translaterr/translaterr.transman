using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Translaterr.Transman.Abstractions.Types;
using Translaterr.Transman.Api.Models;

namespace Translaterr.Transman.Api.DTOs.Tenants
{
    public class TenantsIndexResultDto
    {
        [JsonPropertyName("tenants")]
        public IList<TenantModel> Tenants { get; set; }

        public TenantsIndexResultDto(IList<ITenant> tenants)
        {
            Tenants = tenants.Select(tenant => new TenantModel(tenant)).ToList();
        }
    }
}