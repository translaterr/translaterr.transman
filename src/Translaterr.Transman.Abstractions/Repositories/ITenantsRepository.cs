using System;
using Translaterr.Transman.Abstractions.Repositories.Support;
using Translaterr.Transman.Abstractions.Types;

namespace Translaterr.Transman.Abstractions.Repositories
{
    public interface ITenantsRepository : IRepository<ITenant, int>, IFindableByPublicId<ITenant, Guid>
    {
        
    }
}