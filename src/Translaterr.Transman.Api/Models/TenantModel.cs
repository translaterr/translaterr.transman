using System;
using System.Text.Json.Serialization;
using Translaterr.Transman.Abstractions.Types;

namespace Translaterr.Transman.Api.Models
{
    public class TenantModel
    {
        [JsonPropertyName("publicId")]
        public Guid PublicId { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        public TenantModel(ITenant tenant)
        {
            PublicId = tenant.PublicId;
            Name = tenant.Name;
        }
    }
}