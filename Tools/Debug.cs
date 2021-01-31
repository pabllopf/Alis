//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Debug.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Diagnostics;

    /// <summary>Debug messages.</summary>
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class Debug
    {
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
            Console.WriteLine("Error: " + message);
            Console.ResetColor();
        }

        /// <summary>Gets the debugger display.</summary>
        /// <returns>Debug string</returns>
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}