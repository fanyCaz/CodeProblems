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
        [Test]
        public void NotDuplicatedLetter()
        {
            Assert.AreEqual('c', Mathematics.firstNonDuplicateLetter("abacabad"));
            Assert.AreEqual('_', Mathematics.firstNonDuplicateLetter("abacabaabacaba"));
            Assert.AreEqual('z', Mathematics.firstNonDuplicateLetter("z"));
            Assert.AreEqual('_', Mathematics.firstNonDuplicateLetter("bcccccccb"));
            Assert.AreEqual('_', Mathematics.firstNonDuplicateLetter(""));
        }
        [Test]
        public void NotDuplicatedLetterUsingIndexes()
        {
            Assert.AreEqual('c', Mathematics.firstNonDuplicateLetterIndexes("abacabad"));
            Assert.AreEqual('_', Mathematics.firstNonDuplicateLetterIndexes("abacabaabacaba"));
            Assert.AreEqual('z', Mathematics.firstNonDuplicateLetterIndexes("z"));
            Assert.AreEqual('_', Mathematics.firstNonDuplicateLetterIndexes("bcccccccb"));
            Assert.AreEqual('_', Mathematics.firstNonDuplicateLetterIndexes(""));
        }

        [Test]
        public void WhatCenturyIsThatYear()
        {
            Assert.AreEqual(20, Mathematics.centuryFromYear(1905));
            Assert.AreEqual(17, Mathematics.centuryFromYear(1700));
            Assert.AreEqual(20, Mathematics.centuryFromYear(1988));
            Assert.AreEqual(1, Mathematics.centuryFromYear(45));
            Assert.AreEqual(2, Mathematics.centuryFromYear(200));
        }

        [Test]
        public void IsPalindrome()
        {
            Assert.AreEqual(true, Mathematics.checkPalindrome("aabaa"));
            Assert.AreEqual(false, Mathematics.checkPalindrome("az"));
            Assert.AreEqual(true, Mathematics.checkPalindrome("hlbeeykoqqqokyeeblh"));
            Assert.AreEqual(false, Mathematics.checkPalindrome("aaabaaaa"));
        }

        [Test]
        public void IsTheBiggestProduct()
        {
            Assert.AreEqual(21, Mathematics.adjacentElementsProduct(new int[] { 3, 6, -2, -5, 7, 3 }));
            Assert.AreEqual(2, Mathematics.adjacentElementsProduct(new int[] { -1, -2 }));
            Assert.AreEqual(50, Mathematics.adjacentElementsProduct(new int[] { 9, 5, 10, 2, 24, -1, -48 }));
        }

        [Test]
        public void AreStatuesArranged()
        {
            Assert.AreEqual(3, Mathematics.makeArrayConsecutive2(new int[] { 6, 2, 3, 8 }));
            Assert.AreEqual(0, Mathematics.makeArrayConsecutive2(new int[] { 5, 4, 6 }));
            Assert.AreEqual(2, Mathematics.makeArrayConsecutive2(new int[] { 0 , 3 }));
        }

    }
}