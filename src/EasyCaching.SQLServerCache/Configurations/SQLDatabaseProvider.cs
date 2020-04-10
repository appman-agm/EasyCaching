﻿using EasyCaching.Core;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace EasyCaching.SQLServer.Configurations
{
    public class SQLDatabaseProvider : ISQLDatabaseProvider
    {
        /// <summary>
        /// The options.
        /// </summary>
        private readonly SQLDBOptions _options;

        public SQLDatabaseProvider(IOptionsMonitor<SQLServerOptions> optionAction)
        {
            this._options = optionAction.CurrentValue.DBConfig;
        }

        public SQLDatabaseProvider(string name, SQLServerOptions options)
        {
            this._name = name;
            this._options = options.DBConfig;
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_options.ConnectionString);
        }

        private readonly string _name = EasyCachingConstValue.DefaultSQLServerName;
        public string DBProviderName => _name;
    }
}