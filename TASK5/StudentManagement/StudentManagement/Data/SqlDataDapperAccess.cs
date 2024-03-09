using Castle.Core.Resource;
using Dapper;
using NHibernate.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data
{
    public class SqlDataDapperAccess<T>
    {
        private readonly string _connectionString;
        public SqlDataDapperAccess(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public bool Excute(string query, params (string, object)[] parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var dynamicParameters = new DynamicParameters();
                foreach (var parameter in parameters)
                {
                    dynamicParameters.Add(parameter.Item1, parameter.Item2);
                }
                var affectedRows = connection.Execute(query, dynamicParameters);
                return affectedRows > 0;
            }
        }
        public List<T> Query(string query, params (string, object)[] parameters) { 
            using( var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var dynamicParameters = new DynamicParameters();
                foreach (var parameter in parameters)
                {
                    dynamicParameters.Add(parameter.Item1, parameter.Item2);
                }
                var list = connection.Query<T>(query, dynamicParameters).ToList();
                return list;
            }
        }
        public double ExecuteScalar(string query, params (string, object)[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var dynamicParameters = new DynamicParameters();
                foreach(var parameter in parameters)
                {
                    dynamicParameters.Add(parameter.Item1, parameter.Item2);
                }
                return connection.ExecuteScalar<double>(query, dynamicParameters);
            }
        }


    }
}
