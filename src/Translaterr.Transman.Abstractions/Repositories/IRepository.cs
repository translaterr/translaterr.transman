using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Translaterr.Transman.Abstractions.Repositories
{
    public interface IRepository<T, Key>
    {
        public Task<IList<T>> GetAll(CancellationToken cancellationToken);
        public Task<T> FindById(Key id, CancellationToken cancellationToken);
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
    }
}