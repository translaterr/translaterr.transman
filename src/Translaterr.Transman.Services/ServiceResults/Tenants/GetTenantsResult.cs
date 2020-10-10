using System.Collections.Generic;
using Translaterr.Transman.Abstractions.ServiceResults.Tenants;
using Translaterr.Transman.Abstractions.Types;

namespace Translaterr.Transman.Services.ServiceResults.Tenants
{
    public class GetTenantsResult : IGetTenantsResult
    {
        public IList<ITenant> Data { get; set; }
        public TenantResults Type { get; set; }

        public static GetTenantsResult Success(IList<ITenant> tenants) => new GetTenantsResult()
        {
            Data = tenants,
            Type = TenantResults.Success,
        };
    }
}