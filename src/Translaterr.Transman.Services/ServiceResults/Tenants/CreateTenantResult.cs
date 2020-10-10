using Translaterr.Transman.Abstractions.ServiceResults.Tenants;
using Translaterr.Transman.Abstractions.Types;

namespace Translaterr.Transman.Services.ServiceResults.Tenants
{
    public class CreateTenantResult : ICreateTenantResult
    {
        public ITenant Data { get; set; }
        public TenantResults Type { get; set; }
        
        public static CreateTenantResult UnableToCreate() => new CreateTenantResult()
        {
            Data = null,
            Type = TenantResults.DatabaseError,
        };
        
        public static CreateTenantResult Success(ITenant tenant) => new CreateTenantResult()
        {
            Data = tenant,
            Type = TenantResults.Success,
        };
    }
}