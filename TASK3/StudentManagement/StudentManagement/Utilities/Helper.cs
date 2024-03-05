using Castle.MicroKernel.Registration;
using StudentManagement.Data.Dapper;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace StudentManagement.Utilities
{
    internal class Helper
    {
        public static List<T> ConvertDataTableToList<T>(DataTable dataTable) 
        {
            List<T> list = new List<T>();
            foreach (DataRow row in dataTable.Rows)
            {
                T item = Activator.CreateInstance<T>();

                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    PropertyInfo propertyInfo = typeof(T).GetProperty(dataColumn.ColumnName);
                    if (propertyInfo != null && row[dataColumn] != DBNull.Value)
                    {
                        //propertyInfo.SetValue(item, row[dataColumn]);
                        if (propertyInfo.PropertyType == typeof(string))
                        {
                            propertyInfo.SetValue(item, row[dataColumn].ToString());
                        }
                        else
                        {
                            propertyInfo.SetValue(item, row[dataColumn]);
                        }
                    }
                }
                list.Add(item);
            }
            return list;
        }
       
        public static string ConvertDateString(string input) {
            string format = "dd/MM/yyyy hh:mm:ss tt";
            string outputFormat = "dd/MM/yyyy";
            bool checkDate = IsDateStringValid(input, format);
            if (checkDate == true)
            {
                DateTime dateTime = DateTime.ParseExact(input, format, null);
                input = dateTime.ToString(outputFormat);
            }
            return input;
        }
        public static bool IsDateStringValid(string input, string format)
        {
   
            return DateTime.TryParseExact(input, format, null, System.Globalization.DateTimeStyles.None, out _);
        }
     

    }
}
