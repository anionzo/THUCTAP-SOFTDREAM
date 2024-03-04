using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data
{
    internal class SqlDataAccess<T> :IDataAccess<T>
    {
        private readonly string _connectionString;
        public SqlDataAccess(string connectionString) { 
            this._connectionString = connectionString;
        }

        public bool ExecuteNonQuery(string query, params (string, object)[] parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                try
                {
                    connection.Execute(query, parameters);
                  
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi Rồi: " + ex);
                    return false;
                }
            }

            
        }

        IEnumerable<T> IDataAccess<T>.ExecuteQuery(string query, params (string, object)[] parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    return connection.Query<T>(query, parameters);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi rồi: " + ex);
                    return Enumerable.Empty<T>();
                }
            }
        }
    }
}
