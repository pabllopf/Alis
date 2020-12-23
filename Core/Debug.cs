namespace Alis.Core
{
    using System;

    /// <summary>
    ///   <br />
    /// </summary>
    public class Debug
    {
        /// <summary>Logs the specified message.</summary>
        /// <param name="message">The message.</param>
        public static void Log(String message) 
        {
            Console.WriteLine(message);
        }

        /// <summary>Errors the specified message.</summary>
        /// <param name="message">The message.</param>
        public static void Error(String message) 
        {
            Console.WriteLine(message);
        }
    }
}
