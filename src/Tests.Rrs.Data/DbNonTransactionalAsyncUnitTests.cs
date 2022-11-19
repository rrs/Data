using NUnit.Framework;
using Rrs.Data;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Tests.Rrs.Data
{
    public class DbNonTransactionalAsyncUnitTests
    {
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private IDbDelegator _q;

        [SetUp]
        public void Setup()
        {
            _q = new DbDelegator(MockIDbConnectionFactoryFacade.Create().MockDbConnectionFactory.Object);
        }

        [Test]
        public Task CommandAsyncGetsAConnection() => _q.Execute(CommandAsync);
        
        private static Task CommandAsync(IDbConnection c)
        {
            Assert.IsNotNull(c);

            return Task.CompletedTask;
        }

        [Test]
        public Task CommandAsyncGetsAConnectionAndCancellationToken() => _q.Execute(CommandAsyncCt, _cts.Token);

        private static Task CommandAsyncCt(IDbConnection c, CancellationToken token)
        {
            Assert.IsNotNull(c);

            return Task.CompletedTask;
        }

        [Test]
        public Task TestCommandAsyncWithABasicParameter() => _q.Execute(CommandAsync, 5);


        private static Task CommandAsync(IDbConnection c, int p)
        {
            Assert.IsNotNull(c);
            Assert.AreEqual(5, p);

            return Task.CompletedTask;
        }

        [Test]
        public Task TestCommandAsyncWithABasicParameterAndCancellationToken() => _q.Execute(CommandAsyncCt, 5);

        private static Task CommandAsyncCt(IDbConnection c, int p, CancellationToken token)
        {
            Assert.IsNotNull(c);
            Assert.AreEqual(5, p);

            return Task.CompletedTask;
        }

        [Test]
        public Task TestCommandAsyncWithAnObjectParameter() => _q.Execute(CommandAsync, new TestObject(67, "Barry"));
        [Test]
        public Task TestCommandAsyncWithAnObjectParameterAndCancellationToken() => _q.Execute(CommandAsync, new TestObject(67, "Barry"));

        private static Task CommandAsync(IDbConnection c, TestObject p)
        {
            Assert.IsNotNull(c);
            Assert.AreEqual(67, p.Id);
            Assert.AreEqual("Barry", p.Name);

            return Task.CompletedTask;
        }

        [Test]
        public Task TestCommandAsyncAccepts2ParametersAndCancellationToken() => _q.Execute(CommandAsyncWith2ParamtersAndCancellationToken, 5, 2);

        private Task CommandAsyncWith2ParamtersAndCancellationToken(IDbConnection c, int a, int b, CancellationToken cancellationToken)
        {
            Assert.IsNotNull(c);
            Assert.AreEqual(5, a);
            Assert.AreEqual(2, b);
            Assert.AreEqual(_cts.Token, cancellationToken);
            return Task.CompletedTask;
        }

        [Test]
        public async Task QueryAsyncGetsABasicValue()
        {
            var r = await _q.Execute(QueryAsync);
            Assert.AreEqual("Moooo!", r);
        }

        private Task<string> QueryAsync(IDbConnection c)
        {
            Assert.IsNotNull(c);
            return Task.FromResult("Moooo!");
        }


        [Test]
        public async Task QueryAsyncGetsAnObject()
        {
            var r = await _q.Execute(QueryAsyncReturnsAnObject);
            Assert.AreEqual(2, r.Id);
            Assert.AreEqual("Wilbur", r.Name);
        }

        private Task<TestObject> QueryAsyncReturnsAnObject(IDbConnection c)
        {
            Assert.IsNotNull(c);
            return Task.FromResult(new TestObject(2, "Wilbur"));
        }


        [Test]
        public async Task QueryAsyncGetsABasicValueFromABasicValue()
        {
            var r = await _q.Execute(QueryAsync, 717);
            Assert.AreEqual(717, r);
        }

        private Task<int> QueryAsync(IDbConnection c, int p)
        {
            Assert.IsNotNull(c);
            return Task.FromResult(p);
        }


        [Test]
        public async Task QueryAsyncGetsAnObjectFromABasicValue()
        {
            var r = await _q.Execute(QueryAsyncReturnsAnObject, 909);
            Assert.AreEqual(909, r.Id);
            Assert.AreEqual("Gaaary", r.Name);
        }

        private Task<TestObject> QueryAsyncReturnsAnObject(IDbConnection c, int p)
        {
            Assert.IsNotNull(c);
            return Task.FromResult(new TestObject(p, "Gaaary"));
        }

        [Test]
        public async Task QueryAsyncAccepts2Parameters()
        {
            var r = await _q.Execute(QueryAsyncWith2Paramters, 1, 2);
            Assert.AreEqual(3, r.Id);
            Assert.AreEqual("Baaary", r.Name);
        }

        private Task<TestObject> QueryAsyncWith2Paramters(IDbConnection c, int a, int b)
        {
            Assert.IsNotNull(c);
            return Task.FromResult(new TestObject(a + b, "Baaary"));
        }

        [Test]
        public async Task QueryAsyncAccepts2ParametersAndCancellationToken()
        {
            var r = await _q.Execute(QueryAsyncWith2ParamtersAndCancellationToken, 5, 2);
            Assert.AreEqual(7, r.Id);
            Assert.AreEqual("Boris", r.Name);
        }

        private Task<TestObject> QueryAsyncWith2ParamtersAndCancellationToken(IDbConnection c, int a, int b, CancellationToken cancellationToken)
        {
            Assert.IsNotNull(c);
            return Task.FromResult(new TestObject(a + b, "Boris"));
        }
    }
}
