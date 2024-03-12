using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Utilities
{
    public class HelperColor
    {
        public static ConsoleColor Red = ConsoleColor.Red;
        public static ConsoleColor Blue = ConsoleColor.Blue;
        public static ConsoleColor Green = ConsoleColor.Green;
        public static ConsoleColor Yellow = ConsoleColor.Yellow;
        public static void WriteLineWithColor(string message, ConsoleColor color)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = originalColor;
        }
        public static void WriteWithColor(string message, ConsoleColor color)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = originalColor;
        }
    }
}
