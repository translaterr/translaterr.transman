using System.Collections.Generic;
using Bogus;
using Translaterr.Transman.Abstractions.Factories;
using Translaterr.Transman.Domain.Types;

namespace Translaterr.Transman.Domain.Factories
{
    public class TranslationValueFactory : IFactory<TranslationValue>
    {
        private readonly Faker<TranslationValue> _faker;

        public TranslationValueFactory()
        {
            _faker = new Faker<TranslationValue>()
                .RuleFor(translationValue => translationValue.LanguageCode, faker => faker.Random.RandomLocale())
                .RuleFor(translationValue => translationValue.Value, faker => faker.Random.Words(3));
        }
        
        public TranslationValue Generate()
        {
            return _faker.Generate();
        }

        public IList<TranslationValue> Generate(int count)
        {
            return _faker.Generate(count);
        }
    }
}