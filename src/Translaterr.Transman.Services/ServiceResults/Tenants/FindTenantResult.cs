using Translaterr.Transman.Abstractions.ServiceResults.Tenants;
using Translaterr.Transman.Abstractions.Types;

namespace Translaterr.Transman.Services.ServiceResults.Tenants
{
    public class FindTenantResult : IFindTenantResult
    {
        public ITenant Data { get; set; }
        public TenantResults Type { get; set; }
        
        public static FindTenantResult Found(ITenant tenant) => new FindTenantResult()
        {
            Data = tenant,
            Type = TenantResults.Success,
        };
        
        public static FindTenantResult NoResults() => new FindTenantResult()
        {
            Data = null,
            Type = TenantResults.NoTenantFound,
        };
    }
}