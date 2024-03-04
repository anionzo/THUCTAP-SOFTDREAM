using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data
{
    internal interface IDataAccess<T>
    {
        bool ExecuteNonQuery(string query, params (string, object)[] parameters);
        IEnumerable<T> ExecuteQuery(string query, params (string, object)[] parameters);
    }
}
