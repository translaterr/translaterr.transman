using System;

namespace Translaterr.Transman.Abstractions.Types
{
    public interface IEnvironment : IType
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public int ApplicationId { get; set; }
        public string Name { get; set; }
    }
}