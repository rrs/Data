using NUnit.Framework;
using Rrs.Data;
using System;
using System.Data;

namespace Tests.Rrs.Data
{
    public class DbTransactionalCommandUnitTests
    {
        private MockIDbConnectionFactoryFacade _f;
        private IDbDelegator _q;

        [SetUp]
        public void Setup()
        {
            _f = MockIDbConnectionFactoryFacade.Create();
            _q = new DbDelegator(_f.MockDbConnectionFactory.Object);
        }

        [Test]
        public void CommandGetsAConnectionAndATransactionAndCommits()
        {
            _q.Execute(Command);
            _f.MockDbTransaction.Verify(o => o.Commit());
        }

        private static void Command(IDbConnection c, IDbTransaction t)
        {
            Assert.IsNotNull(c);
            Assert.IsNotNull(t);
        }

        [Test]
        public void CommandRollsbackOnException()
        {
            Assert.Throws<Exception>(() => _q.Execute(ExceptionCommand));
            _f.MockDbTransaction.Verify(o => o.Rollback());
        }

        private static void ExceptionCommand(IDbConnection c, IDbTransaction t)
        {
            throw new Exception();
        }

        [Test]
        public void TestCommandWithABasicParameter() => _q.Execute(Command, new DateTime(2001,2,3,4,5,6));

        private static void Command(IDbConnection c, IDbTransaction t, DateTime p)
        {
            Assert.IsNotNull(c);
            Assert.AreEqual(new DateTime(2001, 2, 3, 4, 5, 6), p);
        }

        [Test]
        public void TestCommandWithAnObjectParameter() => _q.Execute(Command, new TestObject(4056, "Mildred"));

        private static void Command(IDbConnection c, TestObject p)
        {
            Assert.IsNotNull(c);
            Assert.AreEqual(4056, p.Id);
            Assert.AreEqual("Mildred", p.Name);
        }
    }
}