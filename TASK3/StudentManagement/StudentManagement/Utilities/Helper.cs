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
       
        public static string ConvertDateString(object input) {
            string format = "dd/MM/yyyy hh:mm:ss tt";
            string outputFormat = "dd/MM/yyyy";
            bool checkDate = IsDateStringValid(input, format);
            if (checkDate == true)
            {
                DateTime dateTime = DateTime.ParseExact(input.ToString(), format, null);
                input = dateTime.ToString(outputFormat);
            }
            return input.ToString();
        }
        public static bool IsDateStringValid(object input, string format)
        {
   
            return DateTime.TryParseExact(input.ToString(), format, null, System.Globalization.DateTimeStyles.None, out _);
        }

        public static bool IsInRange(decimal number)
        {
            return (number >= 0 && number <= 10);
        }
        public static bool IsDecimal(string input)
        {
            decimal result;
            return decimal.TryParse(input, out result);
        }
    }
}
