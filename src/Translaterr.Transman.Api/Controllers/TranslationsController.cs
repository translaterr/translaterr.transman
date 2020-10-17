using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Translaterr.Transman.Api.DTOs.Translations;
using Translaterr.Transman.Api.Models;
using Translaterr.Transman.Domain.Data;
using Translaterr.Transman.Domain.Types;

namespace Translaterr.Transman.Api.Controllers
{
    [Route("api/tenants/{tenantId}/applications/{applicationId}/translations")]
    public class TranslationsController : BaseController
    {
        private readonly ILogger<TranslationsController> _logger;
        private readonly AppDbContext _appDbContext;

        public TranslationsController(ILogger<TranslationsController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index(Guid tenantId, Guid applicationId, CancellationToken cancellationToken)
        {
            var tenant = await _appDbContext
                .Tenants
                .Include(t => t.Applications)
                .FirstOrDefaultAsync(t => t.PublicId == tenantId, cancellationToken);

            if (tenant == null)
            {
                _logger.LogDebug("Unable to find any tenant by {publicId}", tenantId.ToString());
                return NotFound();
            }

            var application = tenant.Applications.FirstOrDefault(a => a.PublicId == applicationId);

            if (application == null)
            {
                _logger.LogDebug(
                    "Unable to find any application by {applicationPublicId} for {tenantId}", 
                    applicationId.ToString(), 
                    tenant.Id.ToString()
                );
                return NotFound();
            }

            var translations = await _appDbContext
                .Translations
                .Include(t => t.Environment)
                .Where(t => t.ApplicationId == application.Id)
                .ToListAsync(cancellationToken);

            return Ok(translations.Select(translation => new TranslationModel(translation)).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Guid tenantId, Guid applicationId, TranslationsCreateRequest request, CancellationToken cancellationToken)
        {
            var tenant = await _appDbContext
                .Tenants
                .Include(t => t.Applications)
                .FirstOrDefaultAsync(t => t.PublicId == tenantId, cancellationToken);

            if (tenant == null)
            {
                _logger.LogDebug("Unable to find any tenant by {publicId}", tenantId.ToString());
                return NotFound();
            }

            var application = tenant.Applications.FirstOrDefault(a => a.PublicId == applicationId);

            if (application == null)
            {
                _logger.LogDebug(
                    "Unable to find any application by {applicationPublicId} for {tenantId}", 
                    applicationId.ToString(), 
                    tenant.Id.ToString()
                );
                return NotFound();
            }
            
            var translation = new Translation()
            {
                PublicId = Guid.NewGuid(),
                ApplicationId = application.Id,
                Key = request.Key,
                LanguageCode = request.LanguageCode,
                Value = request.Value,
            };
            _appDbContext.Translations.Add(translation);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return Ok(new TranslationModel(translation));
        }
    }
}