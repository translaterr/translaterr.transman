using System;
using System.Threading;
using System.Threading.Tasks;
using Translaterr.Transman.Abstractions.ServiceResults.Tenants;

namespace Translaterr.Transman.Abstractions.Services
{
    public interface ITenantsService
    {
        public Task<IGetTenantsResult> GetTenants(CancellationToken cancellationToken);
        public Task<IFindTenantResult> FindTenant(int tenantId, CancellationToken cancellationToken);
        public Task<IFindTenantResult> FindByPublicId(Guid publicId, CancellationToken cancellationToken);
        public Task<ICreateTenantResult> CreateTenant(string name, CancellationToken cancellationToken);
        public Task<IUpdateTenantResult> RenameTenant(Guid publicId, string name, CancellationToken cancellationToken);
        public Task<IDeleteTenantResult> DeleteTenant(Guid publicId, CancellationToken cancellationToken);
    }
}