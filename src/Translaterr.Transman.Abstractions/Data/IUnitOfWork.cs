using System.Threading;
using System.Threading.Tasks;
using Translaterr.Transman.Abstractions.Repositories;

namespace Translaterr.Transman.Abstractions.Data
{
    public interface IUnitOfWork
    {
        public ITenantsRepository TenantsRepository { get; }

        public Task<bool> SaveChanges(CancellationToken cancellationToken);
    }
}