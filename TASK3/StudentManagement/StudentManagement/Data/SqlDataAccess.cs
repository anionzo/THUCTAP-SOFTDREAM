using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data
{
    internal class SqlDataAccess<T> : IDataAccess<T>
    {
        private readonly string _connectionString;
        public SqlDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool ExecuteNonQuery(string query, params (string, object)[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.AddWithValue(parameter.Item1, parameter.Item2);
                    }

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi: " + ex.ToString());
                    }
                }
            }

            //Console.WriteLine("Thao tác đã được thực hiện thành công.");
            return true;
        }

        public DataTable ExecuteQuery(string query, params (string, object)[] parameters)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.AddWithValue(parameter.Item1, parameter.Item2);
                    }

                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            //Console.WriteLine("Truy vấn đã được thực hiện thành công.");
            return dataTable;
        }

        public double ExecuteScalar(string query, params (string, object)[] parameters)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.AddWithValue(parameter.Item1, parameter.Item2);
                        }
                        connection.Open();
                        double count = Convert.ToDouble(command.ExecuteScalar()) ;
                        return count;
                    }catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi: " + ex.ToString());
                        return 0;

                    }
                }
            }
        }
    }
}
