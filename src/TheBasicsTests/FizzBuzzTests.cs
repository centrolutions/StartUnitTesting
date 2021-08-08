using NUnit.Framework;
using TheBasics;

namespace TheBasicsTests
{
    public class FizzBuzzTests
    {
        FizzBuzz _Sut;

        [SetUp]
        public void Setup()
        {
            _Sut = new FizzBuzz();
        }

        [Test]
        public void Check_ReturnsFizz_WhenNumberIs3()
        {
            var result = _Sut.Check(3);
            
            Assert.AreEqual("Fizz", result);
        }

        [Test]
        public void Check_ReturnsBuzz_WhenNumberIs5()
        {
            var result = _Sut.Check(5);

            Assert.AreEqual("Buzz", result);
        }

        [Test]
        public void Check_ReturnsNumber_WhenNotDivisibleBy3Or5()
        {
            var result = _Sut.Check(1);

            Assert.AreEqual("1", result);
        }

        [TestCase(6)]
        [TestCase(12)]
        [TestCase(33)]
        [TestCase(99)]
        public void Check_ReturnsFizz_WhenNumberIsDivisibleBy3(int input)
        {
            var result = _Sut.Check(input);

            Assert.AreEqual("Fizz", result);
        }

        [TestCase(10)]
        [TestCase(20)]
        [TestCase(25)]
        [TestCase(55)]
        [TestCase(95)]
        public void Check_ReturnsBuzz_WhenNumberIsDivisibleBy5(int input)
        {
            var result = _Sut.Check(input);

            Assert.AreEqual("Buzz", result);
        }

        [TestCase(15)]
        [TestCase(75)]
        [TestCase(30)]
        public void Check_ReturnsFizzBuzz_WhenNumberIsDivisibleBy3And5(int input)
        {
            var result = _Sut.Check(input);

            Assert.AreEqual("FizzBuzz", result);
        }
    }
}