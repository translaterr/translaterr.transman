namespace Translaterr.Transman.Abstractions.Types
{
    public interface ITranslationValue
    {
        public string LanguageCode { get; set; }
        public string Value { get; set; }
    }
}