using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Translaterr.Transman.Abstractions.Services;

namespace Translaterr.Transman.Domain.Services
{
    /*
    public class ApplicationTranslationManager : IApplicationTranslationManager
    {
        private readonly ILogger<ApplicationTranslationManager> _logger;
        private readonly TranslationsDbContext _translationsDbContext;
        private readonly ITranslationCacheManager _cacheManager;

        
        public ApplicationTranslationManager(ILogger<ApplicationTranslationManager> logger, TranslationsDbContext translationsDbContext, ITranslationCacheManager cacheManager)
        {
            _logger = logger;
            _translationsDbContext = translationsDbContext;
            _cacheManager = cacheManager;
        }

        public async Task<IDictionary<string, string>> GenerateTranslationsForApplicationInLanguage(Guid applicationPublicId, string languageCode, CancellationToken cancellationToken)
        {
            var application = await _appDbContext
                .Applications
                .Include(a => a.TranslationKeys)
                .ThenInclude(tk => tk.TranslationValues)
                .FirstOrDefaultAsync(a => a.PublicId == applicationPublicId, cancellationToken);

            if (application == null)
            {
                _logger.LogError("Unable to find application by {publicId}", applicationPublicId.ToString());
                return null;
            }

            var translationKeys = application.TranslationKeys;

            var dictionary = translationKeys
                .Select(tk => tk.Key)
                .ToDictionary(key => key, key => key);

            foreach (var entry in dictionary)
            {
                var translationKey = translationKeys.First(tk => tk.Key == entry.Key);

                var requestedLanguageString = translationKey
                    .TranslationValues
                    .FirstOrDefault(tk => tk.LanguageCode == languageCode);

                if (requestedLanguageString != null)
                {
                    dictionary[entry.Key] = requestedLanguageString.Value;
                    continue;
                }
                
                var fallbackLanguageString = translationKey
                    .TranslationValues
                    .FirstOrDefault(tk => tk.LanguageCode == application.FallbackLanguage);

                if (fallbackLanguageString != null)
                {
                    dictionary[entry.Key] = fallbackLanguageString.Value;
                    continue;
                }
            }

            return dictionary;
        }

        public async Task<bool> GenerateTranslationsForApplicationAndSaveToCache(Guid applicationPublicId, CancellationToken cancellationToken)
        {
            var application = await _appDbContext
                .Applications
                .Include(a => a.TranslationKeys)
                .ThenInclude(tk => tk.TranslationValues)
                .FirstOrDefaultAsync(a => a.PublicId == applicationPublicId, cancellationToken);

            if (application == null)
            {
                _logger.LogError("Unable to find application {applicationPublicId}", applicationPublicId.ToString());
                return false;
            }

            var distinctLanguages = application.TranslationKeys
                .SelectMany(tk => tk.TranslationValues)
                .Select(tv => tv.LanguageCode)
                .Distinct()
                .ToList();

            foreach (var language in distinctLanguages)
            {
                var translations = await GenerateTranslationsForApplicationInLanguage(applicationPublicId, language, cancellationToken);

                if (!await _cacheManager.SaveTranslationsToCache(applicationPublicId, language, translations, cancellationToken))
                {
                    _logger.LogError("Unable to store generated translation to cache");
                    return false;
                }
            }

            return true;
        }

        public async Task<IDictionary<string, string>> GetTranslations(Guid applicationPublicId, string languageCode, CancellationToken cancellationToken)
        {
            var translationsFromCache = await _cacheManager.GetTranslationsFromCache(applicationPublicId, languageCode, cancellationToken);

            if (translationsFromCache != null)
            {
                return translationsFromCache;
            }

            return await GenerateTranslationsForApplicationInLanguage(applicationPublicId, languageCode, cancellationToken);
        }
    }
    */
}