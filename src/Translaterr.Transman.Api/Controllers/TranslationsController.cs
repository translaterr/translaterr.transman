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
    [Route("api/applications/{applicationId}/translations")]
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
        public async Task<IActionResult> Index(Guid applicationId, CancellationToken cancellationToken)
        {
            var application = await _appDbContext
                .Applications
                .Include(a => a.TranslationKeys)
                .ThenInclude(tk => tk.TranslationValues)
                .FirstOrDefaultAsync(a => a.PublicId == applicationId, cancellationToken);

            if (application == null)
            {
                _logger.LogDebug(
                    "Unable to find any application by {applicationPublicId}", 
                    applicationId.ToString()
                );
                return NotFound();
            }

            return Ok(application.TranslationKeys.Select(translation => new TranslationKeyModel(translation)).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Guid applicationId, TranslationsCreateRequest request, CancellationToken cancellationToken)
        {
            var application = await _appDbContext.Applications.FirstOrDefaultAsync(a => a.PublicId == applicationId, cancellationToken);

            if (application == null)
            {
                _logger.LogDebug(
                    "Unable to find any application by {applicationPublicId}", 
                    applicationId.ToString()
                );
                return NotFound();
            }
            
            var translationKey = new TranslationKey()
            {
                PublicId = Guid.NewGuid(),
                ApplicationId = application.Id,
                Key = request.Key,
            };
            _appDbContext.TranslationKeys.Add(translationKey);

            var translationValues = request.Values.Select(tv => new TranslationValue
            {
                TranslationKey = translationKey,
                LanguageCode = tv.LanguageCode,
                Value = tv.Value
            });
            _appDbContext.TranslationValues.AddRange(translationValues);

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return Ok(new TranslationKeyModel(translationKey));
        }
    }
}