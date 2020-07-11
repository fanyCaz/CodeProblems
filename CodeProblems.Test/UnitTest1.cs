using NUnit.Framework;

namespace CodeProblems.Test
{
    [TestFixture]
    public class Tests
    {
        private codeProblems _CodeProblems;

        [SetUp]
        public void Setup()
        {
            _CodeProblems = new CodeProblems();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}