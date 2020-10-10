using Translaterr.Transman.Abstractions.ServiceResults.Tenants;
using Translaterr.Transman.Abstractions.Types;

namespace Translaterr.Transman.Services.ServiceResults.Tenants
{
    public class DeleteTenantResult : IDeleteTenantResult
    {
        public ITenant Data { get; set; }
        public TenantResults Type { get; set; }
        
        public static DeleteTenantResult TenantNotFound() => new DeleteTenantResult()
        {
            Data = null,
            Type = TenantResults.NoTenantFound,
        };
        
        public static DeleteTenantResult UnableToDelete() => new DeleteTenantResult()
        {
            Data = null,
            Type = TenantResults.DatabaseError,
        };
        
        public static DeleteTenantResult SuccessfullyDeleted(ITenant tenant) => new DeleteTenantResult()
        {
            Data = tenant,
            Type = TenantResults.NoTenantFound,
        };
    }
}