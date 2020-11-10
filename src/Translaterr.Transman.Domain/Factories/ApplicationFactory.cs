using System.Collections.Generic;
using System.Linq;
using Bogus;
using Translaterr.Transman.Abstractions.Factories;
using Translaterr.Transman.Domain.Types;

namespace Translaterr.Transman.Domain.Factories
{
    public class ApplicationFactory : IFactory<Application>
    {
        private readonly Faker<Application> _faker;

        public ApplicationFactory()
        {
            _faker = new Faker<Application>()
                .RuleFor(application => application.Name, faker => faker.Internet.DomainName())
                .RuleFor(application => application.PublicId, faker => faker.Random.Guid())
                .RuleFor(application => application.FallbackLanguage, faker => faker.Random.RandomLocale());
        }

        public Application Generate()
        {
            return _faker.Generate();
        }

        public IList<Application> Generate(int count)
        {
            return _faker.GenerateLazy(count).ToList();
        }
    }
}