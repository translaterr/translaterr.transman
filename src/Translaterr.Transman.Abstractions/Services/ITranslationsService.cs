using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Translaterr.Transman.Abstractions.Types;

namespace Translaterr.Transman.Abstractions.Services
{
    public interface ITranslationsService
    {
        public Task<IList<ITranslation>> GetTranslations(Guid applicationId, CancellationToken cancellationToken = default);
        public Task<ITranslation> AddTranslation(ITranslation translation, CancellationToken cancellationToken = default);
        public Task<ITranslation> UpdateTranslation(ITranslation translation, CancellationToken cancellationToken = default);
        public Task<bool> DeleteTranslation(ITranslation translation, CancellationToken cancellationToken = default);
    }
}