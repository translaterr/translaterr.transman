namespace Translaterr.Transman.Abstractions.ServiceResults
{
    public interface IServiceResult<T, K>
    {
        public T Data { get; set; }
        public K Type { get; set; }
    }
}