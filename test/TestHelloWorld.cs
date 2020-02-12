using NUnit.Framework;
using myapp;

namespace test
{
    public class TestHelloWorld
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MyApplicationShouldBeRunning()
        {
            Assert.True(HelloWorld.IsApplicationRunning());
        }

        [Test]
        public void TestAddition()
        {
            Assert.AreEqual(6, HelloWorld.Add(2, 4));
        }

        [Test]
        public void TestSubtraction()
        {
            Assert.AreEqual(9, HelloWorld.Subtract(10, 1));
        }

        [Test]
        public void TestMultiplication()
        {
            Assert.AreEqual(8, HelloWorld.Multiply(2, 4));
        }

        [Test]
        public void TestDivision()
        {
            Assert.AreEqual(5, HelloWorld.Divide(10, 2));
        }
    }
}