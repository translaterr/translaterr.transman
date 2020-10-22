using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Translaterr.Transman.Abstractions.Services
{
    public interface ITranslationCacheManager
    {
        public Task<bool> SaveTranslationsToCache(Guid applicationId, string languageCode, IDictionary<string, string> translations, CancellationToken cancellationToken);
        public Task<IDictionary<string, string>> GetTranslationsFromCache(Guid applicationId, string languageCode, CancellationToken cancellationToken);
    }
}