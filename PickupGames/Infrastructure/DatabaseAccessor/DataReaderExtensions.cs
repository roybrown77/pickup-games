using System;
using System.Collections.Generic;
using System.Data;

namespace PickupGames.Infrastructure.DatabaseAccessor
{
    public static class DataReaderExtensions
    {
        public static IEnumerable<T> Select<T>(this IDataReader reader, Func<IDataReader, T> projection)
        {
            while (reader.Read())
            {
                yield return projection(reader);
            }
        }
    }
}
