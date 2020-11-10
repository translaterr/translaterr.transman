using System.Collections.Generic;

namespace Translaterr.Transman.Abstractions.Factories
{
    public interface IFactory<T> where T : class
    {
        public T Generate();
        public IList<T> Generate(int count);
    }
}