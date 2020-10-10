using Translaterr.Transman.Abstractions.Types;

namespace Translaterr.Transman.Data.Entities
{
    public interface IEntity<T> where T : IType
    {
        public T ToDomain();
    }
}