using Microsoft.VisualBasic.FileIO;
using NUnit.Framework;
using System;

namespace CodeProblems.UnitTests.Services
{
    [TestFixture]
    public class CodeTest
    {
        private Program _codeProblems;      //Este debe ser : private NombreDeClaseATestear _variable;
        private Mathematics _mathematics;

        [SetUp]
        public void Setup()
        {
            _codeProblems = new Program();
            _mathematics = new Mathematics();
        }

        [Test]
        public void FirstDuplicate()
        {
            Assert.AreEqual(3, Mathematics.firstDuplicate(new int[] { 2, 1, 3, 5, 3, 2 }));
            Assert.AreEqual(2, Mathematics.firstDuplicate(new int[] { 2, 2 }));
            Assert.AreEqual(-1, Mathematics.firstDuplicate(new int[] { 2, 4, 3, 5, 1 }));
            Assert.AreEqual(-1, Mathematics.firstDuplicate(new int[] { 10, 6, 8, 4, 9, 1, 7, 2, 5, 3 }));
            Assert.AreEqual(-1, Mathematics.firstDuplicate(new int[] { 2, 1 }));
            Assert.AreEqual(3, Mathematics.firstDuplicate(new int[] { 2, 3, 3 }));
            Assert.AreEqual(-1, Mathematics.firstDuplicate(new int[] { }));
            Assert.AreEqual(-1, Mathematics.firstDuplicate(new int[] { 2 }));
            Assert.AreEqual(2, Mathematics.firstDuplicate(new int[] { 1, 0, 2, 2, 1,1 }));
        }
    }
}