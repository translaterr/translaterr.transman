namespace Translaterr.Transman.Abstractions.Types
{
    public interface ITranslation : IType
    {
        public int Id { get; set; }
        
        public int ApplicationId { get; set; }
        
        public ILanguage Language {get; set; }
        
        public string Key { get; set; }
        
        public string Value { get; set; }
    }
}