//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Debug.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    /// <summary>
    /// Define the log system.
    /// </summary>
    /// <remarks>Control the logs of system.</remarks>
    internal static class Debug
    {
        private static Level level;

        internal static Level Level
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Print simple message to console
        /// </summary>
        public static void Log(string message)
        {
            throw new System.NotImplementedException();
        }



        /// <summary>
        /// Print simple warning to console
        /// </summary>
        public static void Warning()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Print simple error to console
        /// </summary>
        public static void Error()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Print fatal error to console
        /// </summary>
        public static void FatalError()
        {
            throw new System.NotImplementedException();
        }
    }
}