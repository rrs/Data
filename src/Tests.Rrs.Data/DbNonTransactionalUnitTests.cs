using NUnit.Framework;
using Rrs.Data;
using System.Data;

namespace Tests.Rrs.Data
{
    public class DbNonTransactionalUnitTests
    {
        private IDbDelegator _q;

        [SetUp]
        public void Setup() => _q = new DbDelegator(MockIDbConnectionFactoryFacade.Create().MockDbConnectionFactory.Object);

        [Test]
        public void CommandGetsAConnection()
        {
            _q.Execute(Command);
            static void Command(IDbConnection c)
            {
                Assert.IsNotNull(c);
            }
        }

        [Test]
        public void TestCommandWithABasicParameter()
        {
            _q.Execute(Command, 5);
            
            static void Command(IDbConnection c, int p)
            {
                Assert.IsNotNull(c);
                Assert.AreEqual(5, p);
            }
        }


        [Test]
        public void TestCommandWithAnObjectParameter()
        {
            _q.Execute(Command, new TestObject(67, "Barry"));
            
            static void Command(IDbConnection c, TestObject p)
            {
                Assert.IsNotNull(c);
                Assert.AreEqual(67, p.Id);
                Assert.AreEqual("Barry", p.Name);
            }
        }

        [Test]
        public void QueryGetsABasicValue()
        {
            var r = _q.Execute(Query);
            Assert.AreEqual("Moooo!", r);
            static string Query(IDbConnection c)
            {
                Assert.IsNotNull(c);
                return "Moooo!";
            }
        }

        [Test]
        public void QueryGetsAnObject()
        {
            var r = _q.Execute(Query);
            Assert.AreEqual(2, r.Id);
            Assert.AreEqual("Wilbur", r.Name);

            static TestObject Query(IDbConnection c)
            {
                Assert.IsNotNull(c);
                return new TestObject(2, "Wilbur");
            }
        }

        [Test]
        public void QueryGetsABasicValueFromABasicValue()
        {
            var r = _q.Execute(Query, 717);
            Assert.AreEqual(717, r);

            static int Query(IDbConnection c, int p)
            {
                Assert.IsNotNull(c);
                return p;
            }
        }

        [Test]
        public void QueryGetsAnObjectFromABasicValue()
        {
            var r = _q.Execute(Query, 909);
            Assert.AreEqual(909, r.Id);
            Assert.AreEqual("Gaaary", r.Name);

            static TestObject Query(IDbConnection c, int p)
            {
                Assert.IsNotNull(c);
                return new TestObject(p, "Gaaary");
            }
        }

        public void CommandWith2Parameters()
        {
            _q.Execute(Command, 1, 2);

            static void Command(IDbConnection c, int a, int b)
            {
                Assert.IsNotNull(c);
                Assert.AreEqual(1, a);
                Assert.AreEqual(2, b);
            }
        }

        [Test]
        public void QueryAccepts3Parameters()
        {
            var r = _q.Execute(Query, 1, 2, 3);
            Assert.AreEqual(6, r.Id);
            Assert.AreEqual("Baaary", r.Name);

            static TestObject Query(IDbConnection c, int x, int y, int z)
            {
                Assert.IsNotNull(c);
                Assert.AreEqual(1, x);
                Assert.AreEqual(2, y);
                Assert.AreEqual(3, z);
                return new TestObject(x + y + z, "Baaary");
            }
        }
    }
}