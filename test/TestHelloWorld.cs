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
		public void ShouldAddTwoNumbers()
		{
			Assert.AreEqual(6, HelloWorld.Add(2, 4));
		}

		[Test]
		public void ShouldSubtractTwoNumbers()
		{
			Assert.AreEqual(9, HelloWorld.Subtract(10, 1));
		}

		[Test]
		public void ShouldMultiplyTwoNumbers()
		{
			Assert.AreEqual(8, HelloWorld.Multiply(2, 4));
		}

		[Test]
		public void ShouldDivideTwoNumbers()
		{
			Assert.AreEqual(5, HelloWorld.Divide(10, 2));
		}

		// [Test]
		public void ShouldFailWhenDividingByZero()
		{
			Assert.AreEqual(5, HelloWorld.Divide(10, 0));
		}

		// [Test]
		public void ShouldThrowDivideByZeroException()
		{
			Assert.Throws<System.DivideByZeroException>(new TestDelegate(() => DivideByZero()));
		}
		private void DivideByZero()
		{
            decimal result = HelloWorld.Divide(10, 0);
		}
	}
}