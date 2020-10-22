using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Translaterr.Transman.Abstractions.Services;

namespace Translaterr.Transman.Domain.Services
{
    public class TranslationCacheManager : ITranslationCacheManager
    {
        private readonly ILogger<TranslationCacheManager> _logger;
        private readonly IDistributedCache _cache;
        private readonly DistributedCacheEntryOptions _options;

        public TranslationCacheManager(ILogger<TranslationCacheManager> logger, IDistributedCache cache, DistributedCacheEntryOptions options)
        {
            _logger = logger;
            _cache = cache;
            _options = options;
        }

        public async Task<bool> SaveTranslationsToCache(Guid applicationId, string languageCode, IDictionary<string, string> translations, CancellationToken cancellationToken)
        {
            string payload;
            try
            {
                payload = JsonSerializer.Serialize(translations);
            }
            catch (Exception exception)
            {
                _logger.LogCritical(exception, "An error occurred when trying to serialize payload for {applicationId} for {languageCode}", 
                    applicationId.ToString(), 
                    languageCode
                );
                return false;
            }
            
            var cacheKey = GetCacheKey(applicationId, languageCode);

            try
            {
                await _cache.SetStringAsync(cacheKey, payload, _options, cancellationToken);
            }
            catch (Exception exception)
            {
                _logger.LogCritical(exception, "An error occurred when trying to save payload to cache for {applicationId} for {languageCode}", 
                    applicationId.ToString(), languageCode);
                return false;
            }

            return true;
        }

        public async Task<IDictionary<string, string>> GetTranslationsFromCache(Guid applicationId, string languageCode, CancellationToken cancellationToken)
        {
            var cacheKey = GetCacheKey(applicationId, languageCode);
            var payload = await _cache.GetStringAsync(cacheKey, cancellationToken);

            if (payload == null)
            {
                _logger.LogDebug("Unable to find any value in cache for {applicationId} for {languageCode} with {cacheKey}", 
                    applicationId.ToString(), languageCode, cacheKey);
                return null;
            }

            Dictionary<string, string> translations;
            
            try
            {
                translations = JsonSerializer.Deserialize<Dictionary<string, string>>(payload);
            }
            catch (Exception exception)
            {
                _logger.LogCritical(exception, "An error occurred when trying to deserialize payload for {applicationId} for {languageCode} with {cacheKey}", 
                    applicationId.ToString(), 
                    languageCode);
                return null;
            }

            return translations;
        }

        private static string GetCacheKey(Guid applicationId, string languageCode) => $"translations-{applicationId.ToString()}-{languageCode}";
    }
}