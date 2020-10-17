using System;
using System.Text.Json.Serialization;
using Translaterr.Transman.Domain.Types;

namespace Translaterr.Transman.Api.Models
{
    public class ApplicationModel
    {
        [JsonPropertyName("publicId")]
        public Guid PublicId { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        public ApplicationModel(Application application)
        {
            PublicId = application.PublicId;
            Name = application.Name;
        }
    }
}