using System.Collections.Generic;
using System.Linq;
using Bogus;
using Translaterr.Transman.Abstractions.Factories;
using Translaterr.Transman.Domain.Types;

namespace Translaterr.Transman.Domain.Factories
{
    public class TenantFactory : IFactory<Tenant>
    {
        private readonly Faker<Tenant> _faker;

        public TenantFactory()
        {
            _faker = new Faker<Tenant>()
                .RuleFor(tenant => tenant.Name, faker => faker.Company.CompanyName())
                .RuleFor(tenant => tenant.PublicId, faker => faker.Random.Guid());
        }

        public Tenant Generate()
        {
            return _faker.Generate();
        }
        
        public IList<Tenant> Generate(int count)
        {
            return _faker.GenerateLazy(count).ToList();
        }
    }
}