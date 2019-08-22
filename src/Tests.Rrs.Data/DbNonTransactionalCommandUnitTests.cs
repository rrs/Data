using NUnit.Framework;
using Rrs.Data;
using System.Data;
using System.Threading.Tasks;

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
        public void CommandAsyncGetsAConnection() => _q.ExecuteAsync(CommandAsync);

        private static Task CommandAsync(IDbConnection c)
        {
            Assert.IsNotNull(c);

            return Task.CompletedTask;
        }

        [Test]
        public void TestCommandWithABasicParameter() => _q.Execute(Command, 5);

        private static void Command(IDbConnection c, int p)
        {
            Assert.IsNotNull(c);
            Assert.AreEqual(5, p);
        }

        [Test]
        public void TestCommandAsyncWithABasicParameter() => _q.ExecuteAsync(CommandAsync, 5);

        private static Task CommandAsync(IDbConnection c, int p)
        {
            Assert.IsNotNull(c);
            Assert.AreEqual(5, p);

            return Task.CompletedTask;
        }

        [Test]
        public void TestCommandWithAnObjectParameter() => _q.Execute(Command, new TestObject(67, "Barry"));

        private static void Command(IDbConnection c, TestObject p)
        {
            Assert.IsNotNull(c);
            Assert.AreEqual(67, p.Id);
            Assert.AreEqual("Barry", p.Name);
        }

        [Test]
        public void TestCommandAsyncWithAnObjectParameter() => _q.ExecuteAsync(CommandAsync, new TestObject(67, "Barry"));

        private static Task CommandAsync(IDbConnection c, TestObject p)
        {
            Assert.IsNotNull(c);
            Assert.AreEqual(67, p.Id);
            Assert.AreEqual("Barry", p.Name);

            return Task.CompletedTask;
        }
    }
}