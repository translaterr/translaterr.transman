using System.Collections.Generic;
using System.Linq;
using Bogus;
using Translaterr.Transman.Abstractions.Factories;
using Translaterr.Transman.Domain.Types;

namespace Translaterr.Transman.Domain.Factories
{
    public class TranslationKeyFactory : IFactory<TranslationKey>
    {
        private readonly Faker<TranslationKey> _faker;

        public TranslationKeyFactory()
        {
            _faker = new Faker<TranslationKey>()
                .RuleFor(translationKey => translationKey.Key, faker => faker.Random.Hash(40, true))
                .RuleFor(translationKey => translationKey.PublicId, faker => faker.Random.Guid());
        }

        public TranslationKey Generate()
        {
            return _faker.Generate();
        }

        public IList<TranslationKey> Generate(int count)
        {
            return _faker.Generate(count);
        }
    }
}