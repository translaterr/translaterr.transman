using System;
using Translaterr.Transman.Abstractions.Types;

namespace Translaterr.Transman.Domain.Types
{
    public class Environment : IEnvironment
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public int ApplicationId { get; set; }
        public string Name { get; set; }
    }
}