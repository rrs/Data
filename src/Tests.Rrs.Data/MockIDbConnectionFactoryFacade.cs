using Moq;
using Rrs.Data;
using System.Data;

namespace Tests.Rrs.Data
{
    class MockIDbConnectionFactoryFacade
    {
        public Mock<IDbConnection> MockDbConnection { get; }
        public Mock<IDbTransaction> MockDbTransaction { get; }
        public Mock<IDbConnectionFactory> MockDbConnectionFactory { get; }

        public MockIDbConnectionFactoryFacade(Mock<IDbConnection> mockDbConnection, Mock<IDbTransaction> mockDbTransaction, Mock<IDbConnectionFactory> mockDbConnectionFactory)
        {
            MockDbConnection = mockDbConnection;
            MockDbTransaction = mockDbTransaction;
            MockDbConnectionFactory = mockDbConnectionFactory;
        }

        public static MockIDbConnectionFactoryFacade Create()
        {
            var dbtMock = new Mock<IDbTransaction>();

            var dbcMock = new Mock<IDbConnection>();
            dbcMock.Setup(o => o.BeginTransaction()).Returns(dbtMock.Object);
            var dbcFactoryMock = new Mock<IDbConnectionFactory>();
            dbcFactoryMock.Setup(o => o.OpenConnection()).Returns(dbcMock.Object);

            return new MockIDbConnectionFactoryFacade(dbcMock, dbtMock, dbcFactoryMock);
        }
    }
}
