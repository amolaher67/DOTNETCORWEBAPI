using Microsoft.Extensions.Logging;
using System;

namespace SampleCoreWebApi.LogProvider
{
    public class DbLoggerProvider : ILoggerProvider
    {
        private readonly Func<string, LogLevel, bool> _filter;
        private readonly string _connectionString;

        public DbLoggerProvider(Func<string, LogLevel, bool> filter, string connectionStr)
        {
            _filter = filter;
            _connectionString = connectionStr;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new DbLogger(categoryName, _filter, _connectionString);
        }

        public void Dispose()
        {

        }
    }

    public static class DbLoggerExtensions
    {
        public static ILoggerFactory AddContext(this ILoggerFactory factory,Func<string, LogLevel, bool> filter = null, string connectionStr = null)
        {
            factory.AddProvider(new DbLoggerProvider(filter, connectionStr));
            return factory;
        }

        public static ILoggerFactory AddContext(this ILoggerFactory factory, LogLevel minLevel, string connectionStr)
        {
            return AddContext(factory,(_, logLevel) => logLevel >= minLevel, connectionStr);
        }
    }
}
    
