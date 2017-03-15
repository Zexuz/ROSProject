using System;
using System.Data;

namespace ROS.Extensions
{
    public static class SqlReaderExtension
    {
        public static string GetStringNullCheck(this IDataReader reader, int ordinal)
        {
            return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);
        }

        public static DateTime GetDateTimeNullCheck(this IDataReader reader, int ordinal)
        {
            return reader.IsDBNull(ordinal) ? DateTime.MinValue : reader.GetDateTime(ordinal);
        }

        public static int GetIntNullCheck(this IDataReader reader, int ordinal)
        {
            return reader.IsDBNull(ordinal) ? 0: reader.GetInt32(ordinal);
        }
    }
}