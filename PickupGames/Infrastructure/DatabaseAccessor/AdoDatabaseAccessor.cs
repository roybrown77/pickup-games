using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PickupGames.Infrastructure.Logging;

namespace PickupGames.Infrastructure.DatabaseAccessor
{
    public class AdoDatabaseAccessor : IDatabaseAccessor
    {
        private readonly string _connectionString;
        private string _commandText;
        private Dictionary<string, object> _params = new Dictionary<string, object>();
        private readonly IApplicationLogger _logger;

        public AdoDatabaseAccessor(string connectionString, IApplicationLogger logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }

        public Dictionary<string, object> Params
        {
            get { return _params; }
            set { _params = value; }
        }

        public void AddParameter(string key, object value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key is null.");
            }

            if (key == string.Empty)
            {
                throw new ArgumentException("Key is empty.");
            }

            if (value == null)
            {
                throw new ArgumentNullException("Value is null.");
            }

            Params.Add(key, value);
        }

        public void SetCommandText(string command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("Command is null.");
            }

            if (command == string.Empty)
            {
                throw new ArgumentException("Command is empty.");
            }

            _commandText = command;
        }

        public IEnumerable<T> ExecuteReader<T>(Func<IDataReader, T> function)
        {
            if (_commandText == null)
            {
                throw new ArgumentNullException("CommandText is null.");
            }

            if (_commandText == string.Empty)
            {
                throw new ArgumentException("CommandText is empty.");
            }

            if (function == null)
            {
                throw new ArgumentNullException("Function is null.");
            }

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                SetParameters(cmd);

                cmd.CommandText = _commandText;                

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    var data = reader.Select(function);                    

                    return data.ToList();
                }
            }
        }

        public int ExecuteScalar()
        {
            if (_commandText == null)
            {
                throw new ArgumentNullException("CommandText is null.");
            }

            if (_commandText == string.Empty)
            {
                throw new ArgumentException("CommandText is empty.");
            }

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                SetParameters(cmd);

                cmd.CommandText = _commandText;                

                conn.Open();

                var data = (int)cmd.ExecuteScalar();                

                return data;
            }
        }

        public void ExecuteNonQuery()
        {
            if (_commandText == null)
            {
                throw new ArgumentNullException("CommandText is null.");
            }

            if (_commandText == string.Empty)
            {
                throw new ArgumentException("CommandText is empty.");
            }

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                SetParameters(cmd);

                cmd.CommandText = _commandText;

                conn.Open();

                cmd.ExecuteNonQuery();                
            }
        }

        private void SetParameters(SqlCommand cmd)
        {
            if (Params == null)
            {
                throw new ArgumentNullException("Params is null.");
            }

            foreach (var paramRecord in Params)
            {
                var param = cmd.CreateParameter();
                param.Value = paramRecord.Value;
                param.ParameterName = "@" + paramRecord.Key;
                
                // TODO: resolve this issue
                // We were blindly implicitly setting the dbtype to string = nvarchar.
                // The sql schema was calling for ansitring = varchar
                // there is a seemingly HUGE performance penatly by using nvarchar on varchar schema
                // For now we will assume ALL parameters are varchar 
                param.DbType = DbType.AnsiString;
                cmd.Parameters.Add(param);
            }

            //var correlationId = LoggingHelper.GetCorrelationId();
            //_logger.Log(string.Format("Correlation Id: {0}, Execute Sql statement: {1} Parameters: {2}", correlationId, _commandText, GetParameterMessage()), LogType.Info);

            _logger.Log(string.Format("Execute Sql statement: {0} Parameters: {1}", _commandText, GetParameterMessage()), LogType.Info);

            Params.Clear();
        }

        private string GetParameterMessage()
        {
            if (Params == null || Params.Count == 0)
            {
                return null;
            }

            var parameterMessage = Params.Select(paramRecord => string.Format("ParamKey: {0} ParamValue: {1}", paramRecord.Key, paramRecord.Value)).ToList();

            return string.Join(", ", parameterMessage);
        }
    }
}
