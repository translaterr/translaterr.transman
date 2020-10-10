using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Translaterr.Transman.Abstractions.Data;
using Translaterr.Transman.Abstractions.ServiceResults.Tenants;
using Translaterr.Transman.Abstractions.Services;
using Translaterr.Transman.Domain.Types;
using Translaterr.Transman.Services.ServiceResults.Tenants;

namespace Translaterr.Transman.Services.Services
{
    public class TenantsService : ITenantsService
    {
        private readonly ILogger<TenantsService> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public TenantsService(ILogger<TenantsService> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IGetTenantsResult> GetTenants(CancellationToken cancellationToken)
        {
            using (_logger.BeginScope("TenantsService.GetTenants"))
            {
                _logger.LogDebug("Attempting to retrieve all tenants");

                var tenants = await _unitOfWork.TenantsRepository.GetAll(cancellationToken);
                
                return GetTenantsResult.Success(tenants);
            }
        }

        public async Task<IFindTenantResult> FindTenant(int tenantId, CancellationToken cancellationToken)
        {
            using (_logger.BeginScope("TenantsService.FindTenant"))
            {
                _logger.LogDebug("Attempting to find tenant by id {tenantId}", tenantId.ToString());

                var tenant = await _unitOfWork.TenantsRepository.FindById(tenantId, cancellationToken);

                if (tenant == null)
                {
                    _logger.LogDebug("Didn't find any tenant with id of {tenantId}", tenantId.ToString());
                    return FindTenantResult.NoResults();
                }
                
                _logger.LogDebug("Found tenant with id of {tenantId}", tenantId.ToString());
                return FindTenantResult.Found(tenant);
            }
        }

        public async Task<IFindTenantResult> FindByPublicId(Guid publicId, CancellationToken cancellationToken)
        {
            using (_logger.BeginScope("TenantsService.FindByPublicId"))
            {
                _logger.LogDebug("Attempting to find tenant by publicId {publicId}", publicId.ToString());

                var tenant = await _unitOfWork.TenantsRepository.FindByPublicId(publicId, cancellationToken);
                
                if (tenant == null)
                {
                    _logger.LogDebug("Didn't find any tenant with a publicId of {publicId}", publicId.ToString());
                    return FindTenantResult.NoResults();
                }
                
                _logger.LogDebug("Found tenant with a publicId of {publicId}", publicId.ToString());
                return FindTenantResult.Found(tenant);
            }
        }

        public async Task<ICreateTenantResult> CreateTenant(string name, CancellationToken cancellationToken)
        {
            using (_logger.BeginScope("TenantsService.CreateTenant"))
            {
                _logger.LogDebug("Attempting to create a new tenant with name of {name}", name);

                var tempTenant = new Tenant()
                {
                    Name = name,
                    PublicId = Guid.NewGuid()
                };

                _unitOfWork.TenantsRepository.Add(tempTenant);
                
                if (await _unitOfWork.SaveChanges(cancellationToken) == false)
                {
                    _logger.LogError("Unable to create the new tenant with name {name} and publicId {publicId}", tempTenant.Name, tempTenant.PublicId.ToString());
                    return CreateTenantResult.UnableToCreate();
                }
                
                _logger.LogDebug("Successfully created a new tenant {name}, {publicId}", tempTenant.Name, tempTenant.PublicId.ToString());

                var tenant = await _unitOfWork.TenantsRepository.FindByPublicId(tempTenant.PublicId, cancellationToken);
                return CreateTenantResult.Success(tenant);
            }
        }

        public async Task<IUpdateTenantResult> RenameTenant(Guid publicId, string name, CancellationToken cancellationToken)
        {
            using (_logger.BeginScope("TenantsService.RenameTenant"))
            {
                var tenant = await _unitOfWork.TenantsRepository.FindByPublicId(publicId, cancellationToken);

                if (tenant == null)
                {
                    _logger.LogWarning("Unable to find tenant {publicId}", publicId.ToString());
                    return UpdateTenantResult.TenantNotFound();
                }
                
                tenant.Name = name;
                _unitOfWork.TenantsRepository.Update(tenant);

                if (await _unitOfWork.SaveChanges(cancellationToken) == false)
                {
                    _logger.LogError("Unable to rename tenant {publicId} to {name}", publicId.ToString(), tenant.Name);
                    return UpdateTenantResult.UnableToUpdate();
                }
                
                _logger.LogDebug("Successfully renamed the tenant {publicId} to {name}", publicId.ToString(), name);
                return UpdateTenantResult.SuccessfullyRenamed(tenant);
            }
        }

        public async Task<IDeleteTenantResult> DeleteTenant(Guid publicId, CancellationToken cancellationToken)
        {
            using (_logger.BeginScope("TenantsService.DeleteTenant"))
            {
                var tenant = await _unitOfWork.TenantsRepository.FindByPublicId(publicId, cancellationToken);

                if (tenant == null)
                {
                    _logger.LogWarning("Unable to find tenant {id}", publicId.ToString());
                    return DeleteTenantResult.TenantNotFound();
                }
                
                _unitOfWork.TenantsRepository.Delete(tenant);

                if (await _unitOfWork.SaveChanges(cancellationToken) == false)
                {
                    _logger.LogError("Unable to delete tenant {id} {name}", publicId.ToString(), tenant.Name);
                    return DeleteTenantResult.UnableToDelete();
                }
                
                _logger.LogDebug("Successfully deleted the tenant {id} {name}", publicId.ToString(), tenant.Name);
                return DeleteTenantResult.SuccessfullyDeleted(tenant);
            }
        }
    }
}