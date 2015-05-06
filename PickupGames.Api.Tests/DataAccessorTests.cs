using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using NUnit.Framework;
using Rhino.Mocks;

namespace PickupGames.Api.Tests
{
    public interface IUserRepository
    {
        List<User> GetBy(UserSearchRequest userSearchRequest);
    }

    public class UserSearchRequest
    {
        public string Name { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public interface IDataAccessor
    {
        IDataReader ExecuteReader();
        void AddParameter<T>(string key, T value);
        void Save();
    }

    public class UserRepository : IUserRepository
    {
        private readonly IDataAccessor _dataAccessor;

        public UserRepository(IDataAccessor dataAccessor)
        {
            _dataAccessor = dataAccessor;
        }

        public List<User> GetBy(UserSearchRequest userSearchRequest)
        {
            using (var reader = _dataAccessor.ExecuteReader())
            {
                //_dataAccessor.AddParameter("Id", 1);
                //_dataAccessor.AddParameter("Name", "Roy");
                //_dataAccessor.Save();

                reader.Read();
                return new List<User>();
            }
        }
    }

    public class UserRepository2 : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository2(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<User> GetBy(UserSearchRequest userSearchRequest)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var dbCommand = conn.CreateCommand();
                
                var param = dbCommand.CreateParameter();
                param.ParameterName = "@Id";
                param.Value = 1;
                dbCommand.Parameters.Add(param);

                conn.Open();

                using (var reader = dbCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                    }

                    return new List<User>();
                }
            }
        }
    }

    public class MockUserRepository : IUserRepository
    {
        private List<User> _users = new List<User>();

        public List<User> Users
        {
            get { return _users; }
            set { _users = value; }
        }

        public MockUserRepository()
        {
        }

        public MockUserRepository(IDataAccessor dataAccessor)
        {
        }

        public List<User> GetBy(UserSearchRequest userSearchRequest)
        {
            return Users;
        }
    }

    public class DataAccessor : IDataAccessor, IDisposable
    {
        bool _disposed;
        
        IDbCommand _dbCommand;
        readonly IDbConnection _dbConnection;

        public DataAccessor(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            _dbCommand = dbConnection.CreateCommand();
        }

        public void AddParameter<T>(string key, T value)
        {
            var param = _dbCommand.CreateParameter();
            param.ParameterName = "@" + key;
            param.Value = value;
            _dbCommand.Parameters.Add(param);
        }

        public void Save()
        {
            _dbCommand.ExecuteNonQuery();
        }

        public IDataReader ExecuteReader()
        {
            _dbConnection.Open();
            return _dbCommand.ExecuteReader();
        }

        ~DataAccessor()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (_disposed)
            {
                if (disposing)
                {
                    //clean up managed resoureces

                    if (_dbCommand != null && _dbCommand.Connection != null)
                    {
                        _dbCommand.Connection.Close();
                        _dbCommand.Connection.Dispose();
                        _dbCommand.Connection = null;

                        _dbCommand.Dispose();
                        _dbCommand = null;
                    }
                }

                //clean up unmanaged resources
            }

            _disposed = true;
        }
    }

    [TestFixture]
    public class DataAccessorTests
    {
        [SetUp]
        public void Init()
        {
        }

        [Test]
        public void Test()
        {
            var stubConnection = MockRepository.GenerateStub<IDbConnection>();
            var stubCommand = MockRepository.GenerateMock<IDbCommand>();
            var stubReader = MockRepository.GenerateStub<IDataReader>();
            var stubParameter = MockRepository.GenerateStub<IDbDataParameter>();
            var stubParameterCollection = MockRepository.GenerateStub<IDataParameterCollection>();

            stubConnection.Stub(conn => conn.CreateCommand()).Return(stubCommand);
            
            stubCommand.Stub(comm => comm.ExecuteReader()).Return(stubReader);
            stubCommand.Stub(comm => comm.CreateParameter()).Return(stubParameter);
            stubCommand.Stub(comm => comm.Parameters).Return(stubParameterCollection);

            stubReader.Stub(rdr => rdr.Read()).Return(true).Repeat.Times(1);
            stubReader.Stub(rdr => rdr.Read()).Return(false).Repeat.Once();
            stubReader.Stub(rdr => rdr.GetInt32(0)).Return(2).Repeat.Once();
            
            using (var dataAccessor = new DataAccessor(stubConnection))
            {
                dataAccessor.AddParameter("Id", 1);
                var reader = dataAccessor.ExecuteReader();
                reader.Read();
                var val = reader.GetInt32(0);
                Assert.IsTrue(true);
            }
        }

        [Test]
        public void Test2()
        {
            var stubDataAccessor = MockRepository.GenerateStub<IDataAccessor>();
            var userRepository = new MockUserRepository(stubDataAccessor);
            var users = userRepository.GetBy(new UserSearchRequest());
            Assert.AreEqual(0, users.Count);
        }

        [Test]
        public void Test3()
        {
            var userRepository = new MockUserRepository();
            var users = userRepository.GetBy(new UserSearchRequest());
            Assert.AreEqual(0, users.Count);
        }
    }

    [TestFixture]
    public class DataReaderHelperTests
    {
        private MockRepository _mocks;
        private DataReaderHelper.CreateConnection _mockCreateConnection;
        private IDbConnection _mockConnection;
        private IDbCommand _mockCommand;
        private IDataReader _mockReader;
        private DataReaderHelper.ReadDatabaseValue<object> _mockDelegate;
        private object _obj;

        [SetUp]
        public void InitTest()
        {
            _mocks = new MockRepository();
            _mockCreateConnection = _mocks.StrictMock<DataReaderHelper.CreateConnection>();
            _mockConnection = _mocks.StrictMock<IDbConnection>();
            _mockCommand = _mocks.StrictMock<IDbCommand>();
            _mockReader = _mocks.StrictMock<IDataReader>();
            _mockDelegate = _mocks.StrictMock<DataReaderHelper.ReadDatabaseValue<object>>();
            _obj = null;
        }

        [Test]
        public void GetData_ListInt_ReturnsFromDelegateUsingReader()
        {
            DataReaderHelper.CreateConnection stubCreateConnection =
                MockRepository.GenerateStub<DataReaderHelper.CreateConnection>();
            IDbConnection stubConnection = MockRepository.GenerateStub<IDbConnection>();
            IDbCommand stubCommand = MockRepository.GenerateStub<IDbCommand>();
            IDataReader stubReader = MockRepository.GenerateStub<IDataReader>();
            DataReaderHelper.ReadDatabaseValue<List<int>> stubDelegate =
                MockRepository.GenerateStub<DataReaderHelper.ReadDatabaseValue<List<int>>>();
            List<int> testList = new List<int>();

            stubCreateConnection.Stub(get => get()).Return(stubConnection);
            stubConnection.Stub(conn => conn.CreateCommand()).Return(stubCommand);
            stubCommand.Stub(comm => comm.ExecuteReader()).Return(stubReader);
            stubReader.Stub(rdr => rdr.Read()).Return(true).Repeat.Times(2);
            stubReader.Stub(rdr => rdr.Read()).Return(false).Repeat.Once();
            stubReader.Stub(rdr => rdr.GetInt32(0)).Return(2).Repeat.Once();
            stubReader.Stub(rdr => rdr.GetInt32(0)).Return(4).Repeat.Once();
            stubDelegate.Stub(del => del(stubReader, ref testList))
                .WhenCalled(invocation => testList.Add(stubReader.GetInt32(0))).Repeat.Times(2).OutRef(testList);

            DataReaderHelper.GetData<List<int>>(stubCreateConnection, "sql", stubDelegate, ref testList);

            Assert.That(testList.Count, Is.EqualTo(2));
            Assert.That(testList[0], Is.EqualTo(2));
            Assert.That(testList[1], Is.EqualTo(4));
        }
    }

    public class DataReaderHelper
    {
        // generic delegate passed into the GetData method to manipulate the IDataReader object
        public delegate void ReadDatabaseValue<T>(IDataReader reader, ref T businessObject);
        
        // delegate is passed into the GetData method to create a new connection
        public delegate IDbConnection CreateConnection();

        public static void GetData<T>(CreateConnection createConnection, string sql,
            ReadDatabaseValue<T> readDelegate, ref T businessObject)
        {
            IDbConnection dbConnection = null;
            IDbCommand command = null;
            IDataReader reader = null;

            try
            {
                dbConnection = createConnection();
                if (dbConnection.State != ConnectionState.Open) { dbConnection.Open(); }
                command = dbConnection.CreateCommand();
                command.CommandText = sql;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    readDelegate(reader, ref businessObject);
                }
            }
            finally
            {
                if (dbConnection != null) dbConnection.Dispose();
                if (command != null) command.Dispose();
                if (reader != null) reader.Dispose();
            }
        }
    }
}
