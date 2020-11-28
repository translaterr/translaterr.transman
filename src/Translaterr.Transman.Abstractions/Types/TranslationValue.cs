namespace Translaterr.Transman.Abstractions.Types
{
    public class TranslationValue : ITranslationValue
    {
        public string LanguageCode { get; set; }
        public string Value { get; set; }
    }
}