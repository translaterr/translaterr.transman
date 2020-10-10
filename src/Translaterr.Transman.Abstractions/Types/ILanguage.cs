namespace Translaterr.Transman.Abstractions.Types
{
    public interface ILanguage : IType
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string IsoCode { get; set; }
    }
}