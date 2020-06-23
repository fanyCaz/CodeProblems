using NUnit.Framework;

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
        public void IsPrime_ValuesNotPrime_ReturnFalse(int value)   //el nombre debe decir funcion_queSeEvalua_queDebeRetornar
        {
            //En las pruebas nunca debe haber logica
            var result = _primeService.IsPrimer(value);
            Assert.IsFalse(result,"Es primo");
        }

        [TestCase(0)]
        public void IsEntero_NumeroSalida_ReturnInt(int value)
        {
            int expected = 0;
            var actual = _primeService.SerieFibonacci(value);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SampleTest()
        {
            Assert.AreEqual(new int[] { 3, 5 }, _primeService.Divisors(15));
            Assert.AreEqual(new int[] { 2, 4, 8 }, _primeService.Divisors(16));
            Assert.AreEqual(new int[] { 11, 23 }, _primeService.Divisors(253));
            Assert.AreEqual(new int[] { 2, 3, 4, 6, 8, 12 }, _primeService.Divisors(24));
        }
    }
}