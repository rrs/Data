using NUnit.Framework;
using Rrs.Data;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Tests.Rrs.Data
{
    public class DbNonTransactionalAsyncUnitTests
    {
        private CancellationTokenSource _cts;
        private IDbDelegator _q;

        [SetUp]
        public void Setup() => _q = new DbDelegator(MockIDbConnectionFactoryFacade.Create().MockDbConnectionFactory.Object);

        [Test]
        public Task CommandAsyncGetsAConnection()
        {
            return _q.Execute(Command);
            
            static Task Command(IDbConnection c)
            {
                Assert.IsNotNull(c);

                return Task.CompletedTask;
            }
        }

        [Test]
        public Task CommandAsyncGetsAConnectionAndCancellationToken()
        {
            return _q.Execute(Command);

            static Task Command(IDbConnection c, CancellationToken token)
            {
                Assert.IsNotNull(c);

                return Task.CompletedTask;
            }
        }

        [Test]
        public Task TestCommandAsyncWithABasicParameter()
        {
            return _q.Execute(Command, 5);

            static Task Command(IDbConnection c, int p)
            {
                Assert.IsNotNull(c);
                Assert.AreEqual(5, p);

                return Task.CompletedTask;
            }
        }

        [Test]
        public Task TestCommandAsyncWithABasicParameterAndCancellationToken()
        {
            return _q.Execute(Command, 5);

            static Task Command(IDbConnection c, int p, CancellationToken token)
            {
                Assert.IsNotNull(c);
                Assert.AreEqual(5, p);

                return Task.CompletedTask;
            }
        }

        [Test]
        public Task TestCommandAsyncWithAnObjectParameter()
        {
            return _q.Execute(Command, new TestObject(67, "Barry"));

            static Task Command(IDbConnection c, TestObject p)
            {
                Assert.IsNotNull(c);
                Assert.AreEqual(67, p.Id);
                Assert.AreEqual("Barry", p.Name);

                return Task.CompletedTask;
            }
        }

        [Test]
        public Task TestCommandAsyncAccepts2Parameters()
        {
            return _q.Execute(Command, 5, 2);

            Task Command(IDbConnection c, int a, int b)
            {
                Assert.IsNotNull(c);
                Assert.AreEqual(5, a);
                Assert.AreEqual(2, b);
                return Task.CompletedTask;
            }
        }

        [Test]
        public Task TestCommandAsyncAccepts2ParametersAndCancellationToken()
        {
            return _q.Execute(Command, 5, 2);
        
            Task Command(IDbConnection c, int a, int b, CancellationToken cancellationToken)
            {
                Assert.IsNotNull(c);
                Assert.AreEqual(5, a);
                Assert.AreEqual(2, b);
                Assert.AreEqual(_cts.Token, cancellationToken);
                return Task.CompletedTask;
            }
        }

        [Test]
        public async Task QueryAsyncGetsABasicValue()
        {
            var r = await _q.Execute(Query);
            Assert.AreEqual("Moooo!", r);
            
            static Task<string> Query(IDbConnection c)
            {
                Assert.IsNotNull(c);
                return Task.FromResult("Moooo!");
            }
        }

        [Test]
        public async Task QueryAsyncGetsABasicValueWithCancellationToken()
        {
            var r = await _q.Execute(Query);
            Assert.AreEqual("Moooo!", r);

            Task<string> Query(IDbConnection c, CancellationToken cancellationToken)
            {
                Assert.IsNotNull(c);
                Assert.AreEqual(_cts.Token, cancellationToken);
                return Task.FromResult("Moooo!");
            }
        }


        [Test]
        public async Task QueryAsyncGetsAnObject()
        {
            var r = await _q.Execute(Query);
            Assert.AreEqual(2, r.Id);
            Assert.AreEqual("Wilbur", r.Name);

            static Task<TestObject> Query(IDbConnection c)
            {
                Assert.IsNotNull(c);
                return Task.FromResult(new TestObject(2, "Wilbur"));
            }
        }

        [Test]
        public async Task QueryAsyncGetsABasicValueFromABasicValue()
        {
            var r = await _q.Execute(Query, 717);
            Assert.AreEqual(717, r);

            static Task<int> Query(IDbConnection c, int p)
            {
                Assert.IsNotNull(c);
                return Task.FromResult(p);
            }
        }

        [Test]
        public async Task QueryAsyncGetsAnObjectFromABasicValue()
        {
            var r = await _q.Execute(Query, 909);
            Assert.AreEqual(909, r.Id);
            Assert.AreEqual("Gaaary", r.Name);

            static Task<TestObject> Query(IDbConnection c, int p)
            {
                Assert.IsNotNull(c);
                return Task.FromResult(new TestObject(p, "Gaaary"));
            }
        }

        [Test]
        public async Task QueryAsyncAccepts2Parameters()
        {
            var r = await _q.Execute(Query, 1, 2);
            Assert.AreEqual(3, r.Id);
            Assert.AreEqual("Baaary", r.Name);

            static Task<TestObject> Query(IDbConnection c, int a, int b)
            {
                Assert.IsNotNull(c);
                return Task.FromResult(new TestObject(a + b, "Baaary"));
            }
        }

        [Test]
        public async Task QueryAsyncAccepts2ParametersAndCancellationToken()
        {
            var r = await _q.Execute(Query, 5, 2);
            Assert.AreEqual(7, r.Id);
            Assert.AreEqual("Boris", r.Name);

            static Task<TestObject> Query(IDbConnection c, int a, int b, CancellationToken cancellationToken)
            {
                Assert.IsNotNull(c);
                return Task.FromResult(new TestObject(a + b, "Boris"));
            }
        }

        
    }
}
