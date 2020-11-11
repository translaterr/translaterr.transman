using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Translaterr.Transman.Api.DTOs.Applications;
using Translaterr.Transman.Api.Models;
using Translaterr.Transman.Domain.Data;
using Translaterr.Transman.Domain.Types;

namespace Translaterr.Transman.Api.Controllers
{
    [Route("api/{tenantId}/applications")]
    public class ApplicationsController : BaseController
    {
        private readonly ILogger<ApplicationsController> _logger;
        private readonly AppDbContext _appDbContext;

        public ApplicationsController(ILogger<ApplicationsController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index(Guid tenantId, CancellationToken cancellationToken)
        {
            var tenant = await _appDbContext.Tenants
                .Include(t => t.Applications)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.PublicId == tenantId, cancellationToken);

            if (tenant == null)
            {
                return NotFound();
            }

            return Ok(tenant.Applications.Select(application => new ApplicationModel(application)).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Guid tenantId, ApplicationsCreateRequest request, CancellationToken cancellationToken)
        {
            var tenant = await _appDbContext.Tenants
                .FirstOrDefaultAsync(t => t.PublicId == tenantId, cancellationToken);

            if (tenant == null)
            {
                return NotFound();
            }
            
            var application = new Application
            {
                TenantId = tenant.Id,
                Name = request.Name,
            };

            _appDbContext.Applications.Add(application);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            
            return Ok(new ApplicationModel(application));
        }

        [HttpPatch("{applicationId}")]
        public async Task<IActionResult> Update(Guid tenantId, Guid applicationId, ApplicationsUpdateRequest request, CancellationToken cancellationToken)
        {
            var tenant = await _appDbContext.Tenants
                .Include(t => t.Applications)
                .FirstOrDefaultAsync(t => t.PublicId == tenantId, cancellationToken);

            if (tenant == null)
            {
                return NotFound();
            }

            var application = tenant.Applications.FirstOrDefault(a => a.PublicId == applicationId);

            if (application == null)
            {
                return NotFound();
            }

            application.Name = request.Name;
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return NoContent();
        }

        [HttpDelete("{applicationId}")]
        public async Task<IActionResult> Delete(Guid tenantId, Guid applicationId, CancellationToken cancellationToken)
        {
            var tenant = await _appDbContext.Tenants
                .Include(t => t.Applications)
                .FirstOrDefaultAsync(t => t.PublicId == tenantId, cancellationToken);

            if (tenant == null)
            {
                return NotFound();
            }

            var application = tenant.Applications.FirstOrDefault(a => a.PublicId == applicationId);

            if (application == null)
            {
                return NotFound();
            }

            _appDbContext.Applications.Remove(application);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return Ok();
        }
    }
}