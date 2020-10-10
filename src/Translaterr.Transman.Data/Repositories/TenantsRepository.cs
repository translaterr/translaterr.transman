using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Translaterr.Transman.Abstractions.Repositories;
using Translaterr.Transman.Abstractions.Types;
using Translaterr.Transman.Data.Contexts;
using Translaterr.Transman.Data.Entities;

namespace Translaterr.Transman.Data.Repositories
{
    public class TenantsRepository : ITenantsRepository
    {
        private readonly ILogger<TenantsRepository> _logger;
        private readonly AppDbContext _appDbContext;

        public TenantsRepository(ILogger<TenantsRepository> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        public async Task<IList<ITenant>> GetAll(CancellationToken cancellationToken)
        {
            var tenants = await _appDbContext.Tenants.ToListAsync(cancellationToken);

            return tenants.Select(t => t.ToDomain()).ToList();
        }

        public async Task<ITenant> FindById(int id, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Tenants.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

            if (entity == null)
            {
                _logger.LogWarning("Unable to find Tenant by id, with an Id of {id}", id.ToString());
                return null;
            }

            return entity.ToDomain();
        }
        
        public async Task<ITenant> FindByPublicId(Guid publicId, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Tenants.FirstOrDefaultAsync(
                t => t.PublicId == publicId, 
                cancellationToken);

            if (entity == null)
            {
                _logger.LogWarning("Unable to find Tenant by publicId, with an publicId of {publicId}", publicId.ToString());
                return null;
            }

            return entity.ToDomain();
        }

        public void Add(ITenant tenant)
        {
            var entity = TenantEntity.FromDomain(tenant);
            _appDbContext.Tenants.Add(entity);
            _logger.LogDebug("Added new tenant with name {name} and {publicId}", entity.Name, entity.PublicId.ToString());
        }

        public void Update(ITenant tenant)
        {
            var entity = TenantEntity.FromDomain(tenant);
            _appDbContext.Tenants.Update(entity);
            _logger.LogDebug("Updated tenant with name {name} and {publicId}", entity.Name, entity.PublicId.ToString());
        }

        public void Delete(ITenant tenant)
        {
            var entity = TenantEntity.FromDomain(tenant);
            _appDbContext.Tenants.Remove(entity);
            _logger.LogDebug("Deleted tenant with name {name} and {publicId}", entity.Name, entity.PublicId.ToString());
        }
    }
}