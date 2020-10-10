using Translaterr.Transman.Abstractions.Types;

namespace Translaterr.Transman.Domain.Types
{
    public class Language : ILanguage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }
    }
}