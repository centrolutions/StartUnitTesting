using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBasics;

namespace TheBasicsTests
{
    public class PigLatinTests
    {
        PigLatin _Sut;

        [SetUp]
        public void Setup()
        {
            _Sut = new PigLatin();
        }

        [TestCase("over", "overway")]
        [TestCase("away", "awayway")]
        [TestCase("a", "away")]
        [TestCase("it", "itway")]
        public void Translate_WayIsAddedToEndOfWord_WhenWordStartsWithVowel(string input, string expected)
        {
            var result = _Sut.Translate(input);

            Assert.AreEqual(expected, result);
        }

        [TestCase("fox", "oxfay")]
        [TestCase("jumped", "umpedjay")]
        [TestCase("dog", "ogday")]
        public void Translate_ConsonantIsMovedToEndAndAyIsAddedToEnd_WhenWordStartsWithConsonant(string input, string expected)
        {
            var result = _Sut.Translate(input);

            Assert.AreEqual(expected, result);
        }

        [TestCase("quick", "uickqay")]
        [TestCase("brown", "ownbray")]
        [TestCase("the", "ethay")]
        public void Translate_AllConsonantsAreMovedToEndAndAyIsAddedToEnd_WhenWordStartsWithMultipleConsonants(string input, string expected)
        {
            var result = _Sut.Translate(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Translate_TranslatesEntireSentence_WhenMoreThanOneWordIsUsed()
        {
            var result = _Sut.Translate("the quick brown fox jumped over the dog");

            Assert.AreEqual("ethay uickqay ownbray oxfay umpedjay overway ethay ogday", result);
        }

        [Test]
        public void Translate_TranslatesWord_WhenWordHasCapitolLettersInIt()
        {
            var result = _Sut.Translate("The");

            Assert.AreEqual("Ethay", result);
        }

        [Test]
        public void Translate_TranslatesWordThatStartsWithVowel_WhenWordHasCapitalLetter()
        {
            var result = _Sut.Translate("Over");

            Assert.AreEqual("Overway", result);
        }

        [Test]
        public void Translate_KeepsPunctuationAtEndOfWord_WhenWordHasCommaAtEnd()
        {
            var result = _Sut.Translate("quick,");

            Assert.AreEqual("uickqay,", result);
        }
    }
}
