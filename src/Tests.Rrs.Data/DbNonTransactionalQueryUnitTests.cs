using NUnit.Framework;
using Rrs.Data;
using System.Data;

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
    }
}
