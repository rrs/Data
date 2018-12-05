using NUnit.Framework;
using Rrs.Data;
using System.Data;

namespace Tests.Rrs.Data
{
    public class DbNonTransactionalCommandUnitTests
    {
        private IDbDelegator _q;

        [SetUp]
        public void Setup()
        {
            _q = new DbDelegator(MockIDbConnectionFactoryFacade.Create().MockDbConnectionFactory.Object);
        }

        [Test]
        public void CommandGetsAConnection() => _q.Execute(Command);

        private static void Command(IDbConnection c)
        {
            Assert.IsNotNull(c);
        }

        [Test]
        public void TestCommandWithABasicParameter() => _q.Execute(Command, 5);

        private static void Command(IDbConnection c, int p)
        {
            Assert.IsNotNull(c);
            Assert.AreEqual(5, p);
        }

        [Test]
        public void TestCommandWithAnObjectParameter() => _q.Execute(Command, new TestObject(67, "Barry"));

        private static void Command(IDbConnection c, TestObject p)
        {
            Assert.IsNotNull(c);
            Assert.AreEqual(67, p.Id);
            Assert.AreEqual("Barry", p.Name);
        }
    }
}