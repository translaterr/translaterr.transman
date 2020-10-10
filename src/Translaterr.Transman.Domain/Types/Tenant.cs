using System;
using Translaterr.Transman.Abstractions.Types;

namespace Translaterr.Transman.Domain.Types
{
    public class Tenant : ITenant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid PublicId { get; set; }
    }
}