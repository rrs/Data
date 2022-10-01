using NUnit.Framework;
using Rrs.Data;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Tests.Rrs.Data
{
    public class DbNonTransactionalCommandUnitTests
    {
        private CancellationTokenSource _cts = new CancellationTokenSource();
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
        public void CommandAsyncGetsAConnection() => _q.Execute(CommandAsync);

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
        public void TestCommandAsyncWithABasicParameter() => _q.Execute(CommandAsync, 5);

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
        public void TestCommandAsyncWithAnObjectParameter() => _q.Execute(CommandAsync, new TestObject(67, "Barry"));

        private static Task CommandAsync(IDbConnection c, TestObject p)
        {
            Assert.IsNotNull(c);
            Assert.AreEqual(67, p.Id);
            Assert.AreEqual("Barry", p.Name);

            return Task.CompletedTask;
        }

        [Test]
        public void TestCommandAsyncAccepts2ParametersAndCancellationToken() => _q.Execute(CommandAsyncWith2ParamtersAndCancellationToken, 5, 2, _cts.Token);

        private Task CommandAsyncWith2ParamtersAndCancellationToken(IDbConnection c, int a, int b, CancellationToken cancellationToken)
        {
            Assert.AreEqual(5, a);
            Assert.AreEqual(2, b);
            Assert.AreEqual(_cts.Token, cancellationToken);
            return Task.CompletedTask;
        }
    }
}