using System;

namespace Translaterr.Transman.Abstractions.Types
{
    public interface ITenant : IType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid PublicId { get; set; }
    }
}