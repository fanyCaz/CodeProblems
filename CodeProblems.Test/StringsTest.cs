using Microsoft.VisualBasic.FileIO;
using NUnit.Framework;
using System;

namespace CodeProblems.UnitTests.Services
{
    [TestFixture]
    public class StringsTest
    {
        private Strings _strings;
        
        [SetUp]
        public void Setup()
        {
            _strings = new Strings();
        }

    }
}