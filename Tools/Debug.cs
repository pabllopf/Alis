//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Debug.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Tools
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    /// <summary>Debug messages.</summary>
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class Debug
    {
        private static Level level;

        private static int numObj = 0;

        /// <summary>Logs the specified message.</summary>
        /// <param name="message">The message.</param>
        public static void Log(string message)
        {
            Console.WriteLine("Log: " + message);
        }

        /// <summary>Warnings the specified message.</summary>
        /// <param name="message">The message.</param>
        public static void Warning(string message) 
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Warning: " + message);
            Console.ResetColor();
        }

        /// <summary>Errors the specified message.</summary>
        /// <param name="message">The message.</param>
        public static void Error(string message)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Error: " + message + " Trace: ");
            Console.ResetColor();
        }

        /// <summary>Gets the debugger display.</summary>
        /// <returns>Debug string</returns>
        private string GetDebuggerDisplay()
        {
            return ToString();
        }

        public static void Event(string message)
        {
            Console.WriteLine("Event: " + message);
        }

        public static void System() 
        {
            double memory = 0.0f;
            using (var mem = Process.GetCurrentProcess())
            {
                memory = mem.PrivateMemorySize64 / 1024;
            }

            double gc = GC.GetTotalMemory(true) / 1024;

            Console.WriteLine("System: " + "Memory{" + memory + " Kb} Garbage Collector{" + gc + " Kb}");
        }

        public static void CountObjects(bool increment) 
        {
            if (increment)
            {
                numObj++;
            }
            else 
            {
                numObj--;
            }

            Console.WriteLine("Total Objects: " + numObj + " objs");
        }

        public static void Event<T>(T obj)
        {
            Console.WriteLine("Event: " + obj.GetType().FullName + "." + new StackTrace().GetFrame(1).GetMethod().Name.Split('_')[1]);
        }

        public static void Event<T>(T obj, string message)
        {
            Console.WriteLine("Event: " + obj.GetType().FullName + "." + new StackTrace().GetFrame(1).GetMethod().ToString() + " Action: " + message);
        }
    }
}