using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SampleCoreWebApi.LogProvider
{
    public partial class EventLog
    {
        public int Id { get; set; }
        public int? EventId { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public DateTime? CreatedTime { get; set; }
    }

    public class SqlHelper
    {
        private string ConnectionString { get; set; }

        public SqlHelper(string connectionStr)
        {
            ConnectionString = connectionStr;
        }

        private bool ExecuteNonQuery(string commandStr, List<SqlParameter> paramList)
        {
            var result = false;
            using (var conn = new SqlConnection(ConnectionString))
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                using (var command = new SqlCommand(commandStr, conn))
                {
                    command.Parameters.AddRange(paramList.ToArray());
                    var count = command.ExecuteNonQuery();
                    result = count > 0;
                }
            }
            return result;
        }

        public bool InsertLog(EventLog log)
        {
            var command = $@"INSERT INTO [dbo].[EventLog] ([EventID],[LogLevel],[Message],[CreatedTime]) VALUES (@EventID, @LogLevel, @Message, @CreatedTime)";

            var paramList = new List<SqlParameter>
            {
                new SqlParameter("EventID", log.EventId),
                new SqlParameter("LogLevel", log.LogLevel),
                new SqlParameter("Message", log.Message),
                new SqlParameter("CreatedTime", log.CreatedTime)
            };

            return ExecuteNonQuery(command, paramList);
        }
    }

    // 
    // Summary: 
    //     Defines logging severity levels. 
    public enum LoggingEvents
    {
        GENERATE_ITEMS = 1000,
        LIST_ITEMS = 1001,
        GET_ITEM,
        INSERT_ITEM,
        UPDATE_ITEM,
        DELETE_ITEM
    }
}