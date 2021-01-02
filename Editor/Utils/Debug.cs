//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Debug.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Alis.Editor.Utils
{
    /// <summary>Manage the messages to show in consoles.</summary>
    public class Debug
    {
        /// <summary>Logs the specified message.</summary>
        /// <param name="message">The message.</param>
        public static void Log(string message)
        {
            System.Console.WriteLine(message);
        }

        /// <summary>Warnings the specified message.</summary>
        /// <param name="message">The message.</param>
        public static void Warning(string message)
        {
            System.Console.WriteLine(message);
        }

        /// <summary>Errors the specified message.</summary>
        /// <param name="message">The message.</param>
        public static void Error(string message)
        {
            System.Console.BackgroundColor = System.ConsoleColor.Red;
            System.Console.WriteLine(message);
            System.Console.ResetColor();

            System.Console.WriteLine("Press ANY KEY to close console.");
            System.Console.ReadKey();
        }

        /// <summary>Exceptions the specified message.</summary>
        /// <param name="message">The message.</param>
        public static void Exception(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}
