using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Translaterr.Transman.Abstractions.Repositories;
using Translaterr.Transman.Abstractions.Services;
using Translaterr.Transman.Abstractions.Types;

namespace Translaterr.Transman.Domain.Services
{
    public class TranslationsService : ITranslationsService
    {
        private readonly ILogger<TranslationsService> _logger;
        private readonly ITranslationsRepository _translationsRepository;

        public TranslationsService(ILogger<TranslationsService> logger, ITranslationsRepository translationsRepository)
        {
            _logger = logger;
            _translationsRepository = translationsRepository;
        }

        public async Task<IList<ITranslation>> GetTranslations(Guid applicationId, CancellationToken cancellationToken = default)
        {
            return await _translationsRepository.Get(applicationId, cancellationToken);
        }

        public async Task<ITranslation> AddTranslation(ITranslation translation, CancellationToken cancellationToken = default)
        {
            return await _translationsRepository.Add(translation, cancellationToken);
        }

        public async Task<ITranslation> UpdateTranslation(ITranslation translation, CancellationToken cancellationToken = default)
        {
            return await _translationsRepository.Update(translation, cancellationToken);
        }

        public async Task<bool> DeleteTranslation(ITranslation translation, CancellationToken cancellationToken = default)
        {
            return await _translationsRepository.Delete(translation, cancellationToken);
        }
    }
}