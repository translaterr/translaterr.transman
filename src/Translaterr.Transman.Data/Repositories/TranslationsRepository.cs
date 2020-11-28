using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Translaterr.Transman.Abstractions.Repositories;
using Translaterr.Transman.Abstractions.Types;
using Translaterr.Transman.Data.Entities;

namespace Translaterr.Transman.Data.Repositories
{
    public class TranslationsRepository : ITranslationsRepository
    {
        private const string CollectionName = "translations";
        
        private readonly ILogger<TranslationsRepository> _logger;

        private readonly IMongoCollection<TranslationEntity> _collection;
        
        public TranslationsRepository(ILogger<TranslationsRepository> logger, MongoClient client)
        {
            _logger = logger;
            
            var db = client.GetDatabase(Constants.DatabaseName);
            _collection = db.GetCollection<TranslationEntity>(CollectionName);
        }

        public async Task<IList<ITranslation>> Get(Guid applicationId, CancellationToken cancellationToken)
        {
            var translations = await _collection
                .Find(t => t.ApplicationId == applicationId)
                .ToListAsync(cancellationToken);
            return translations.Select(t => t.ToDomain()).ToList();
        }

        public async Task<ITranslation> Add(ITranslation translation, CancellationToken cancellationToken)
        {
            var translationEntity = new TranslationEntity(translation);
            await _collection.InsertOneAsync(translationEntity, null, cancellationToken);
            return translationEntity.ToDomain();
        }

        public async Task<ITranslation> Update(ITranslation translation, CancellationToken cancellationToken)
        {
            var translationEntity = new TranslationEntity(translation);
            await _collection.ReplaceOneAsync(t => t.Id == translation.Id, translationEntity, new ReplaceOptions(), cancellationToken);
            return translationEntity.ToDomain();
        }

        public async Task<bool> Delete(ITranslation translation, CancellationToken cancellationToken)
        {
            var result = await _collection.DeleteOneAsync(t => t.Id == translation.Id, cancellationToken);
            return result.IsAcknowledged;
        }
    }
}