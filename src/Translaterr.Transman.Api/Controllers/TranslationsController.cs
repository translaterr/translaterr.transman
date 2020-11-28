using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Translaterr.Transman.Abstractions.Services;
using Translaterr.Transman.Abstractions.Types;
using Translaterr.Transman.Api.DTOs.Translations;
using Translaterr.Transman.Api.Models;

namespace Translaterr.Transman.Api.Controllers
{
    [Route("api/{applicationId}/translations")]
    public class TranslationsController : BaseController
    {
        private readonly ILogger<TranslationsController> _logger;
        private readonly ITranslationsService _translationsService;
        

        public TranslationsController(ILogger<TranslationsController> logger, ITranslationsService translationsService)
        {
            _logger = logger;
            _translationsService = translationsService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<TranslationModel>>> Index(Guid applicationId, CancellationToken cancellationToken)
        {
            var translations = await _translationsService.GetTranslations(applicationId, cancellationToken);
            return translations.Select(translation => new TranslationModel(translation)).ToList();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Guid applicationId, TranslationModel translationModel, CancellationToken cancellationToken)
        {
            var translation = translationModel.ToDomain(applicationId);
            await _translationsService.AddTranslation(translation, cancellationToken);

            return Ok();
        }
        

        [HttpPut("{translationId}")]
        public async Task<IActionResult> Update(Guid applicationId, Guid translationId, TranslationsUpdateRequest request, CancellationToken cancellationToken)
        {
            var translation = new Translation(translationId, applicationId)
            {
                Key = request.Key,
                Description = request.Description,
                DefaultValue = request.DefaultValue,
                Translations = request.Translations.Select(t => t.ToDomain()).ToList()
            };

            await _translationsService.UpdateTranslation(translation, cancellationToken);

            return Ok();
        }

        [HttpDelete("{translationId}")]
        public async Task<IActionResult> Delete(Guid applicationId, Guid translationId, CancellationToken cancellationToken)
        {
            var translation = new Translation(applicationId, translationId);

            await _translationsService.DeleteTranslation(translation, cancellationToken);

            return Ok();
        }
    }
}