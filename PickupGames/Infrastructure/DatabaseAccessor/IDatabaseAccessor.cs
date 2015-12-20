using System;
using System.Collections.Generic;
using System.Data;

namespace PickupGames.Infrastructure.DatabaseAccessor
{
    public interface IDatabaseAccessor
    {
        void AddParameter(string name, object value);
        void SetCommandText(string command);
        IEnumerable<T> ExecuteReader<T>(Func<IDataReader, T> function);
        int ExecuteScalar();
        void ExecuteNonQuery();
    }
}

