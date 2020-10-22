using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Translaterr.Transman.Abstractions.Services
{
    public interface IApplicationTranslationManager
    {
        public Task<bool> GenerateTranslationsForApplicationAndSaveToCache(Guid applicationPublicId, CancellationToken cancellationToken);
        public Task<IDictionary<string, string>> GenerateTranslationsForApplicationInLanguage(Guid applicationPublicId, string languageCode, CancellationToken cancellationToken);
        public Task<bool> GetTranslations(Guid applicationPublicId, string languageCode, CancellationToken cancellationToken);
    }
}