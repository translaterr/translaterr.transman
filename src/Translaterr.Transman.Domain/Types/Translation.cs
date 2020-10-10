using Translaterr.Transman.Abstractions.Types;

namespace Translaterr.Transman.Domain.Types
{
    public class Translation : ITranslation
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public ILanguage Language { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}