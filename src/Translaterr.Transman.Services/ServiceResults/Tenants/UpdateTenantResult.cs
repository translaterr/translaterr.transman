using Translaterr.Transman.Abstractions.ServiceResults.Tenants;
using Translaterr.Transman.Abstractions.Types;

namespace Translaterr.Transman.Services.ServiceResults.Tenants
{
    public class UpdateTenantResult : IUpdateTenantResult
    {
        public ITenant Data { get; set; }
        public TenantResults Type { get; set; }
        
        public static UpdateTenantResult TenantNotFound() => new UpdateTenantResult()
        {
            Data = null,
            Type = TenantResults.NoTenantFound,
        };
        
        public static UpdateTenantResult UnableToUpdate() => new UpdateTenantResult()
        {
            Data = null,
            Type = TenantResults.DatabaseError,
        };
        
        public static UpdateTenantResult SuccessfullyRenamed(ITenant tenant) => new UpdateTenantResult()
        {
            Data = tenant,
            Type = TenantResults.Success,
        };
    }
}