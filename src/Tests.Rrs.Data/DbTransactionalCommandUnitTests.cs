using Moq;
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
            _q.Transaction(Command);
            _f.MockDbTransaction.Verify(o => o.Commit());
            _f.MockDbTransaction.Verify(o => o.Rollback(), Times.Never);

            static void Command(IDbTransaction t)
            {
                Assert.IsNotNull(t);
            }
        }

        [Test]
        public void CommandRollsbackOnException()
        {
            Assert.Throws<Exception>(() => _q.Transaction(Command));
            _f.MockDbTransaction.Verify(o => o.Rollback());
            _f.MockDbTransaction.Verify(o => o.Commit(), Times.Never);

            static void Command(IDbTransaction t)
            {
                throw new Exception();
            }
        }

        [Test]
        public void TestCommandWithABasicParameter()
        {
            _q.Transaction(Command, new DateTime(2001, 2, 3, 4, 5, 6));

            static void Command(IDbTransaction t, DateTime p)
            {
                Assert.IsNotNull(t);
                Assert.AreEqual(new DateTime(2001, 2, 3, 4, 5, 6), p);
            }
        }

        [Test]
        public void TestCommandWithAnObjectParameter()
        {
            _q.Transaction(Command, new TestObject(4056, "Mildred"));

            static void Command(IDbTransaction c, TestObject p)
            {
                Assert.IsNotNull(c);
                Assert.AreEqual(4056, p.Id);
                Assert.AreEqual("Mildred", p.Name);
            }
        }
    }
}