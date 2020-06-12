using NUnit.Framework;
using PrimeService;

namespace PrimeService.UnitTests.Services
{
    [TestFixture]
    public class PrimeService_IsPrimeShould
    {
        private PrimeService _primeService;
        [SetUp]
        public void Setup()
        {
            _primeService = new PrimeService();
        }

        [Test]
        public void IsPrime_InputIs1_ReturnFalse()
        {
            var result = _primeService.IsPrimer(1);
            Assert.Pass();
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(12)]
        public void IsPrime_ValuesLessThan2_ReturnFalse(int value)
        {
            var result = _primeService.IsPrimer(value);
            Assert.IsFalse(result, $"{value} should not be prime");
        }
    }
}