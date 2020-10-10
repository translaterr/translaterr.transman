using System.Threading;
using System.Threading.Tasks;
using Translaterr.Transman.Abstractions.Types;

namespace Translaterr.Transman.Abstractions.Repositories.Support
{
    public interface IFindableByPublicId<T, K> where T : IType
    {
        public Task<T> FindByPublicId(K publicId, CancellationToken cancellationToken);
    }
}