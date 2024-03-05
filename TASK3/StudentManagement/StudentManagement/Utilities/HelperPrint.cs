using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Utilities
{
    internal class HelperPrint
    {
        public static void PrintTable<T>(List<T> dataList, List<string> nameHeader, int length =15)
        {
            if (dataList == null || dataList.Count == 0)
            {
                Console.WriteLine("Empty table.");
                return;
            }
            List<int> columnWidths = new List<int>();
            string header = null;
            foreach (var name in nameHeader)
            {
                header += name.PadRight(length);
                columnWidths.Add(length);
            }

            Console.WriteLine(header);
            foreach (var item in dataList)
            {
                PrintRow(item, length);
            }
        }
        public static void PrintRow<T>(T row, int columnWidths)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            List<string> formattedValues = new List<string>();

            foreach (var property in properties)
            {
                string value = property.GetValue(row)?.ToString() ?? "";
                value = Helper.ConvertDateString(value);
                formattedValues.Add(value.PadRight(columnWidths));
            }

            string rowString = string.Join("", formattedValues);
            Console.WriteLine(rowString);
        }
        public static void Print<T>(T item, List<string> strings)
        {
            int index = 0;
            HelperColor.WriteLineWithColor("Chi Tiết", ConsoleColor.Green);
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach(var property in properties)
            {
                string value = property.GetValue(item)?.ToString() ?? "";
                value = Helper.ConvertDateString(value);
                Console.WriteLine(strings[index++].PadRight(13) + ": ".PadRight(0) + value.PadRight(10));

            }
        }
    }
}
