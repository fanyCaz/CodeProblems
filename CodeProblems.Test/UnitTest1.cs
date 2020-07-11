using NUnit.Framework;

namespace CodeProblems.UnitTests.Services
{
    [TestFixture]
    public class CodeTest
    {
        private Program _codeProblems;      //Este debe ser : private NombreDeClaseATestear _variable;

        [SetUp]
        public void Setup()
        {
            _codeProblems = new Program();
        }

        [Test]
        public void IsPrime_InputIs1_ReturnFalse()
        {

        }
    }
}