using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Translaterr.Transman.Api.DTOs.Tenants;
using Translaterr.Transman.Api.Models;
using Translaterr.Transman.Domain.Data;
using Translaterr.Transman.Domain.Types;

namespace Translaterr.Transman.Api.Controllers
{
    [Route("api/tenants")]
    public class TenantsController : BaseController
    {
        private readonly ILogger<TenantsController> _logger;
        private readonly AppDbContext _appDbContext;
        
        public TenantsController(ILogger<TenantsController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var tenants = await _appDbContext
                .Tenants
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return Ok(tenants.Select(tenant => new TenantModel(tenant)).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Create(TenantsCreateRequest request, CancellationToken cancellationToken)
        {
            var tenant = new Tenant
            {
                Name = request.Name,
                PublicId = Guid.NewGuid()
            };

            _appDbContext.Tenants.Add(tenant);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return Ok(new TenantModel(tenant));
        }

        [HttpPatch("{publicId}")]
        public async Task<IActionResult> Update(Guid publicId, TenantsUpdateRequest request, CancellationToken cancellationToken)
        {
            var tenant = await _appDbContext
                .Tenants
                .FirstOrDefaultAsync(t => t.PublicId == publicId, cancellationToken);

            if (tenant == null)
            {
                return NotFound();
            }

            tenant.Name = request.Name;
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return NoContent();
        }

        [HttpDelete("{publicId}")]
        public async Task<IActionResult> Delete(Guid publicId, CancellationToken cancellationToken)
        {
            var tenant = await _appDbContext
                .Tenants
                .FirstOrDefaultAsync(t => t.PublicId == publicId, cancellationToken);

            if (tenant == null)
            {
                return NotFound();
            }

            _appDbContext.Tenants.Remove(tenant);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return Ok();
        }
    }
}