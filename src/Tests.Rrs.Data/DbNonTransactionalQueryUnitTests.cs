using NUnit.Framework;
using Rrs.Data;
using System.Data;
using System.Threading.Tasks;

namespace Tests.Rrs.Data
{
    public class DbNonTransactionalQueryUnitTests
    {
        private IDbDelegator _q;

        [SetUp]
        public void Setup()
        {
            _q = new DbDelegator(MockIDbConnectionFactoryFacade.Create().MockDbConnectionFactory.Object);
        }

        [Test]
        public void QueryGetsABasicValue()
        {
            var r = _q.Execute(Query);
            Assert.AreEqual("Moooo!", r);
        }

        private string Query(IDbConnection c)
        {
            Assert.IsNotNull(c);
            return "Moooo!";
        }

        public void QueryAsyncGetsABasicValue()
        {
            var r = _q.Execute(QueryAsync).Result;
            Assert.AreEqual("Moooo!", r);
        }

        private Task<string> QueryAsync(IDbConnection c)
        {
            Assert.IsNotNull(c);
            return Task.FromResult("Moooo!");
        }

        [Test]
        public void QueryGetsAnObject()
        {
            var r = _q.Execute(QueryReturnsAnObject);
            Assert.AreEqual(2, r.Id);
            Assert.AreEqual("Wilbur", r.Name);
        }

        private TestObject QueryReturnsAnObject(IDbConnection c)
        {
            Assert.IsNotNull(c);
            return new TestObject(2, "Wilbur");
        }

        [Test]
        public void QueryAsyncGetsAnObject()
        {
            var r = _q.Execute(QueryAsyncReturnsAnObject).Result;
            Assert.AreEqual(2, r.Id);
            Assert.AreEqual("Wilbur", r.Name);
        }

        private Task<TestObject> QueryAsyncReturnsAnObject(IDbConnection c)
        {
            Assert.IsNotNull(c);
            return Task.FromResult(new TestObject(2, "Wilbur"));
        }

        [Test]
        public void QueryGetsABasicValueFromABasicValue()
        {
            var r = _q.Execute(Query, 717);
            Assert.AreEqual(717, r);
        }

        private int Query(IDbConnection c, int p)
        {
            Assert.IsNotNull(c);
            return p;
        }

        [Test]
        public void QueryAsyncGetsABasicValueFromABasicValue()
        {
            var r = _q.Execute(QueryAsync, 717).Result;
            Assert.AreEqual(717, r);
        }

        private Task<int> QueryAsync(IDbConnection c, int p)
        {
            Assert.IsNotNull(c);
            return Task.FromResult(p);
        }

        [Test]
        public void QueryGetsAnObjectFromABasicValue()
        {
            var r = _q.Execute(QueryReturnsAnObject, 909);
            Assert.AreEqual(909, r.Id);
            Assert.AreEqual("Gaaary", r.Name);
        }

        private TestObject QueryReturnsAnObject(IDbConnection c, int p)
        {
            Assert.IsNotNull(c);
            return new TestObject(p, "Gaaary");
        }

        [Test]
        public void QueryAsyncGetsAnObjectFromABasicValue()
        {
            var r = _q.Execute(QueryAsyncReturnsAnObject, 909).Result;
            Assert.AreEqual(909, r.Id);
            Assert.AreEqual("Gaaary", r.Name);
        }

        private Task<TestObject> QueryAsyncReturnsAnObject(IDbConnection c, int p)
        {
            Assert.IsNotNull(c);
            return Task.FromResult(new TestObject(p, "Gaaary"));
        }

        [Test]
        public void QueryAccepts2Parameters()
        {
            var r = _q.Execute(QueryWith2Paramters, 1, 2);
            Assert.AreEqual(3, r.Id);
            Assert.AreEqual("Baaary", r.Name);
        }

        private TestObject QueryWith2Paramters(IDbConnection c, int a, int b)
        {
            Assert.IsNotNull(c);
            return new TestObject(a + b, "Baaary");
        }

        [Test]
        public void QueryAsyncAccepts2Parameters()
        {
            var r = _q.Execute(QueryAsyncWith2Paramters, 1, 2).Result;
            Assert.AreEqual(3, r.Id);
            Assert.AreEqual("Baaary", r.Name);
        }

        private Task<TestObject> QueryAsyncWith2Paramters(IDbConnection c, int a, int b)
        {
            Assert.IsNotNull(c);
            return Task.FromResult(new TestObject(a + b, "Baaary"));
        }
    }
}
