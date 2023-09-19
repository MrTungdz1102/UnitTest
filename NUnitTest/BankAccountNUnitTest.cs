using Moq;
using UnitTest;

namespace NUnitTest
{
	[TestFixture]
	public class BankAccountNUnitTest
	{
		private BankAccount bankAccount;
		[SetUp]
		public void SetUp()
		{
			//	bankAccount = new BankAccount(new LogBook());
		}

		[Test]
		[TestCase(100)]
		public void BankDeposit_AddAmount_ReturnResponse(int amount)
		{
			bankAccount = new BankAccount(new LogBook());
			var result = bankAccount.Deposit(amount);
			Assert.IsTrue(result);
			Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
		}

		[Test]
		[TestCase(100)]
		public void BankDepositLogFake_AddAmount_ReturnResponse(int amount)
		{
			var logMock = new Mock<ILogBook>();
			logMock.Setup(x => x.Message(""));
			bankAccount = new BankAccount(logMock.Object);

			var result = bankAccount.Deposit(amount);
			Assert.IsTrue(result);
			Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
		}

		[Test]
		[TestCase(100, 200)]
		[TestCase(200, 100)]
		public void BankWithDraw_InputAmount_ReturnResponse(int balcane, int amount)
		{
			var logMock = new Mock<ILogBook>();
			// string kieu nao cung duoc chap nhan, neu khong thi return false
			logMock.Setup(x => x.LogToDb(It.IsAny<string>())).Returns(true);
			logMock.Setup(x => x.LogBalanceAfterWithDraw(It.Is<int>(x => x > 0))).Returns(true);
			//logMock.Setup(u => u.LogBalanceAfterWithDraw(It.Is<int>(x => x < 0))).Returns(false);
			logMock.Setup(u => u.LogBalanceAfterWithDraw(It.IsInRange(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);
			bankAccount = new(logMock.Object);
			// nap tien truoc khi rut
			bankAccount.Deposit(balcane);
			var result = bankAccount.WithDraw(amount);
			Assert.IsTrue(result);
		}

		[Test]
		public void BankLogDummy_LogMockString_ReturnResponse()
		{
			var logMock = new Mock<ILogBook>();
			string output = "Hello";

			logMock.Setup(x => x.MessageWithReturnStr(It.IsAny<string>())).Returns((string str) => str.ToLower());

			Assert.That(logMock.Object.MessageWithReturnStr("HELLO"), Is.EqualTo(output.ToLower()));
		}

		[Test]
		public void BankLogDummy_LogMockStringOutputStr_ReturnResponse()
		{
			var logMock = new Mock<ILogBook>();
			string output = "hello";

			logMock.Setup(x => x.LogWithOutPutResult(It.IsAny<string>(), out output)).Returns(true);
			string result = "";
			Assert.IsTrue(logMock.Object.LogWithOutPutResult("Tung", out result));
			Assert.That(result, Is.EqualTo(output));
		}

		[Test]
		public void BankLogDummy_LogMockRefObject_ReturnResponse()
		{
			var logMock = new Mock<ILogBook>();
			Customer customer = new Customer();
			Customer customerNotUsed = new Customer();
			logMock.Setup(x => x.LogWithRefObject(ref customer)).Returns(true);

			
			Assert.That(logMock.Object.LogWithRefObject(ref customerNotUsed), Is.False);
			Assert.IsTrue(logMock.Object.LogWithRefObject(ref customer));
		}


		[Test]
		public void BankLogDummy_SetAndGetLogTypeSeverityMock_MockTest()
		{
			var logMock = new Mock<ILogBook>();
			
			logMock.Setup(x => x.LogSeverity).Returns(10);
			logMock.Setup(x => x.LogType).Returns("Warning");

			// setup thi moi set duoc gia tri
		//	logMock.SetupAllProperties();
		//	logMock.Object.LogSeverity = 100;

			Assert.That(logMock.Object.LogSeverity, Is.EqualTo(10));
			Assert.That(logMock.Object.LogType, Is.EqualTo("Warning"));

			// callback
			string logTemp = "Hi, ";
			logMock.Setup(x => x.LogToDb(It.IsAny<string>())).Returns(true).Callback((string str) => logTemp += str);
			logMock.Object.LogToDb("Tung");
			Assert.That(logTemp, Is.EqualTo("Hi, Tung"));

			int counter = 5;
			logMock.Setup(x => x.LogToDb(It.IsAny<string>())).Returns(true).Callback(() => counter ++);
			logMock.Object.LogToDb("Tung");
			Assert.That(counter, Is.EqualTo(6));
		}

		[Test]
		public void BankLogDummy_VerifyExample()
		{
			var logMock = new Mock<ILogBook>();
			BankAccount bankAccount = new BankAccount(logMock.Object);
			bankAccount.DepositValid(100);
			Assert.That(bankAccount.GetBalance, Is.EqualTo(100));

			// verify
			logMock.Verify(x => x.Message(It.IsAny<string>()), Times.Exactly(2));
			logMock.Verify(x => x.Message("Test"), Times.AtLeastOnce);
			logMock.VerifySet(x => x.LogSeverity = 101, Times.Once);
		}
	}
}
