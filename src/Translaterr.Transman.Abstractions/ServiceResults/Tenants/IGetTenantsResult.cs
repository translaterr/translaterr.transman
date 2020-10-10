using System.Collections.Generic;
using Translaterr.Transman.Abstractions.Types;

namespace Translaterr.Transman.Abstractions.ServiceResults.Tenants
{
    public interface IGetTenantsResult : IServiceResult<IList<ITenant>, TenantResults> {}
}