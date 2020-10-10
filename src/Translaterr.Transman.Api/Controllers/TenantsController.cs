using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Translaterr.Transman.Abstractions.ServiceResults.Tenants;
using Translaterr.Transman.Abstractions.Services;
using Translaterr.Transman.Api.DTOs.Tenants;

namespace Translaterr.Transman.Api.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/tenants")]
    public class TenantsController : BaseController
    {
        private readonly ILogger<TenantsController> _logger;
        private readonly ITenantsService _tenantsService;
        
        public TenantsController(ILogger<TenantsController> logger, ITenantsService tenantsService)
        {
            _logger = logger;
            _tenantsService = tenantsService;
        }

        [HttpGet]
        public async Task<ActionResult<TenantsIndexResultDto>> Index(CancellationToken cancellationToken)
        {
            var tenantsResult = await _tenantsService.GetTenants(cancellationToken);

            if (tenantsResult.Type != TenantResults.Success)
            {
                _logger.LogError("Unable to retrieve all tenants");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(new TenantsIndexResultDto(tenantsResult.Data));
        }

        [HttpPost]
        public async Task<ActionResult<TenantsCreateResultDto>> Create(TenantsCreateRequestDto request, CancellationToken cancellationToken)
        {
            var tenantsCreationResult = await _tenantsService.CreateTenant(request.Name, cancellationToken);

            if (tenantsCreationResult.Type != TenantResults.Success)
            {
                _logger.LogError("Unable to create new tenant");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(new TenantsCreateResultDto(tenantsCreationResult.Data));
        }

        [HttpPatch("{publicId}")]
        public async Task<ActionResult> Update(Guid publicId, TenantsUpdateRequestDto request, CancellationToken cancellationToken)
        {
            var tenantsUpdateResult = await _tenantsService.RenameTenant(publicId, request.Name, cancellationToken);

            if (tenantsUpdateResult.Type == TenantResults.NoTenantFound)
            {
                return NotFound();
            }

            if (tenantsUpdateResult.Type != TenantResults.Success)
            {
                _logger.LogError("Unable to update tenant with {publicId}", publicId.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        [HttpDelete("{publicId}")]
        public async Task<ActionResult> Delete(Guid publicId, CancellationToken cancellationToken)
        {
            var tenantsDeleteResult = await _tenantsService.DeleteTenant(publicId, cancellationToken);

            if (tenantsDeleteResult.Type == TenantResults.NoTenantFound)
            {
                return NotFound();
            }

            if (tenantsDeleteResult.Type != TenantResults.Success)
            {
                _logger.LogError("Unable to delete tenant with {publicId}", publicId.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }
    }
}