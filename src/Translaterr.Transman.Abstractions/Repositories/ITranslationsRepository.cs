using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Translaterr.Transman.Abstractions.Types;

namespace Translaterr.Transman.Abstractions.Repositories
{
    public interface ITranslationsRepository
    {
        public Task<IList<ITranslation>> Get(Guid applicationId, CancellationToken cancellationToken);
        public Task<ITranslation> Add(ITranslation translation, CancellationToken cancellationToken);
        public Task<ITranslation> Update(ITranslation translation, CancellationToken cancellationToken);
        public Task<bool> Delete(ITranslation translation, CancellationToken cancellationToken);
    }
}